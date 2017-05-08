using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public GameObject[] stats = new GameObject[4];

    //display stat values for this player
    public void setStat(string statType, int statValue)
    {
        stats[statToNum(statType)].GetComponentInChildren<Text>().text = statValue.ToString();
    }

    //removes unneeded graphics
    public void setActive(bool active)
    {
        gameObject.SetActive(false);
    }

    //change color of stat if the player has highscore for that stat
    public void setTopStat(string statType)
    {
        stats[statToNum(statType)].GetComponentInChildren<Image>().color = new Color(212, 175, 55);
    }

    //change string stat input to int input
    public int statToNum(string stat)
    {
        int statNum = 0;

        switch (stat)
        {
            case "MDG":
                statNum = 0;
                break;
            case "MC":
                statNum = 1;
                break;
            case "MTIF":
                statNum = 2;
                break;
            case "MDT":
                statNum = 3;
                break;
            default:
                Debug.Log("Bad stat input");
                break;
        }

        return statNum;
    }
}
