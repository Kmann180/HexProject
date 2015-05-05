using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deactivate : MonoBehaviour 
{
	GameObject[] SButtons;
	GameObject[] LButtons;
	GameObject[] DButtons;

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
		DButtons = GameObject.FindGameObjectsWithTag("Delete");
		foreach (GameObject Dbutton in DButtons) 
		{
			Dbutton.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ActivateSave()
	{
		foreach (GameObject Sbutton in SButtons) 
		{
			Sbutton.SetActive(!Sbutton.activeSelf);
			Sbutton.GetComponentInChildren
		}
	}
	public void ActivateLoad()
	{
		foreach (GameObject Lbutton in LButtons) 
		{
			Lbutton.SetActive(!Lbutton.activeSelf);
		}
	}
	public void DeactivateSave()
	{
		foreach (GameObject Sbutton in SButtons) 
		{
			Sbutton.SetActive(false);
		}
	}
	public void DeactivateLoad()
	{
		foreach (GameObject Lbutton in LButtons) 
		{
			Lbutton.SetActive(false);
		}
	}
	public void ActivateDelete()
	{
		foreach (GameObject Dbutton in DButtons) 
		{
			Dbutton.SetActive(!Dbutton.activeSelf);
		}
	}
	public void DeactivateDelete()
	{
		foreach (GameObject Dbutton in DButtons) 
		{
			Dbutton.SetActive(false);
		}
	}

}
