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
			if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(-3,0,-1.73f))))
			{
				transform.Translate(new Vector3(-3,MoveCheckFloat(CPos + new Vector3(-3,0,-1.73f)),-1.73f), Space.Self);
			}
		}
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(-3,0,1.73f))))
			{
				transform.Translate(new Vector3(-3,MoveCheckFloat(CPos + new Vector3(-3,0,1.73f)),1.73f) , Space.Self);
			}
		}
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(0,0,3.46f))))
			{
				transform.Translate(new Vector3(0,MoveCheckFloat(CPos + new Vector3(0,0,3.46f)),3.46f), Space.Self);
			}
		}
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(3,0,1.73f))))
			{
				transform.Translate(new Vector3(3,MoveCheckFloat(CPos + new Vector3(3,0,1.73f)),1.73f), Space.Self);
			}
		}
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(3,0,-1.73f))))
			{
				transform.Translate(new Vector3(3,MoveCheckFloat(CPos + new Vector3(3,0,-1.73f)),-1.73f), Space.Self);
			}
		}
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(0,0,-3.46f))))
			{
				transform.Translate(new Vector3(0,MoveCheckFloat(CPos + new Vector3(0,0,-3.46f)),-3.46f), Space.Self);
			}
		}
		if (Input.GetKeyDown (KeyCode.R)) 
		{
				transform.Rotate(0,60,0, Space.Self);
		}
		if (Input.GetKeyDown (KeyCode.Tab)) 
		{
				transform.Rotate(0,-60,0, Space.Self);
		}


	}

	float MoveCheckFloat(Vector3 NPos)
	{
		Debug.Log ("Initially");
		Debug.Log (NPos);
		int i = 0;
		while (HexList.CheckListIn (NPos)) 
		{
			Debug.Log ("In Something");
			Debug.Log (NPos);
			NPos = NPos + new Vector3 (0,1,0);
			Debug.Log (NPos);
		}
		Debug.Log ("Not In Something");
		while (!HexList.CheckListBelow(NPos)) 
		{
			Debug.Log ("Nothing Below");
			if (HexList.CheckListAround (NPos)) 
			{
				Debug.Log ("Something Around");
				Debug.Log (NPos);
				break;
			}
			Debug.Log ("Nothing Around");
			if (NPos.y == 0) 
			{
				Debug.Log ("NPos.y == 0");
				Debug.Log (NPos);
				NPos = NPos + new Vector3 (0, i, 0);
				Debug.Log (NPos);
				break;
			}
			
			Debug.Log ("NPos.y != 0");
			Debug.Log (NPos);
			NPos = NPos + new Vector3 (0, -1, 0);
			i++;
			Debug.Log (NPos);
			Debug.Log (i);
		}
		Debug.Log ("Returning");
		Debug.Log (NPos);

		return NPos.y;
	}

	bool MoveCheckBool(Vector3 NPos)
	{
		int i = 0;
		while (HexList.CheckListIn (NPos)) 
		{
			return true;
		}
		
		while (!HexList.CheckListBelow(NPos)) 
		{
			
			if (HexList.CheckListAround (NPos)) 
			{
				return true;
			}
			
			if (NPos.y == 0) 
			{
				NPos = NPos + new Vector3 (0, i, 0);
				break;
			}
			
			NPos = NPos + new Vector3 (0, -1, 0);
			i++;
		}
		if (HexList.CheckListBelow (NPos)) 
		{
			return true;
		}
		
		return false;
	}

}
