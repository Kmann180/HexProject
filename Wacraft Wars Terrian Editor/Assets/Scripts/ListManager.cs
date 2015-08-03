using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class ListManager : MonoBehaviour 
{
	
	bool IsItTrue;	
	public HexTypeManager HexType;

	public List<HexStats> HexList = new List<HexStats> ();

	// Use this for initialization
	void Start () 
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

	public void RemoveFromList (HexStats hs/*Vector3 Pos*/)
	{		
		HexList.Remove (hs);
		/*
		for (int i = 0; i < HexList.Count; i++)
		{
			if(Physics.CheckSphere(Pos,0.001f))
			{
				Debug.Log("checking if in list?");
				HexList.RemoveAt(i);
				Debug.Log("REMOVE FROM LIST: ");
				Debug.Log(Pos);

			}
/*			if (HexList[i].GetComponent<MeshCollider>().bounds.Contains(Pos))
			{
				Debug.Log("checking if in list?");
				HexList.RemoveAt(i);
				Debug.Log("REMOVE FROM LIST: ");
				Debug.Log(Pos);
			}*/
		//}
		
	}
	public bool CheckListIn (Vector3 NewPos)
	{
		//hex that you are moving to
		Vector3 OneDownPos = NewPos;
		Vector3 HalfDownPos = NewPos - new Vector3 (0,.5f,0); 							///Change///

		
		IsItTrue = false;
		
		for (int i = 0; i < HexList.Count; i++) 
		{
			if (HexList [i].PosXYZ == OneDownPos) 
			{
				IsItTrue = true;
				Debug.Log(HexList[i].PosXYZ);
				Debug.Log(OneDownPos);
			} 
			if (HexList [i].PosXYZ == HalfDownPos) 
			{
				IsItTrue = true;
				Debug.Log(HexList[i].PosXYZ);
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

	public bool CheckListAround (Vector3 NewPos)
	{
		//hexes that around the hex that you are moving to !!!ONLY FOR EDITOR!!!
		Vector3 OneDownPos1 = NewPos - new Vector3 (1,0,1);
		Vector3 HalfDownPos1 = NewPos - new Vector3 (1,.5f,1); 							///Change///
		Vector3 OneDownPos2 = NewPos - new Vector3 (1,0,0);
		Vector3 HalfDownPos2 = NewPos - new Vector3 (1,.5f,0); 							///Change///
		Vector3 OneDownPos3 = NewPos - new Vector3 (0,0,-1);
		Vector3 HalfDownPos3 = NewPos - new Vector3 (0,.5f,-1); 						///Change///
		Vector3 OneDownPos4 = NewPos - new Vector3 (-1,0,-1);
		Vector3 HalfDownPos4 = NewPos - new Vector3 (-1,.5f,-1); 						///Change///
		Vector3 OneDownPos5 = NewPos - new Vector3 (-1,0,0);
		Vector3 HalfDownPos5 = NewPos - new Vector3 (-1,.5f,0); 						///Change///
		Vector3 OneDownPos6 = NewPos - new Vector3 (0,0,1);
		Vector3 HalfDownPos6 = NewPos - new Vector3 (0,.5f,1); 							///Change///
		
		bool IsItTrue = false;
		
		for (int i = 0; i < HexList.Count; i++) 
		{
			/////////////////////////////////////// !!!FOR EDITOR ONLY!!!
			if (HexList [i].PosXYZ == OneDownPos1) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].PosXYZ == HalfDownPos1) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].PosXYZ == OneDownPos2) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].PosXYZ == HalfDownPos2) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].PosXYZ == OneDownPos3) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].PosXYZ == HalfDownPos3) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].PosXYZ == OneDownPos4) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].PosXYZ == HalfDownPos4) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].PosXYZ == OneDownPos5) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].PosXYZ == HalfDownPos5) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].PosXYZ == OneDownPos6) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].PosXYZ == HalfDownPos6) 
			{
				IsItTrue = true;
			} 
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
