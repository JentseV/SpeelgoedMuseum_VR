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

    public GameObject hobbyHorse;
    private Renderer hobbyHorseRenderer;
    Renderer cylinderRenderer;
    Rigidbody cylinderRigidbody;
    private void Start()
    {
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.volume = 1.0f;
        audioSource.clip = audioClip;
        audioSource.Play();
        gameLogicObject = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        spawnedHorse = false;
        horseSpawn = GameObject.FindWithTag("HobbyHorseSpawn").transform;
        hobbyHorse = GameObject.FindGameObjectWithTag("HobbyHorse");

        hobbyHorseRenderer = hobbyHorse.GetComponent<Renderer>();
        Transform cylinder = hobbyHorse.transform.Find("Cylinder");


         if (cylinder != null)
    {
        cylinderRenderer = cylinder.GetComponent<Renderer>();
        cylinderRigidbody = cylinder.GetComponent<Rigidbody>();

        if (cylinderRenderer != null)
        {
            cylinderRenderer.enabled = false;
        }

        if (cylinderRigidbody != null)
        {
            cylinderRigidbody.isKinematic = true; 
            cylinderRigidbody.detectCollisions = false; 
        }
    }
    }


    void spawnHorse()
    {

        if (cylinderRenderer != null)
        {
            cylinderRenderer.enabled = true;
        }

        if (cylinderRigidbody != null)
        {
            cylinderRigidbody.isKinematic = false; 
            cylinderRigidbody.detectCollisions = true; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Well Water" && spawnedHorse == false)
        {
            spawnHorse();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bowl")
        {
            gameLogicObject.collectedCoins += 1;
        }
    }


}
