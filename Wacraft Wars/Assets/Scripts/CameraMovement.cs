using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public GameObject HighLHex;
	Vector3 HPos;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		HPos = HighLHex.transform.position;

		if (Input.GetKeyDown (KeyCode.R)) 
		{
			transform.RotateAround(HPos, Vector3.up, 60);
		}
		if (Input.GetKeyDown (KeyCode.Tab)) 
		{
			transform.RotateAround(HPos, Vector3.down, 60);
		}
	}
}
