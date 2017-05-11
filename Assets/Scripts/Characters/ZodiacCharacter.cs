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


    public int coins;
	public abstract void CoinUpdate ();
    public Sprite profileImage;
}

