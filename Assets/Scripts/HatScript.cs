using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HatScript : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    [SerializeField] private Player player;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnSelectEntered);
        grabInteractable.selectExited.AddListener(OnSelectExited);

    }
    

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Object grabbed by " + args.interactableObject.transform.name);


    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        Debug.Log("Object released by " + args.interactableObject.transform.name);
    }

    private void OnTriggerEnter(Collider other) {
        var playerScore = player.GetComponent<Score>();

        switch(other.transform.tag){
            case "Border_Easy":{
                playerScore.AddScore();
                break;
            }
            case "Border_Medium":{
                playerScore.AddScore();
                break;
            }
            case "Border_Hard":{
                playerScore.AddScore();
                break;
            }
            case "Border_Expert":{
                playerScore.AddScore();
                break;
            }
        }
    }
}
