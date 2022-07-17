using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Simulation : MonoBehaviour
{
    public int round = 1;
    public databasePlayers data;
    public List<TMP_Text> teams;
    public List<TMP_Text> texts;
    private List<Club> clubs;
    private int g1;
    private int g2;
    private bool team1 = false;
    private bool team2 = false;
    public GameObject buttom2;
    public GameObject buttom;
    public GameObject panelEndCareer;
    public GameObject copyText;
    public GameObject copyPanel;
    public string info;

    private void Start()
    {
        clubs = data.Spain;
    }
    public void SimulationSeason()
    {
        StartCoroutine(Coroutine());
        while (round != 39)
        {
            for (int i = 0; i < 10; i++)
            {
                while (team1 == false || team2 == false)
                {
                    g1 = Random.Range(0, data.Spain.Count);
                    g2 = Random.Range(0, data.Spain.Count);
                    if (data.Spain[g1].playedRound == false && data.Spain[g2].playedRound == false && g1 != g2)
                    {
                        break;
                    }
                }
                int gool1 = Random.Range(0, 6);
                int gool2 = Random.Range(0, 6);
                if (gool1 > gool2)
                {
                    data.Spain[g1].wins += 1;
                    data.Spain[g1].gools += gool1 - gool2;
                    data.Spain[g2].lose += 1;
                    data.Spain[g2].gools += gool2 - gool1;
                }
                else if (gool1 == gool2)
                {
                    data.Spain[g1].draws += 1;
                    data.Spain[g2].draws += 1;
                }
                else
                {
                    data.Spain[g1].lose += 1;
                    data.Spain[g1].gools += gool1 - gool2;
                    data.Spain[g2].wins += 1;
                    data.Spain[g2].gools += gool2 - gool1;
                }
                data.Spain[g1].playedRound = true;
                data.Spain[g2].playedRound = true;
            }
            round++;
            clubs = clubs.OrderBy(g => g.points).ToList();
            for (int i = 0; i < data.Spain.Count; i++)
            {
                teams[i].text = $"{clubs[19 - i].nameClub}  {clubs[19 - i].wins}   {clubs[19 - i].draws}   {clubs[19 - i].lose}  {clubs[19 - i].gools}   {clubs[19 - i].points}";
                data.Spain[i].playedRound = false;
            }
        }
        buttom.SetActive(true);
        buttom2.SetActive(false);
        for (int i = 0; i < data.Spain.Count; i++)
        {
             clubs[i].positionSeason.Add(20 - i);
        }
    }

    public void NewSeason()
    {
        info = $"Rating: {data.currentPlayer.rating},  Club: {data.currentPlayer.club.nameClub},  Position on league: {data.currentPlayer.club.positionSeason[data.currentPlayer.club.positionSeason.Count - 1]}";
        data.currentPlayer.infoSeason.Add(info);
        if (data.currentPlayer.age < data.currentPlayer.ageLast)
        {
            data.currentPlayer.age += 1;
            data.currentPlayer.rating += Random.Range(-5, 6);
            if (data.currentPlayer.contractYears > 1)
            {
                data.currentPlayer.contractYears -= 1;
            }
            else
            {
                data.currentPlayer.club = data.Spain[Random.Range(0, data.Spain.Count)];
                data.currentPlayer.contractYears = Random.Range(1, 6);
            }
            texts[0].text = data.currentPlayer.club.nameClub;
            texts[1].text = $"{data.currentPlayer.rating}";
            texts[2].text = $"{data.currentPlayer.firstName} {data.currentPlayer.surName}";
            texts[3].text = $"{data.currentPlayer.age} year";
            texts[4].text = $"{data.currentPlayer.contractYears} years left on the contract.";
            texts[5].text = $"{data.currentPlayer.club.positionSeason[data.currentPlayer.club.positionSeason.Count - 1]} last position in season.";
            for (int i = 0; i < data.Spain.Count; i++)
            {
                data.Spain[i].wins = 0;
                data.Spain[i].lose = 0;
                data.Spain[i].draws = 0;
                data.Spain[i].gools = 0;
            }
            round = 1;
            buttom.SetActive(false);
            buttom2.SetActive(true);
        }
        else
        {
            panelEndCareer.SetActive(true);
            for (int i = 0; i < data.currentPlayer.infoSeason.Count; i++)
            {
                GameObject text = Instantiate(copyText,new Vector3(0,0,0) ,Quaternion.identity) as GameObject;
                text.transform.SetParent(copyPanel.transform,false);
                text.GetComponent<TMP_Text>().text = data.currentPlayer.infoSeason[i];
                text.SetActive(true);
            }
        }
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(5);
    }
}
