using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HatScript : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public GameObject kidsThrowing;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnSelectEntered);
        grabInteractable.selectExited.AddListener(OnSelectExited);

    }
    

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Object grabbed by " + args.interactableObject.transform.name);
        kidsThrowing.SetActive(false);

    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        Debug.Log("Object released by " + args.interactableObject.transform.name);
    }

    
}
