using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    [SerializeField] private Player player;
    void Start()
    {
        
    }

    void Update()
    {
        if(player.GetComponent<Score>().GetScore() > 5){
            
        }
    }
}
