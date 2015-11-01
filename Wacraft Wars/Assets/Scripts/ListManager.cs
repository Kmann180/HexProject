using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class ListManager : MonoBehaviour 
{
	
	public HexTypeManager HexType;

	public List<HexStats> HexList = new List<HexStats> ();

	void Start() 
	{
		StartList (GameObject.FindGameObjectsWithTag ("Land"));
	}
	
	// Update is called once per fram
	void Update()
		
	{
		if (Input.GetKeyDown (KeyCode.P)) 
		{
			Debug.Log(HexList.Count);
		}
		
	}

	void StartList(GameObject[] Hex)
	{
		for (int i = 0; i < Hex.Length; i++) 
		{
			GameObject hex = Hex[i];
			HexStats GridHex = hex.GetComponent<HexStats>();
			
			HexList.Add(GridHex);
		}
	}

	public void AddToList(Vector3 Vec3, string Type)
	{
		HexStats Hex = (Instantiate(HexType.PickType(Type), Vec3, Quaternion.identity) as GameObject).GetComponent<HexStats>();
		Hex.PosX = Vec3.x;
		Hex.PosY = Vec3.y;
		Hex.PosZ = Vec3.z;
		Hex.PosXYZ = Vec3;
		Hex.WType = Type;
		
		HexList.Add (Hex);
	}

	public void RemoveFromList (Vector3 Pos)
	{
		Vector3 OneDownPos = Pos - new Vector3 (0,1,0);
		Vector3 HalfDownPos = Pos - new Vector3 (0,.5f,0);
		
		for (int i = 0; i < HexList.Count; i++)
		{
			if (HexList[i].PosXYZ == OneDownPos)
			{
				HexList.RemoveAt(i);
				Debug.Log("Pos To Be Checked");
				Debug.Log(OneDownPos);
			}
			if (HexList[i].PosXYZ == HalfDownPos)
			{
				HexList.RemoveAt(i);
				Debug.Log("Pos To Be Checked (.5)");
				Debug.Log(HalfDownPos);
			}
		}
		
	}
	public bool CheckListIn (Vector3 NewPos)
	{
		//hex that you are moving to
		Vector3 OneDownPos = NewPos;
		Vector3 HalfDownPos = NewPos - new Vector3 (0,.5f,0); 							///Change///
		
		bool IsItTrue = false;
		
		for (int i = 0; i < HexList.Count; i++) 
		{
			if (HexList [i].PosXYZ == OneDownPos) 
			{
				IsItTrue = true;
				Debug.Log("Tile Pos");
				Debug.Log(HexList[i].PosXYZ);
				Debug.Log("Pos To Be Checked");
				Debug.Log(OneDownPos);
			} 
			if (HexList [i].PosXYZ == HalfDownPos) 
			{
				IsItTrue = true;
				Debug.Log("Tile Pos (.5)");
				Debug.Log(HexList[i].PosXYZ);
				Debug.Log("Pos To Be Checked (.5)");
				Debug.Log(HalfDownPos);
			}
		}
		if (IsItTrue == true)
		{return true;}
		return false;
	}

	public bool CheckListBelow (Vector3 NewPos)
	{
		//hex that you are moving to
		Vector3 OneDownPos = NewPos - new Vector3 (0,1,0);
		Vector3 HalfDownPos = NewPos - new Vector3 (0,1.5f,0); 							///Change///
		
		bool IsItTrue = false;
		
		for (int i = 0; i < HexList.Count; i++) 
		{
			if (HexList[i].PosXYZ == OneDownPos) 
			{
				IsItTrue = true;
				break;
			} 
			if (HexList [i].PosXYZ == HalfDownPos) 
			{
				IsItTrue = true;
				break;
			};
		}
		if (IsItTrue == true)
		{return true;}
		return false;
	}

	public bool CheckListPlace (Vector3 PlacePos)
	{
		//hex that you are moving to
		Vector3 OneDownPos = PlacePos - new Vector3 (0,1,0);
		Vector3 HalfDownPos = PlacePos - new Vector3 (0,.5f,0);
		
		bool IsItTrue = false;
		for (int i = 0; i < HexList.Count; i++) 
		{
			if (HexList [i].PosXYZ == OneDownPos) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].PosXYZ == HalfDownPos) 
			{
				IsItTrue = true;
			} 
		}
		
		if (IsItTrue == true)
		{return true;}
		return false;
	}
}
