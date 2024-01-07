using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingZone : MonoBehaviour
{
    private GameObject caughtObject;
    [SerializeField]
    private float zOffset;
    [SerializeField]
    private Transform hook;
    
    public CoinChest coinChest;
    public float raycastDistance = 10f;



    // Update is called once per frame
    void Update()
    {
        ShootRaycastUp();
        if (caughtObject != null)
        {
            if((Mathf.Abs(gameObject.transform.rotation.eulerAngles.x) < 45 ||  Mathf.Abs(gameObject.transform.rotation.eulerAngles.x) > 315) 
            && (Mathf.Abs(gameObject.transform.rotation.eulerAngles.z) < 45 + zOffset||  Mathf.Abs(gameObject.transform.rotation.eulerAngles.z) > 315 + zOffset) )
            {
                HoldCaughtObject();
            }
            else
            {
                caughtObject.transform.parent = null;
                Rigidbody rb = caughtObject.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                caughtObject = null;
            }
        }

    }

    private void HoldCaughtObject()
    {
        caughtObject.transform.rotation = hook.rotation;
        caughtObject.transform.position = hook.position;
        Rigidbody rb = caughtObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("catchable") && (caughtObject == null) && (gameObject.transform.position.y < other.transform.position.y))
        {
            caughtObject = other.gameObject;
            caughtObject.transform.parent = transform;
            coinChest.PlayerScored();
            Debug.Log("caught object");
        }
    }

    void ShootRaycastUp()
    {
        Vector3 raycastOrigin = transform.position;
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin, Vector3.up, out hit, raycastDistance))
        {
            Debug.Log("Ray hit: " + hit.collider.gameObject.name);
        }
    }
}