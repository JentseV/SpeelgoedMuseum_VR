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
        if(player.GetComponent<Score>().GetScore() > 5 && player.GetComponent<Transform>().position){
            
        }
    }

    private void UnlockChest(){
        keyChest.GetComponent<Animation>();
    }
}
