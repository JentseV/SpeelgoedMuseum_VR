using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/Score", order = 1)]
public class ScoreSO : ScriptableObject
{
    public List<int> BowlingScore;
    public int StandingPins;
    public int BallThrows;
    public bool Resetting;
}