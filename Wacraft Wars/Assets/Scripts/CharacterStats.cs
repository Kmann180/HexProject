using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour
{
    //IsAlive meaning can this character still operate.
    //When health = 0 then IsAlive = false.
    public bool IsAlive;
    //characters health is set in the Unity menu.
    //Character's health decreases when a successful hit is dealt.
    public int CharacterHealth;
    //Size is how large the character/item in question is, scale constist of 1-4.
    // 1 = small, 2 = medium, 3 = Large, 4 = Building
    public int Size;
    //The Distance the Character can move. If Building then not movable and distance equals 0.
    //The cahracter does not need to move the full amount at one time or for the entire around.
    public int MoveDis;
    //The Distance the Character can attack. If melee then 
    //The Distance is impacted by elevation and the calculations for that is down below.
    public int AttackDis;
    //the chance that the character is able to hit the opponent
    public int AttackNum;
    //the chance that the character is able to defend against the opponent
    public int DefenceNum;
    //Is able to fly
    //If able then when moving and attacking the character does NOT include elevation as a negative to distance
    public bool Flies;
    //
    //
    public bool Special;
    public char SName;
    public bool SReusable;
    public int SType;
    public int SAttackNum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
