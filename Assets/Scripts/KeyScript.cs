using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyScript : MonoBehaviour
{
    public bool keyPickedUp = false;

    public GameLogic gameLogic;
    void Start()
    {
        this.GetComponent<XRGrabInteractable>().enabled = false;
    }

    void Update()
    {
        if(gameLogic.collectedCoins > 4 ){
            this.GetComponent<XRGrabInteractable>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "PlayerHand" && !keyPickedUp && this.GetComponent<XRGrabInteractable>().enabled){
            keyPickedUp = true;
        }
    }
    
}
