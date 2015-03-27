using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSelection : MonoBehaviour {

	public List<string> ToolList =  new List<string>();
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ButtonAddToList(string ToolName)
	{
		ToolList.Add (ToolName);
		Debug.Log (ToolName);
	}

}
