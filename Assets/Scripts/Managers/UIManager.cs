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
    public Sprite tier6;
    public Sprite tier7;
    public Sprite tier8;
    public Sprite tier9;
    public Sprite tier10;

    //public GameManager gm;
    public GameObject character;
    Alexis alexis;
    Flub flub;

    void Start ()
    {
        Image image = GetComponent<Image>();
        if (image.sprite == null)
            image.sprite = tier0;

        switch (character.name)
        {
            case "Alexis":
                alexis = character.GetComponent<Alexis>();
                break;
            case "Flub":
                flub = character.GetComponent<Flub>();
                break;
            default:
                break;
        }
    }
	
	void Update ()
    {
        Image image = GetComponent<Image>();

        tier = 0;
        if (alexis != null)
            tier = alexis.coins;
        if (flub != null)
            tier = flub.coins;
 
        switch (tier)
        {
            case 0:
                image.sprite = tier0;
                break;
            case 1:
                image.sprite = tier1;
                break;
            case 2:
                image.sprite = tier2;
                break;
            case 3:
                image.sprite = tier3;
                break;
            case 4:
                image.sprite = tier4;
                break;
            case 5:
                image.sprite = tier5;
                break;
            case 6:
                image.sprite = tier6;
                break;
            case 7:
                image.sprite = tier7;
                break;
            case 8:
                image.sprite = tier8;
                break;
            case 9:
                image.sprite = tier9;
                break;
            case 10:
                image.sprite = tier10;
                break;
        }
	}
}
