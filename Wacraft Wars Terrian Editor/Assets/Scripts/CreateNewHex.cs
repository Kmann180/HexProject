using UnityEngine;
using System.Collections;

public class CreateNewHex : MonoBehaviour 
{
	
	public ListManager HexList;
	public HexStats HexMath;
	public HexTypeManager HexType;

	Vector3 CPos;
	RaycastHit hit = new RaycastHit();
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CPos = this.transform.position;
		if (Input.GetKeyDown (KeyCode.Keypad1)) 
		{
			var stats = ((Instantiate(HexType.PickType("Lava"), CPos, new Quaternion(0,0,0,0))) as GameObject).GetComponent<HexStats>();
			HexList.HexList.Add(stats);
			transform.Translate(new Vector3(0,1,0), Space.Self);
		}

		if (Input.GetKeyDown (KeyCode.Keypad2)) 
		{
			var stats = ((Instantiate(HexType.PickType("Water"), CPos, new Quaternion(0,0,0,0))) as GameObject).GetComponent<HexStats>();
			HexList.HexList.Add(stats);
			transform.Translate(new Vector3(0,1,0), Space.Self);
		}
		if (Input.GetKeyDown (KeyCode.Delete)) 
		{
			Debug.Log("Delete was hit");
			CPos = CPos - new Vector3 (0,-1,0);
			if (Physics.Raycast(CPos, new Vector3(0,-1,0), out hit))
			{
				Debug.Log("Found object");
				Destroy(hit.transform.gameObject);
				Debug.Log("Destroid");
				HexList.RemoveFromList(CPos);
				Debug.Log("Removed from list");
			}

		}
	}
}
