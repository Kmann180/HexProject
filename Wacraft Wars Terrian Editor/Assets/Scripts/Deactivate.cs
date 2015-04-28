using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deactivate : MonoBehaviour 
{

	GameObject[] SButtons;
	GameObject[] LButtons;

	// Use this for initialization
	void Start () 
	{
		SButtons = GameObject.FindGameObjectsWithTag("Save");
		foreach (GameObject Sbutton in SButtons) 
		{
			Sbutton.SetActive(false);
		}
		LButtons = GameObject.FindGameObjectsWithTag("Load");
		foreach (GameObject Lbutton in LButtons) 
		{
			Lbutton.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void ActivateSave()
	{
		SButtons = GameObject.FindGameObjectsWithTag("Save");
		foreach (GameObject Sbutton in SButtons) 
		{
			Sbutton.SetActive(true);
		}
	}
	void ActivateLoad()
	{
		LButtons = GameObject.FindGameObjectsWithTag("Load");
		foreach (GameObject Lbuttson in LButtons) 
		{
			Lbutton.SetActive(true);
		}
	}

}
