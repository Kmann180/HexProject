using UnityEngine;
using System.Collections;

public class HighlighterMovement : MonoBehaviour {

	//Scripts
	public ListManager HexList;
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
		if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(0,0,0))))
		{
			transform.Translate(new Vector3(0,MoveCheckFloat(HexMath.WorldToGrid(CPos + new Vector3(0,0,0))),0), Space.Self);
		}
		Move ();
	}

	void Move()
	{
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(-3,0,-1.73f))))
			{
				transform.Translate(new Vector3(-3,MoveCheckFloat(HexMath.WorldToGrid(CPos + new Vector3(-3,0,-1.73f))),-1.73f), Space.Self);
			}
		}
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(-3,0,1.73f))))
			{
				transform.Translate(new Vector3(-3,MoveCheckFloat(HexMath.WorldToGrid(CPos + new Vector3(-3,0,1.73f))),1.73f) , Space.Self);
			}
		}
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(0,0,3.46f))))
			{
				transform.Translate(new Vector3(0,MoveCheckFloat(HexMath.WorldToGrid(CPos + new Vector3(0,0,3.46f))),3.46f), Space.Self);
			}
		}
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(3,0,1.73f))))
			{
				transform.Translate(new Vector3(3,MoveCheckFloat(HexMath.WorldToGrid(CPos + new Vector3(3,0,1.73f))),1.73f), Space.Self);
			}
		}
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(3,0,-1.73f))))
			{
				transform.Translate(new Vector3(3,MoveCheckFloat(HexMath.WorldToGrid(CPos + new Vector3(3,0,-1.73f))),-1.73f), Space.Self);
			}
		}
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			if (MoveCheckBool(HexMath.WorldToGrid(CPos + new Vector3(0,0,-3.46f))))
			{
				transform.Translate(new Vector3(0,MoveCheckFloat(HexMath.WorldToGrid(CPos + new Vector3(0,0,-3.46f))),-3.46f), Space.Self);
			}
		}
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (MoveCheckBool(HexMath.WorldToGrid(CPos)))
			{
				transform.Translate(new Vector3(0,MoveDown(HexMath.WorldToGrid(CPos)),0), Space.Self);
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

	float MoveDown(Vector3 NPos)
	{
		float i = NPos.y;
		while (HexList.CheckListIn (NPos)) 
		{
			NPos.y++;
		}
		while (!HexList.CheckListBelow(NPos)) 
		{
			NPos.y--;

			if (HexList.CheckListAround (NPos)) 
			{
				break;
			}
			if (NPos.y == 0) 
			{
				break;
			}
		}
		return NPos.y - i;
	}

	float MoveCheckFloat(Vector3 NPos)
	{
		float i = NPos.y;
		while (HexList.CheckListIn (NPos)) 
		{
			NPos.y++;
			Debug.Log("In Hex");
		}
		while (!HexList.CheckListBelow(NPos)) 
		{
			Debug.Log("Not Below Hex");
			if (HexList.CheckListAround (NPos)) 
			{
				break;
				Debug.Log("Around Hex");
			}
			if (NPos.y == 0) 
			{
				break;
			}
			NPos.y--;
		}
		return NPos.y - i;
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