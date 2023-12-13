using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour 
{
    [SerializeField]
    private ScoreSO scoreSO;

    [SerializeField]
    private TMP_Text BowlingTextScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreSO.BowlingScore = new List<int>();
        scoreSO.StandingPins = 0;
        scoreSO.BallThrows = 0;
        scoreSO.Resetting = true;
    }

    // Update is called once per frame
    void Update()
    {
        BowlingTextScore.text = "Score: " + string.Join(", ", scoreSO.BowlingScore);

        if(!scoreSO.Resetting)
        {
            if(scoreSO.StandingPins == 0 || scoreSO.BallThrows == 2)
            {
                scoreSO.Resetting = true;
                scoreSO.BowlingScore.Add(9 - scoreSO.StandingPins);
                scoreSO.StandingPins = 0;
                scoreSO.BallThrows = 0;
                Debug.Log("round ended");
            }
        }
        else
        {
            if(scoreSO.StandingPins == 9)
            {
                scoreSO.Resetting = false;
                Debug.Log("new round started");
            }
        }
    }
}