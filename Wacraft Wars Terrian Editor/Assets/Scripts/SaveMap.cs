using UnityEngine;
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class SaveMap : MonoBehaviour

{
	public ListManager HexList;
	public HexTypeManager HexType;
	public GameObject Button;
	public InputField SaveAsText;

	void Start()
	{
		XMLTesting();
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
	}

		public System.Xml.Linq.XDocument AtlasXML;

	public void GenXML()
	{
		//Declaration
		XDeclaration XMLdec = new XDeclaration ("1.0", "UTF-8", "yes");
		XElement[] Xmlelem = new XElement[HexList.HexList.Count];

		for (int i = 0; i < HexList.HexList.Count; i++)
		{
			XElement node = new XElement("Hex_Node");

			node.SetAttributeValue("x", HexList.HexList[i].PosXYZ.x);
			node.SetAttributeValue("y", HexList.HexList[i].PosXYZ.y);
			node.SetAttributeValue("z", HexList.HexList[i].PosXYZ.z);
			node.SetAttributeValue("Type", HexList.HexList[i].WType);

			Xmlelem[i] = node;
		}


		XElement XMLRootNode = new XElement("HexAtlus", Xmlelem); //add root
		XMLRootNode.SetAttributeValue("imagePath","nothing");
		XDocument XMLdoc = new XDocument (XMLdec, XMLRootNode);
		AtlasXML = XMLdoc;

		if (SaveAsText.text != null) 
		{
			string eek = ".\\Maps\\" + SaveAsText.text + ".xml";
			AtlasXML.Save(eek);
			AtlasXML.Remove();
		}

		//AtlasXML.Save("Map1.xml");
	}

	public void LoadXML()
	{
		HexList.HexList.Clear();
		DestroyAllObjects();

		XmlDocument Doc = new XmlDocument ();
		Doc.Load(".\\Maps\\Map1.xml");
		XmlNodeList nodes = Doc.DocumentElement.SelectNodes("Hex_Node");
		foreach (XmlElement node in nodes) 
		{
			float x = Convert.ToSingle(node.GetAttribute("x"));
			float y = Convert.ToSingle(node.GetAttribute("y"));
			float z = Convert.ToSingle(node.GetAttribute("z"));
			string Type = node.GetAttribute("Type");

			HexList.AddToList(GridToWorld(new Vector3(x,y,z)), Type);
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
	//------------------------------------------------------------------------------------------

	private string		path;					// Holds the application path

	void XMLTesting()
	{
		print("file manager initialized.");
		
		path = Application.dataPath;
		
		print("Path: " + path);

		Debug.Log(checkDirectory("Shit"));
	}

	private bool checkDirectory(string directory)
	{
		if(Directory.Exists(path + "/" + directory))
		{
			return true;
		}
		else
		{
			return false;
		}	
	}
}
