using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Club")]

public class Club : ScriptableObject
{
    public string nameClub;
    public int wins;
    public int draws;
    public int lose;
    public int points
    {
        get { return (wins * 3 + draws); }
    }
    public int gools;
    public bool playedRound = false;
    public List<int> positionSeason;
}
