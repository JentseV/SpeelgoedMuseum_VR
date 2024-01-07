using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip walkingSound; 
    public float walkingSpeedThreshold = 0.1f; 

    private AudioSource audioSource;
    [SerializeField] private Score score; 

    [SerializeField] private GameLogic gameLogic;


    void Start()
    {
        this.score.Setscore(0);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Painting"){
            gameLogic.entry = true;
            Debug.Log("Entered painting");
        }
    }
}
