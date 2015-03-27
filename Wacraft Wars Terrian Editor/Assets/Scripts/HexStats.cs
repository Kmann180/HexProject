using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

public class HexStats : MonoBehaviour {

    public string WType;

	// Grid Distanctes (snap settings)
	public float SnapX = 3;
	public float SnapY = .5f;
	public float SnapZ = 1.73f;

	//Grid Position
	public float PosX;
	public float PosY;
	public float PosZ;

	// Grid Vector3
	public Vector3 PosXYZ;

	void Start()
	{
		//Grid Maths
		PosX = transform.position.x / SnapX;
		PosY = transform.position.y;
		PosZ = Mathf.Round((transform.position.z + ((transform.position.x / SnapX) * (SnapZ))) / (SnapZ * 2));
		PosXYZ = new Vector3 (PosX, PosY, PosZ);
	}
	public Vector3 WorldToGrid(Vector3 WPos)
	{
		PosX = WPos.x / SnapX;
		PosY = WPos.y;
		PosZ = Mathf.Round((WPos.z + ((WPos.x / SnapX) * (SnapZ))) / (SnapZ * 2));
		return new Vector3 (PosX, PosY, PosZ);
	}
	public Vector3 GridToWorld(Vector3 GPos)
	{
		PosX = GPos.x * SnapX;
		PosY = GPos.y;
		PosZ = (GPos.z * (SnapZ * 2)) - (GPos.x * SnapZ);
		return new Vector3 (PosX, PosY, PosZ);
	}
  	
}

/*
public class NewHex
{
	public string GType;
	public Vector3 GridPos;
	public HexStats stats;

	public NewHex (Vector3 NewGridPos, string NewGType)
	{
		GType = NewGType;
		GridPos = NewGridPos;
	}
}
*/