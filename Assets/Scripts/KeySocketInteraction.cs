using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySocketInteraction : MonoBehaviour
{
    public GameObject key; 
    public GameObject theLock;
    public Animator doorAnimator;


    private void Start() {
        doorAnimator = GameObject.Find("Entrance/Door").GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == key)
        {
            KeyInserted();
        }
    }

    void KeyInserted()
    {
        Invoke("OpenLock", 1.0f); 
    }

    void OpenLock()
    {
        doorAnimator.SetBool("Open",true);
    }

    public void CloseDoor(){
        doorAnimator.SetBool("Close",true);
    }
}
