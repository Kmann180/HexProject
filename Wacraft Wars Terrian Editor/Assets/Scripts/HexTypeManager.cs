using UnityEngine;
using System.Collections;

public class HexTypeManager : MonoBehaviour 
{
	
	public GameObject Lava;
	public GameObject Water;
	public GameObject Grass;
	public GameObject Stone;	
	public GameObject Sand;
	public GameObject Leaf;
	public GameObject Wood;
	public GameObject Trunk;
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
			Debug.Log("Lava");
			return Lava;
		case "Water":
			Debug.Log("Water");
			return Water;
		case "Grass":
			Debug.Log("Grass");
			return Grass;
		case "Stone":
			Debug.Log("Stone");
			return Stone;
		case "Leaf":
			Debug.Log("Leaf");
			return Leaf;
		case "Sand":
			Debug.Log("Sand");
			return Sand;
		case "Trunk":
			Debug.Log("Trunk");
			return Trunk;
		case "Wood":
			Debug.Log("Wood");
			return Wood;
		default:
			return Lava;
		}
	}
}
