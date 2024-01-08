using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeySocketInteraction : MonoBehaviour
{
    public GameObject key; 
    public GameObject theLock;
    public Animator doorAnimator;
    public XRGrabInteractable grabInteractable;

    private Rigidbody keyRigidbody; 

    private bool openDoor = false;
    public GameObject keyToEnable;

    private void Start() {
        doorAnimator = GameObject.Find("Entrance/Door").GetComponent<Animator>();
        grabInteractable = key.GetComponent<XRGrabInteractable>();
        keyRigidbody = key.GetComponent<Rigidbody>();
        if (keyRigidbody != null)
        {
            keyRigidbody.useGravity = false; 
        }
    }
    private void Update() {
        if(openDoor){
            doorAnimator.SetBool("openDoor", true);
        }
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
        Debug.Log("Key inserted");
        keyToEnable.SetActive(true);
        key.SetActive(false);

        if (grabInteractable != null)
        {
            grabInteractable.enabled = false;
        }

        Invoke("OpenLock", 1.0f); 
    }

    void OpenLock()
    {
        openDoor = true;

    }


}
