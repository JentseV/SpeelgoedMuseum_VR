using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private GameObject keyChest;
    void Start()
    {
        
    }

    void Update()
    {
        if(player.GetComponent<Score>().GetScore() > 5 && Vector2.Distance(player.GetComponent<Transform>().localPosition,keyChest.GetComponent<Transform>().localPosition) < 5f){
            //open chest
            UnlockChest();
        }
    }

    private void UnlockChest(){
        keyChest.GetComponent<Animation>();
    }
}
