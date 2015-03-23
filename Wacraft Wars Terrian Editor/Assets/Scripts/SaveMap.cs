using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System;

//tuple????

public class SaveMap : MonoBehaviour

{
//	Tuple.Create<Vector3,string> HexTuple = new Tuple.Create<Vector3, string>();
//	public List<Tuple> Hex_vects = new List<HexTuple>();
	
	
	void Update()
		
	{
		if (Input.GetKeyDown (KeyCode.L)) 
		{
			XMLtoList();
		}


		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			GenXML (GameObject.FindGameObjectsWithTag ("Land"));
		}
	}
	
	
	
	public XDocument AtlasXML;
	
	
	
	public void GenXML(GameObject[] hex)
		
	{
		
		// Declaration
		
		XDeclaration XMLdec = new XDeclaration("1.0", "UTF-8", "yes");
		
		
		
		XElement[] XMLelem = new XElement[hex.Length];
		
		
		
		for (int i = 0; i < hex.Length; i++)
		{
			
			XElement node = new XElement("hex_node");
			
			
			GameObject eek = hex[i];   // cache
			
			HexStats gridHex = eek.GetComponent<HexStats>();
			
			
			node.SetAttributeValue("x", gridHex.PosXYZ.x);
			node.SetAttributeValue("y", gridHex.PosXYZ.y);
			node.SetAttributeValue("z", gridHex.PosXYZ.z);
			node.SetAttributeValue("Type", gridHex.Type);
			
			XMLelem[i] = node;
			
		}
		
		
		
		XElement XMLRootNode = new XElement("HexAtlus", XMLelem);   // add root
		
		XMLRootNode.SetAttributeValue("imagePath", "nothing");
		
		
		XDocument XMLdoc = new XDocument(XMLdec, XMLRootNode);
		
		
		AtlasXML = XMLdoc;
		
		//FileStream
		//xmlstream = new FileStream("H:\\Wacraft's Time Battles\\hexSheet.xml", FileMode.Create);
		
		AtlasXML.Save("Map1.xml");
		
		
	}
	
	////////////////////////////////////////////////////////////////////////////////////////
	
	
	
	public void XMLtoList()
		
	{
		
		XmlDocument doc = new XmlDocument();
		
		
		doc.Load("Map1.xml");
		
		
		XmlNodeList nodes = doc.DocumentElement.SelectNodes("hex_node");
		
		
		
		foreach (XmlElement node in nodes)
			
		{
			
			
			float x = Convert.ToSingle(node.GetAttribute("x"));
			
			float y = Convert.ToSingle(node.GetAttribute("y"));
			
			float z = Convert.ToSingle(node.GetAttribute("z"));

			string type = node.GetAttribute("Type");


			///////////////TUPLE!!!/////////////////////
//			Hex_vects.Add (HexTuple(new Vector3(x, y, z), type()));
			
		}
		
	}
	
	
	
	public bool CheckGrid(Vector3 PosC)
		
	{
		
		bool HexThere = false;
		
		
/*		if (Hex_vects.Contains(PosC))
			
		{
			
			HexThere = true;
		} */
			return true;

	}
}
