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
        if (caughtObject != null)
        {
            if((Mathf.Abs(gameObject.transform.rotation.eulerAngles.x) < 30 ||  Mathf.Abs(gameObject.transform.rotation.eulerAngles.x) > 330) && (Mathf.Abs(gameObject.transform.rotation.eulerAngles.z) < 30 + zOffset||  Mathf.Abs(gameObject.transform.rotation.eulerAngles.z) > 330 + zOffset) )
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
                Debug.Log("Dropped object");
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
        if (other.CompareTag("catchable") && (caughtObject == null)) //add check for grab cooldown
        {
            caughtObject = other.gameObject;
            caughtObject.transform.parent = transform;
            Debug.Log("caught object");
        }
    }
}