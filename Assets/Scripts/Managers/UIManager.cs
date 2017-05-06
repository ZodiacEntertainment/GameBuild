using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    // HUD sprites
    public int tier;
    public Sprite tier0;
    public Sprite tier1;
    public Sprite tier2;
    public Sprite tier3;
    public Sprite tier4;
    public Sprite tier5;



    // Pickup sprites
    public Sprite speedBoost;
	public Sprite defaultSprite;
    // Game Manager reference
    public GameManager manager;
    // Character reference
    public GameObject character;
    // Script reference
    ZodiacCharacter charScript;
    // Image reference for tier
    public Image image;
    // Inventory reference
    public GameObject inventory;

	public int coinMax;
	public bool init = false;
    
    void Start ()
    { 
        
        // Set the HUD to the default sprite
        image = GetComponent<Image>();
        if (image.sprite == null)
            image.sprite = tier0;
    }
	
	void Update (){
		if (init) {
			tier = charScript.coinLevel;
			Image image = GetComponent<Image> ();

			Debug.Log (tier);
			switch (tier) {
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
			}
		}
	}

    // Display the Item picked up in HUD
    public void ItemDisplay(string _image)
    {
        Debug.Log("Displaying the Item!");
        Image itemSprite = inventory.GetComponent<Image>();
        // Add image name cases based on sprite name.
        switch (_image){
            case "powerup":
			itemSprite.sprite = speedBoost;
                break;
		case "Default":
			itemSprite.sprite = defaultSprite;
			break;
		default:
			Debug.Log (_image);
                break;
        }
        //item = renameThis;
    }
	public void Init(GameObject me){
		init = true;
		charScript = me.GetComponent<ZodiacCharacter> ();
	}
}