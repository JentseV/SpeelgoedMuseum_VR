using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour 
{
    [SerializeField]
    private ScoreSO scoreSO;

    [SerializeField]
    private TMP_Text BowlingTextScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreSO.BowlingScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        BowlingTextScore.text = "Score: " + scoreSO.BowlingScore;
    }
}