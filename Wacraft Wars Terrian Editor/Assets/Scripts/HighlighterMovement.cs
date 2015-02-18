using UnityEngine;
using System.Collections;

public class HighlighterMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move()
	{
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			transform.Translate(new Vector3(-3,0,-1.73f), Space.Self);
		}
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			transform.Translate(new Vector3(-3,0,1.73f), Space.Self);
		}
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			transform.Translate(new Vector3(0,0,3.46f), Space.Self);
		}
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			transform.Translate(new Vector3(3,0,1.73f), Space.Self);
		}
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			transform.Translate(new Vector3(3,0,-1.73f), Space.Self);
		}
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			transform.Translate(new Vector3(0,0,-3.46f), Space.Self);
		}
		if (Input.GetKeyDown (KeyCode.R)) 
		{
			transform.Rotate(0,60,0, Space.Self);
		}
		if (Input.GetKeyDown (KeyCode.Tab)) 
		{
			transform.Rotate(0,-60,0, Space.Self);
		}


	}

}
