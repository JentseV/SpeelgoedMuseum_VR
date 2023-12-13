using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAboveFloor : MonoBehaviour
{
    public float floor;
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < floor - 0.05)
        {
            Vector3 newPosition = gameObject.transform.position;
            newPosition.y = floor;
            gameObject.transform.position = newPosition;
            Rigidbody rb = GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.velocity = Vector3.zero;
            }

            gameObject.transform.localScale = new Vector3(3,3,3);
            gameObject.transform.rotation = Quaternion.identity;
        }
    }
}
