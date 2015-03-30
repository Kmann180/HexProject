using UnityEngine;
using System.Collections;

public class HighlighterMovement : MonoBehaviour {

	//Scripts
	public SaveMap HexList;
	public HexStats HexMath;

	//Current Position of highlighter
	public Vector3 CPos;
	//New Position of highlighter
	//Vector3 NPos;
	//Position of the tile under the highlighter
	Vector3 LPos;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		CPos = this.transform.position;
		Move ();
	}

	void Move()
	{
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			if (HexList.CheckListAround(HexMath.WorldToGrid(CPos + new Vector3(-3,0,-1.73f))))
			{
			transform.Translate(new Vector3(-3,0,-1.73f), Space.World);
			}
		}
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			if (HexList.CheckListAround(HexMath.WorldToGrid(CPos + new Vector3(-3,0,1.73f))))
			{
			transform.Translate(new Vector3(-3,0,1.73f), Space.World);
			}
		}
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			if (HexList.CheckListAround(HexMath.WorldToGrid(CPos + new Vector3(0,0,3.46f))))
			{
				transform.Translate(new Vector3(0,0,3.46f), Space.World);
			}
		}
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			if (HexList.CheckListAround(HexMath.WorldToGrid(CPos + new Vector3(3,0,1.73f))))
			{
				transform.Translate(new Vector3(3,0,1.73f), Space.World);
			}
		}
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			if (HexList.CheckListAround(HexMath.WorldToGrid(CPos + new Vector3(3,0,-1.73f))))
			{
				transform.Translate(new Vector3(3,0,-1.73f), Space.World);
			}
		}
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			if (HexList.CheckListAround(HexMath.WorldToGrid(CPos + new Vector3(0,0,-3.46f))))
			{
				transform.Translate(new Vector3(0,0,-3.46f), Space.World);
			}
		}
		if (Input.GetKeyDown (KeyCode.R)) 
		{
				transform.Rotate(0,60,0, Space.World);
		}
		if (Input.GetKeyDown (KeyCode.Tab)) 
		{
				transform.Rotate(0,-60,0, Space.World);
		}


	}

	int MoveCheck(Vector3 NPos)
	{
		if (HexList.CheckListAround (NPos)) 
		{
			return 1;
		}
		if (HexList.CheckListBelow (NPos)) 
		{
			return 1;
		}
		if (HexList.CheckListIn (NPos)) 
		{
			return 2;
		}

		return 0;
	}

}
