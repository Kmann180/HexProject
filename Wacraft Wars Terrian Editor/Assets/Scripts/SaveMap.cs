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
	public List<NewHex> HexList = new List<NewHex> ();

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

			HexList.Add(new NewHex(GridHex.PosXYZ, GridHex.WType));
		}
	}

	void AddToList(Vector3 Pos, string Type)
	{
		HexList.Add (new NewHex (Pos, Type));
	}
	void RemoveFromList (Vector3 Pos)
	{
		Vector3 OneDownPos = Pos - new Vector3 (0,1,0);
		Vector3 HalfDownPos = Pos - new Vector3 (0,.5f,0);

		for (int i = 0; i < HexList.Count; i++) 
		{
			if (HexList[i].GridPos == OneDownPos)
			{
				HexList.RemoveAt(i);
			}
			if (HexList[i].GridPos == HalfDownPos)
			{
				HexList.RemoveAt(i);
			}
		}

	}

	bool CheckList (Vector3 Pos)
	{
		Vector3 OneDownPos = Pos - new Vector3 (0,1,0);
		Vector3 HalfDownPos = Pos - new Vector3 (0,.5f,0);
		bool IsItTrue = false;
		
		for (int i = 0; i < HexList.Count; i++) 
		{
			if (HexList [i].GridPos == OneDownPos) 
			{
				IsItTrue = true;
			} 
			if (HexList [i].GridPos == HalfDownPos) 
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

			node.SetAttributeValue("x", HexList[i].GridPos.x);
			node.SetAttributeValue("y", HexList[i].GridPos.y);
			node.SetAttributeValue("z", HexList[i].GridPos.z);
			node.SetAttributeValue("Type", HexList[i].GType);

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
		XmlDocument Doc = new XmlDocument ();
		Doc.Load("Map1.xml");
		XmlNodeList nodes = Doc.DocumentElement.SelectNodes("Hex_Node");
		foreach (XmlElement node in nodes) 
		{
			float x = Convert.ToSingle(node.GetAttribute("x"));
			float y = Convert.ToSingle(node.GetAttribute("y"));
			float z = Convert.ToSingle(node.GetAttribute("z"));
			string Type = node.GetAttribute("Type");

			AddToList(new Vector3(x,y,z), Type);
		}

	}

}
