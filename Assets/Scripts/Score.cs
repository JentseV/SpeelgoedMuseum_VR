using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;
    void Start()
    {
        this.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Setscore(int score){
        this.score = score;
    }
    public void AddScore(int score){
        this.score += score;
    }

    public int GetScore(){
        return this.score;
    }

}
