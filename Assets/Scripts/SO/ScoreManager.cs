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
    
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        scoreSO.StandingPins = 0;
        scoreSO.Resetting = true;
    }

    // Update is called once per frame
    void Update()
    {
        BowlingTextScore.text = "Score: " + (9 - scoreSO.StandingPins);

        if(scoreSO.StandingPins == 0)
        {
            scoreSO.Resetting = true;
            scoreSO.StandingPins = 0;
            var playerScore = player.GetComponent<Score>();
            playerScore.AddScore();
            Debug.Log("round ended");
        }
    }
}