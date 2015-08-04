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

		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			transform.RotateAround(HPos, Vector3.up, 60);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			transform.RotateAround(HPos, Vector3.down, 60);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			transform.RotateAround(HPos, Vector3.right, 10);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			transform.RotateAround(HPos, Vector3.left, 10);
		}
	}
}
