using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player")]

public class Player : ScriptableObject
{
    public string firstName;
    public string surName;
    public string country;
    public Club club;
    public int contractYears;
    public int age = 16;
    public int ageLast;
    public int rating;
    public List<string> infoSeason = new List<string>();
}
