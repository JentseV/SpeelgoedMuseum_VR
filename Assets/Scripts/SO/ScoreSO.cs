using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/Score", order = 1)]
public class ScoreSO : ScriptableObject
{
    public int StandingPins;
    public bool Resetting;
}