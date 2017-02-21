using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player {

    public int score = 0;
    public static Player curr;
    public Character char1;
    public Character char2;
    public Character char3;
    public Character char4;

    public Player() {
        char1 = new Character();
        char2 = new Character();
        char3 = new Character();
        char4 = new Character();
    }
}
