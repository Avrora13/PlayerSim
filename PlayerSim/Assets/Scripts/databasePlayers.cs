using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class databasePlayers : MonoBehaviour
{
    public List<Player> players;
    public Player currentPlayer;
    public List<Club> Spain;
    public List<Club> Russia;
    public List<Club> Germany;

    private void Start()
    {
        for(int i = 0; i < Spain.Count; i++)
        {
            Spain[i].wins = 0;
            Spain[i].lose = 0;
            Spain[i].draws = 0;
            Spain[i].gools = 0;
            Spain[i].positionSeason.Clear();
        }
    }
}
