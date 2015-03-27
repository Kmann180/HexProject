using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
public class Toggle_Map : MonoBehaviour {

	public GameObject MapCamera;
	public bool Active;

    //Fog of war
    public List<GameObject> FogGameObjects;
    FogofWar[] FogPlanes;

    int count;

    public Phases stages;

    
    
    
    void Awake()
    {
        count = 0;
        FogPlanes = new FogofWar[FogGameObjects.Count];
        while (count < FogGameObjects.Count)
        {
            FogPlanes[count] = new FogofWar(FogGameObjects[count]);
            count++;
        }

    }
	// Use this for initialization
	void Start () {
		Active = false;
		ShowMap ();

        stages = new Phases();
        
	
	}
	void ShowMap()
	{
        if (MapCamera.GetComponent<Mapscript>().Captured == false)
        {
            foreach (FogofWar fogs in FogPlanes)
                fogs.ClearFog(transform);

            if (Active == false)
                MapCamera.transform.gameObject.SetActive(false);
            else if (Active == true)
                MapCamera.transform.gameObject.SetActive(true);
        }
        else
        {
           
            if (Active == false)
                MapCamera.GetComponent<Camera>().enabled = false;
            else if (Active == true)
                MapCamera.GetComponent<Camera>().enabled = true;
        }
            
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.M))
			Active = !Active;

		ShowMap();

	}
}

class FogofWar
{
    public GameObject FogofWarPlane;

    Vector3[] vertices;
    Color[] changeAlpha;
    int count = 0;
    public FogofWar(GameObject FogTile)
    {
        int i = 0;
        FogofWarPlane = FogTile;

       
       Mesh GetFogMesh = FogofWarPlane.GetComponent<MeshFilter>().mesh;
       vertices = GetFogMesh.vertices;
       changeAlpha = new Color[vertices.Length];
       

       while (i < vertices.Length)
       {
           changeAlpha[i] = new Color(1, 1, 1, 1);
           i++;
       }
    }

    public void ClearFog(Transform PlayersTransform)
    {
        while (count < vertices.Length)
       {
           Vector3 VerticesWorldSpace = FogofWarPlane.transform.TransformPoint(vertices[count].x, vertices[count].y, vertices[count].z);
           float Distance = Vector3.Distance(PlayersTransform.position, VerticesWorldSpace);
           if (Distance < 3.0f && changeAlpha[count].a > 0)
           {
               changeAlpha[count] = new Color(changeAlpha[count].r, changeAlpha[count].g, changeAlpha[count].b, (changeAlpha[count].a - ( .25f * Time.deltaTime)));
           }
           count++;
       }
       count = 0;
           FogofWarPlane.GetComponent<MeshFilter>().mesh.colors = changeAlpha;
    }

}

public enum PHASE : int
{
    CASING = 0,
    PLANNING = 1,
    HEIST = 3,
};

public class Phases
{

    public int CurrentPhase;
    /* enum PHASE : int
    { 
        CASING = 0,
        PLANNING = 1,
        HEIST = 3,
    };*/
    public Phases()
    {
        // have the initail phase be casing before anythin else;
        CurrentPhase = (int)PHASE.CASING;

    }

    public bool ComparePhase(int wantphase, PHASE comparephase)
    {
        if (wantphase == (int)comparephase)
            return true;
        else
            return false;

    }

    public bool ComparePhase(int wantphase, int comparephase)
    {
        if (wantphase == comparephase)
            return true;
        else
            return false;

    }
}
