using UnityEngine;
using System.Collections;
using UnityEditor;

public class HexStats : MonoBehaviour {

    public string Type;

	public float Tempx;
	float Tempy;
	public float Tempz;
	
	float Snapx;
	float Snapy;
	float Snapz;
	
	public float Posx;
	public float Posy;
	public float PosZ;

	void Start()
	{
		Tempx = transform.position.x;
		Tempy = transform.position.y;
		Tempz = transform.position.z;
		
		Snapx = EditorPrefs.GetFloat("MoveSnapX");
		Snapy = EditorPrefs.GetFloat("MoveSnapY");
		Snapz = EditorPrefs.GetFloat("MoveSnapZ") * 2;
		
		Posx = Tempx / Snapx;
		Posy = Tempy / Snapy;
		PosZ = (Tempz / Snapz) + (Posx * 1.5f)  ;
	}
  
}
