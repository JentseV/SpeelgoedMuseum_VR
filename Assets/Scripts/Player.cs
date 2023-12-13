using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Score score; 

    void Start()
    {
        this.score.Setscore(0);
    }

    void Update()
    {
        
    }

    
}
