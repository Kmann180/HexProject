using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponChange : MonoBehaviour {

	public GameObject BlondePrefab;
	public GameObject BluePrefab;
	public GameObject PinkPrefab;
	public GameObject WhitePrefab;
	public GameObject Menu;

	GameObject[] Weapons;
	[SerializeField] WeaponSelection WeaponSelection;
	bool WeaponSelectionEnabled = false;

	public GameObject SlotOne;
	public GameObject SlotTwo;
	public GameObject SlotThree;
	public GameObject SlotFour;

	bool WeaponSpawner = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		SelectWeapon();
	}

	void SelectWeapon()
	{
		if (WeaponSelectionEnabled == true) {
			if (WeaponSpawner == false) {
				SlotOne = Instantiate (SwitchSearch (WeaponSelection.ToolList [0]), new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				SlotTwo = Instantiate (SwitchSearch (WeaponSelection.ToolList [1]), new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				SlotThree = Instantiate (SwitchSearch (WeaponSelection.ToolList [2]), new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				SlotFour = Instantiate (SwitchSearch (WeaponSelection.ToolList [3]), new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;

				SlotOne.transform.SetParent(this.gameObject.transform);
				SlotTwo.transform.SetParent(this.gameObject.transform);
				SlotThree.transform.SetParent(this.gameObject.transform);
				SlotFour.transform.SetParent(this.gameObject.transform);

				DeactiveAll();

				WeaponSpawner = true;
			}

			if (WeaponSpawner == true) {
				if (Input.GetButtonDown ("Primary")) {
					DeactiveAll();
					SlotOne.SetActive (true);
				}

				if (Input.GetButtonDown ("Secondary")) {
					DeactiveAll();
					SlotTwo.SetActive (true);
				}

				if (Input.GetButtonDown ("ToolOne")) {
					DeactiveAll();
					SlotThree.SetActive (true);
				}

				if (Input.GetButtonDown ("ToolTwo")) {
					DeactiveAll();
					SlotFour.SetActive (true);
				}
			}
		}
	}

	public void EnableSelection(bool i)
	{
		WeaponSelectionEnabled = i;
		Menu.SetActive (false);
		//Debug.Log ("Selection enabled " + WeaponSelectionEnabled);
	}

	GameObject SwitchSearch(string Tool)
	{
		switch (Tool) 
		{
		case "Blue":
			return BluePrefab;
			//Debug.Log("Blue");
		case "Blonde":
			return BlondePrefab;
			//Debug.Log ("Blue");
		case "Pink":
			return PinkPrefab;
			//Debug.Log (Tool);
		case "White":
			return WhitePrefab;
			//Debug.Log (Tool);
		default:
			//Debug.Log ("None");
			return null;
		}

	}

	void DeactiveAll()
	{
		SlotOne.SetActive (false);
		SlotTwo.SetActive (false);
		SlotThree.SetActive (false);
		SlotFour.SetActive (false);
	}
}
