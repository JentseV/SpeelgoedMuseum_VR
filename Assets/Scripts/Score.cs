using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;

    [SerializeField] private CoinScript coinScript;
    void Start()
    {
        this.score = 0;        
        InvokeRepeating("AddScore", 0f, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Setscore(int score){
        this.score = score;
    }
    public void AddScore(){
        this.score +=1;
        this.coinScript.PlayerScored();
    }

    public int GetScore(){
        return this.score;
    }

}
