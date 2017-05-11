using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ZodiacCharacter : MonoBehaviour {
	public abstract void TakeDamage(int damage);
	public string controller;
	public bool isStunned;
	public GameObject myHUD;
    public int coinLevel;
    public int coinTier1;
    public int coinTier2;
    public int coinTier3;
    public int coinTier4;
    public int coinTier5;
    public int coinMax;
	public bool isInvincible;
	public Sprite profileImage;
    public int coins;
	public void Update(){
		if(coins == coinTier1)
			coinLevel = 1;
		if (coins == coinTier2)
			coinLevel = 2;
		if (coins == coinTier3)
			coinLevel = 3;
		if (coins == coinTier4)
			coinLevel = 4;
		if (coins == coinTier5)
			coinLevel = 5;
		if (coins > coinMax)
			coinLevel = 6;

	}
    
}

