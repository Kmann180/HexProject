using UnityEngine;
using System.Collections;
using UnityEditor;

public class HexStats : MonoBehaviour {

    public string Type;

	// Grid Distanctes (snap settings)
	float Snapx = 3;
	float Snapy = .5f;
	float Snapz = 1.73f;

	//Grid Position
	public float Posx;
	public float Posy;
	public float PosZ;

	// Grid Vector3
	public Vector3 PosXYZ;

	void Start()
	{
		//Grid Maths
		Posx = transform.position.x / Snapx;
		Posy = transform.position.y / Snapy;
		PosZ = Mathf.Round((transform.position.z + ((transform.position.x / Snapx) * (Snapz))) / (Snapz * 2));
		PosXYZ = new Vector3 (Posx, Posy, PosZ);
	}
  	
}
