using UnityEngine;
using System.Collections;

public class HexTypeManager : MonoBehaviour 
{
	
	public GameObject Lava;
	public GameObject Water;
	//public GameObject Grass;
	//public GameObject Stone;
	//public GameObject Snow;
	//public GameObject Swamp;
	//public GameObject Brick;
	//public GameObject Mountian;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public GameObject PickType (string Type)
	{
		switch (Type) 
		{
		case "Lava":
			return Lava;
		case "Water":
			return Water;
		default:
			return Lava;
		}
	}
}
