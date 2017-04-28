using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ZodiacCharacter : MonoBehaviour {
	public abstract void TakeDamage(int damage);
    public int coins;
	public string controller;
}
