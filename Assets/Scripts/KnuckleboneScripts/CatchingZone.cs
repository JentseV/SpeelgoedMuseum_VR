using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingZone : MonoBehaviour
{
    private GameObject caughtObject;
    [SerializeField]
    private float zOffset;

    // Update is called once per frame
    void Update()
    {
        ShootRaycastUp();
        if (caughtObject != null)
        {
            if((Mathf.Abs(gameObject.transform.rotation.eulerAngles.x) < 30 ||  Mathf.Abs(gameObject.transform.rotation.eulerAngles.x) > 330) 
            && (Mathf.Abs(gameObject.transform.rotation.eulerAngles.z) < 30 + zOffset||  Mathf.Abs(gameObject.transform.rotation.eulerAngles.z) > 330 + zOffset) )
            {
                HoldCaughtObject();
            }
            else
            {
                caughtObject.transform.parent = null;
                caughtObject.transform.localScale = new Vector3(3,3,3);
                Rigidbody rb = caughtObject.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                caughtObject = null;
            }
        }

    }

    private void HoldCaughtObject()
    {
        caughtObject.transform.rotation = transform.rotation;
        caughtObject.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("catchable") && (caughtObject == null) && (gameObject.transform.position.y < other.transform.position.y))
        {
            caughtObject = other.gameObject;
            caughtObject.transform.parent = transform;
            Debug.Log("caught object");
        }
    }

    public void TryCatch(GameObject other)
    {

    }
        public float raycastDistance = 10f;

    void ShootRaycastUp()
    {
        // Get the position of the GameObject this script is attached to
        Vector3 raycastOrigin = transform.position;

        // Shoot a raycast in the upward direction from the GameObject's position
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin, Vector3.up, out hit, raycastDistance))
        {
            // The ray hit something
            Debug.Log("Ray hit: " + hit.collider.gameObject.name);

            // You can perform additional actions here, based on what the ray hit
        }
        else
        {
            // The ray did not hit anything
            Debug.Log("Ray did not hit anything");
        }
    }
}