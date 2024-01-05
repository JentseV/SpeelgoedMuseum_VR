using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySocketInteraction : MonoBehaviour
{
    public GameObject key; 
    public GameObject theLock;
    public Animator doorAnimator;


    private void Start() {
        doorAnimator = GetComponent<Animator>();
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
        Invoke("OpenLock", 2.0f); 
    }

    void OpenLock()
    {
        theLock.SetActive(false);
        doorAnimator.SetTrigger("Open");
    }
}
