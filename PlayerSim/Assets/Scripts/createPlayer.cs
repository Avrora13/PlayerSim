using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class createPlayer : MonoBehaviour
{
    public databasePlayers database;
    public List<TMP_InputField> inputField;
    public TMP_Dropdown dropdown;
    public List<TMP_Text> texts;
    public GameObject sim;
    public void Create()
    {
        Player player = ScriptableObject.CreateInstance<Player>();
        player.firstName = inputField[0].text;
        player.surName = inputField[1].text;
        player.country = dropdown.captionText.text;
        player.rating = Random.Range(60, 81);
        player.ageLast = Random.Range(32, 41);
        switch(player.country)
        {
            case "Spain":
                player.club = database.Spain[Random.Range(0, database.Spain.Count)];
                break;
        }
        player.contractYears = Random.Range(1, 6);
        AssetDatabase.CreateAsset(player, $"Assets/Players/Player[{database.players.Count}].asset");
        AssetDatabase.SaveAssets();
        database.players.Add(player);
        database.currentPlayer = player;
        texts[0].text = player.club.nameClub;
        texts[1].text = $"{player.rating}";
        texts[2].text = $"{player.firstName} {player.surName}";
        texts[3].text = $"{player.age} year";
        texts[4].text = $"{player.contractYears} years left on the contract.";
        sim.SetActive(true);
    }  
}
