using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCoins : MonoBehaviour
{ 
    [SerializeField] private Score playerScore;
    [SerializeField] private  TMP_Text textMeshPro;
    void Start()
    {
        if (textMeshPro != null)
        {
            string displayText = playerScore.GetScore().ToString();

            textMeshPro.text = displayText;
        }
    }
}
