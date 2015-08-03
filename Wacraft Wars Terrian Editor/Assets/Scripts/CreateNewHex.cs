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
		
		if (Input.GetKeyDown (KeyCode.Keypad3)) 
		{
			var stats = ((Instantiate(HexType.PickType("Grass"), CPos, new Quaternion(0,0,0,0))) as GameObject).GetComponent<HexStats>();
			HexList.HexList.Add(stats);
			transform.Translate(new Vector3(0,1,0), Space.Self);
		}
		
		if (Input.GetKeyDown (KeyCode.Keypad4)) 
		{
			var stats = ((Instantiate(HexType.PickType("Leaf"), CPos, new Quaternion(0,0,0,0))) as GameObject).GetComponent<HexStats>();
			HexList.HexList.Add(stats);
			transform.Translate(new Vector3(0,1,0), Space.Self);
		}
		
		if (Input.GetKeyDown (KeyCode.Keypad5)) 
		{
			var stats = ((Instantiate(HexType.PickType("Sand"), CPos, new Quaternion(0,0,0,0))) as GameObject).GetComponent<HexStats>();
			HexList.HexList.Add(stats);
			transform.Translate(new Vector3(0,1,0), Space.Self);
		}
		
		if (Input.GetKeyDown (KeyCode.Keypad6)) 
		{
			var stats = ((Instantiate(HexType.PickType("Stone"), CPos, new Quaternion(0,0,0,0))) as GameObject).GetComponent<HexStats>();
			HexList.HexList.Add(stats);
			transform.Translate(new Vector3(0,1,0), Space.Self);
		}
		
		if (Input.GetKeyDown (KeyCode.Keypad7)) 
		{
			var stats = ((Instantiate(HexType.PickType("Trunk"), CPos, new Quaternion(0,0,0,0))) as GameObject).GetComponent<HexStats>();
			HexList.HexList.Add(stats);
			transform.Translate(new Vector3(0,1,0), Space.Self);
		}
		
		if (Input.GetKeyDown (KeyCode.Keypad8)) 
		{
			var stats = ((Instantiate(HexType.PickType("Wood"), CPos, new Quaternion(0,0,0,0))) as GameObject).GetComponent<HexStats>();
			HexList.HexList.Add(stats);
			transform.Translate(new Vector3(0,1,0), Space.Self);
		}
		if (Input.GetKeyDown (KeyCode.Delete)) 
		{
			Debug.Log("Delete was hit");
			CPos = CPos - new Vector3 (0,-1,0);
			if (Physics.Raycast(CPos, new Vector3(0,-1,0), out hit))
			{
				HexList.RemoveFromList(hit.transform.gameObject.GetComponent<HexStats>());
				Destroy(hit.transform.gameObject);
				Debug.Log("Destroid");
			}

		}
	}
}
