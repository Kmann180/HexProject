using UnityEngine;
using System.Collections;

public class CreateNewHex : MonoBehaviour 
{

	public SaveMap HexList;
	public HexStats HexMath;

	public GameObject Lava;

	Vector3 CPos;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CPos = this.transform.position;
		if (Input.GetKeyDown (KeyCode.Keypad1)) 
		{
			if (HexList.CheckListPlace(HexMath.WorldToGrid(CPos)) == false)
			{
				Instantiate(Lava, (CPos - new Vector3 (0,1,0)), new Quaternion(0,0,0,0));
				HexList.AddToList((CPos - new Vector3 (0,1,0)), "Lava");
				if (HexList.CheckListPlace(HexMath.WorldToGrid(CPos - new Vector3 (0,1,0))))
				{
					Debug.Log("Done");
				}
			}
		}
	}


}
