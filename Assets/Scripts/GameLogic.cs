using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

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
        }

        if(player.GetComponent<Score>().GetScore() > 5 && Vector2.Distance(player.GetComponent<Transform>().localPosition,keyChest.GetComponent<Transform>().localPosition) < 5f){

            UnlockChest();
        }
    }

    private void UnlockChest(){
        keyChest.GetComponent<Animation>();
    }
}
