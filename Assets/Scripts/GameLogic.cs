using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    public float collectedCoins = 0;
    [SerializeField] private Player player;
    [SerializeField] private GameObject keyChest;

    [SerializeField] private GameObject disableBeforeEntry;
    [SerializeField] private GameObject entrance;
    [SerializeField] private GameObject enableAfterEntry;

    [SerializeField] private GameObject blockLight;

    public bool entry = false;


    void Start()
    {
        
    }

    void Update()
    {
        if(!entry){
            disableBeforeEntry.SetActive(false);
        }else{
            disableBeforeEntry.SetActive(true);
            entrance.SetActive(false);
            blockLight.SetActive(false);
            enableAfterEntry.SetActive(true);
            RenderSettings.ambientIntensity = 0.68f;
        }

    }
}
