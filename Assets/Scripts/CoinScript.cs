using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public AudioClip audioClip;
    private Transform horseSpawn;
    [SerializeField] private GameLogic gameLogicObject;
    [SerializeField] private GameObject horseToy;
    private bool spawnedHorse;

  

    private void Start() {
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.volume = 1.0f;
        audioSource.clip = audioClip;
        audioSource.Play();
        gameLogicObject = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        spawnedHorse = false;
        horseSpawn = GameObject.FindWithTag("HobbyHorseSpawn").transform;
    }


    void spawnHorse(){
        spawnedHorse = true;

        Instantiate(horseToy,horseSpawn.position,Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Well Water" && spawnedHorse == false){
            spawnHorse();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Bowl"){
            gameLogicObject.collectedCoins+=1;
        }
    }


}
