using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mapscript : MonoBehaviour {

	


    //used for switch Blueprint view
    public List<GameObject> Blueprint;
    int CurrentCameraLook;

    // Take Screenshot varibles
    Texture2D image;

    bool Grab = false;
    public bool Captured = false;

    public GameObject Player;
    //byte[] pngShot;
    List<byte[]> pngShot;

    public GameObject FogofWar;
    public GameObject turnoffCanvas;

    int loadNumber;

    public LineRenderer lineRender;
    private int numberOfPoints = 0;
    Camera MapCamera;

    List<LineRenderer> Lines;

    public Toggle_Map playerscript;

    Phases playerstage;

     
	void Start () {
        CurrentCameraLook = 0;


        image = new Texture2D(Screen.width, Screen.height);
        pngShot = new List<byte[]>();
        loadNumber = 0;

        Lines = new List<LineRenderer>();

        MapCamera = transform.GetComponent<Camera>();

        playerstage = playerscript.stages;


	}

    void SwitchBlueprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.UpArrow) && CurrentCameraLook < Blueprint.Count - 1)
        {
            CurrentCameraLook++;
            transform.position = new Vector3(transform.position.x, transform.position.y + 6.0f, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.DownArrow) && CurrentCameraLook != 0)
        {
            CurrentCameraLook--;
            transform.position = new Vector3(transform.position.x, transform.position.y - 6.0f, transform.position.z);
        }
        
    }

    void PostScreen()
    {
        if (Input.GetKeyDown(KeyCode.O) && Grab == false){
			Grab = true;
			CurrentCameraLook = Blueprint.Count - 1 ;
			GetComponent<Camera>().rect = new Rect(0,0,1,1);
            turnoffCanvas.SetActive(false);
		}

		if (Grab == true && Captured == false && loadNumber < Blueprint.Capacity)
			transform.position = new Vector3 (transform.position.x, Blueprint [loadNumber].transform.position.y + 6.0f, transform.position.z);

	}
    void TakeScreen()
    {
        if (Grab == true && Captured == false)
        {


            //Debug.Log("Captured Screenshot");

            if (loadNumber < Blueprint.Capacity)
            {
                image = new Texture2D(Screen.width, Screen.height);
                image.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);

                image.Apply();

                //pngShot.Add(image.EncodeToPNG());

                //load map texture
                Blueprint[loadNumber].GetComponent<Renderer>().material.mainTexture = image;

                loadNumber++;
            }
            else
            {
                playerscript.stages.CurrentPhase = (int)PHASE.HEIST;
                Captured = true;
                gameObject.GetComponent<Camera>().rect = new Rect(.5f, .5f, 1, 1);
                Player.GetComponentInChildren<Camera>().transform.gameObject.SetActive(true);

                turnoffCanvas.SetActive(true);
                FogofWar.SetActive(false);

                //delete lines
                GameObject[] Lines;
                Lines = GameObject.FindGameObjectsWithTag("Lines");

                foreach (GameObject line in Lines)
                {
                    Destroy(line);
                }
            }
        }

    }

    void OnPostRender()
    {
        TakeScreen();
    }

    void DeleteLines()
    {
        var deletinglineobjecy = Lines[Lines.Count - 1];
        Lines.RemoveAt(Lines.Count - 1);
        Destroy(deletinglineobjecy.gameObject);
    }



    void DrawLines()
    {
        numberOfPoints++;
        lineRender.SetVertexCount(numberOfPoints);
        Vector3 mousePos = new Vector3(0, 0, 0);
        mousePos = Input.mousePosition;
        mousePos.z = 1.0f;
        Vector3 worldPos = MapCamera.ScreenToWorldPoint(mousePos);
        lineRender.SetPosition(numberOfPoints - 1, worldPos);
        lineRender.transform.localScale = new Vector3(500.0f, 500.0f, 500.0f);
    }

    void StoreAndMakeNewLine()
    {
        Lines.Add(Instantiate(lineRender));
        numberOfPoints = 0;
        lineRender.SetVertexCount(0);
    }


	// Update is called once per frame
	void Update () {
        SwitchBlueprint();
        PostScreen();

        if (Captured == false && playerstage.ComparePhase(playerstage.CurrentPhase,PHASE.PLANNING))
        {
            if (Input.GetKeyDown(KeyCode.P) && Lines.Count != 0)
                DeleteLines();
            if (Input.GetMouseButton(0))
                DrawLines();
            else if (Input.GetMouseButtonUp(0))
                StoreAndMakeNewLine();
        }
	}
}
