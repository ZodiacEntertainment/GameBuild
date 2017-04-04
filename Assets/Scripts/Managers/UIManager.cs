using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
    public int tier;
    public Sprite tier0;
    public Sprite tier1;
    public Sprite tier2;
    public Sprite tier3;
    public Sprite tier4;
    public Sprite tier5;

    //public GameManager gm;
    public GameObject character;
    ZodiacCharacter charScript;

    void Start ()
    {
        Image image = GetComponent<Image>();
        if (image.sprite == null)
            image.sprite = tier0;

        charScript = character.GetComponent<ZodiacCharacter>();
    }
	
	void Update ()
    {
        Image image = GetComponent<Image>();

        tier = 0;
        tier = charScript.coins;
        /*if (flub != null)
            tier = flub.coins;
            */
 
        switch (tier)
        {
            case 0:
            case 1:
            case 2:
                image.sprite = tier0;
                break;
            case 3:
            case 4:
            case 5:
                image.sprite = tier1;
                break;
            case 6:
            case 7:
            case 8:
                image.sprite = tier2;
                break;
            case 9:
            case 10:
            case 11:
                image.sprite = tier3;
                break;
            case 12:
            case 13:
            case 14:
                image.sprite = tier4;
                break;
            case 15:
                image.sprite = tier5;
                break;
            default:
                break;
        }
	}
}
