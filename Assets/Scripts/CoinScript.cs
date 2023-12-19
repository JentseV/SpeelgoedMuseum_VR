using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    [SerializeField] private Transform horseSpawn;

    [SerializeField] private GameObject horseToy;

    private bool spawnedHorse;

  

    private void Start() {
        spawnedHorse = false;
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


}
