using UnityEngine;
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;

//tuple????

public class SaveMap : MonoBehaviour

{
	//public List<NewHex> HexList = new List<NewHex> ();
	public List<HexStats> HexList = new List<HexStats> ();
	public GameObject HexPrefab;

	void Start()
	{
		StartList (GameObject.FindGameObjectsWithTag("Land"));

	}
	
	void Update()
		
	{
		if (Input.GetKeyDown (KeyCode.L)) 
		{
			LoadXML ();
			Debug.Log ("Loaded!");
		}
		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			GenXML();
			Debug.Log("Saved!");
		}
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
		HexStats Hex = (Instantiate(HexPrefab, Vec3, Quaternion.identity) as GameObject).GetComponent<HexStats>();
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
			}
			if (HexList[i].PosXYZ == HalfDownPos)
			{
				HexList.RemoveAt(i);
			}
		}

	}
	public bool CheckListIn (Vector3 NewPos)
	{
		//hex that you are moving to
		Vector3 OneDownPos = NewPos - new Vector3 (0,1,0);
		Vector3 HalfDownPos = NewPos - new Vector3 (0,.5f,0); 							///Change///
		
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

	public bool CheckListBelow (Vector3 NewPos)
	{
		//hex that you are moving to
		Vector3 OneDownPos = NewPos - new Vector3 (0,1,0);
		Vector3 HalfDownPos = NewPos - new Vector3 (0,1.5f,0); 							///Change///

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
			};
		}
		if (IsItTrue == true)
		{return true;}
		return false;
	}

	public bool CheckListAround (Vector3 NewPos)
	{
		//hexes that around the hex that you are moving to !!!ONLY FOR EDITOR!!!
		Vector3 OneDownPos1 = NewPos - new Vector3 (1,1,1);
		Vector3 HalfDownPos1 = NewPos - new Vector3 (1,.5f,1); 							///Change///
		Vector3 OneDownPos2 = NewPos - new Vector3 (1,1,0);
		Vector3 HalfDownPos2 = NewPos - new Vector3 (1,.5f,0); 							///Change///
		Vector3 OneDownPos3 = NewPos - new Vector3 (0,1,-1);
		Vector3 HalfDownPos3 = NewPos - new Vector3 (0,.5f,-1); 						///Change///
		Vector3 OneDownPos4 = NewPos - new Vector3 (-1,1,-1);
		Vector3 HalfDownPos4 = NewPos - new Vector3 (-1,.5f,-1); 						///Change///
		Vector3 OneDownPos5 = NewPos - new Vector3 (-1,1,0);
		Vector3 HalfDownPos5 = NewPos - new Vector3 (-1,.5f,0); 						///Change///
		Vector3 OneDownPos6 = NewPos - new Vector3 (0,1,1);
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

	/////////////////////The Start of XML//////////////////////////

	public XDocument AtlasXML;

	public void GenXML()
	{
		//Declaration
		XDeclaration XMLdec = new XDeclaration ("1.0", "UTF-8", "yes");
		XElement[] Xmlelem = new XElement[HexList.Count];

		for (int i = 0; i < HexList.Count; i++)
		{
			XElement node = new XElement("Hex_Node");

			node.SetAttributeValue("x", HexList[i].PosXYZ.x);
			node.SetAttributeValue("y", HexList[i].PosXYZ.y);
			node.SetAttributeValue("z", HexList[i].PosXYZ.z);
			node.SetAttributeValue("Type", HexList[i].WType);

			Xmlelem[i] = node;
		}

		XElement XMLRootNode = new XElement("HexAtlus", Xmlelem); //add root
		XMLRootNode.SetAttributeValue("imagePath","nothing");
		XDocument XMLdoc = new XDocument (XMLdec, XMLRootNode);
		AtlasXML = XMLdoc;

		
		AtlasXML.Save("Map1.xml");
	}

	public void LoadXML()
	{
		HexList.Clear();
		DestroyAllObjects();

		XmlDocument Doc = new XmlDocument ();
		Doc.Load("Map1.xml");
		XmlNodeList nodes = Doc.DocumentElement.SelectNodes("Hex_Node");
		foreach (XmlElement node in nodes) 
		{
			float x = Convert.ToSingle(node.GetAttribute("x"));
			float y = Convert.ToSingle(node.GetAttribute("y"));
			float z = Convert.ToSingle(node.GetAttribute("z"));
			string Type = node.GetAttribute("Type");

			AddToList(GridToWorld(new Vector3(x,y,z)), Type);
		}

	}

	public Vector3 GridToWorld(Vector3 GPos)
	{
		float PosX = GPos.x * 3;
		float PosY = GPos.y;
		float PosZ = (GPos.z * (1.73f * 2)) - (GPos.x * 1.73f);
		return new Vector3 (PosX, PosY, PosZ);
	}

	void DestroyAllObjects()
	{
		var gameObjects = GameObject.FindGameObjectsWithTag ("Land");
		
		for(var i = 0 ; i < gameObjects.Length ; i ++)
		{
			Destroy(gameObjects[i]);
		}
	}

}
