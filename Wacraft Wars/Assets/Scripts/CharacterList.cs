using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class CharacterList : MonoBehaviour
{

    public List<HexStats> CharList = new List<HexStats>();

    void Start()
    {
        StartList(GameObject.FindGameObjectsWithTag("Character"));
    }

    // Update is called once per fram
    void Update()
    {
    }

    void StartList(GameObject[] Hex)
    {
        for (int i = 0; i < Hex.Length; i++)
        {
            GameObject hex = Hex[i];
            HexStats GridHex = hex.GetComponent<HexStats>();

            CharList.Add(GridHex);
        }
    }

    public bool CheckListIn(Vector3 NewPos)
    {
        //hex that you are moving to
        Vector3 OneDownPos = NewPos;
        Vector3 HalfDownPos = NewPos - new Vector3(0, .5f, 0); 							///Change///

        bool IsItTrue = false;

        for (int i = 0; i < CharList.Count; i++)
        {
            if (CharList[i].PosXYZ == OneDownPos)
            {
                IsItTrue = true;
                Debug.Log("Tile Pos");
                Debug.Log(CharList[i].PosXYZ);
                Debug.Log("Pos To Be Checked");
                Debug.Log(OneDownPos);
            }
            if (CharList[i].PosXYZ == HalfDownPos)
            {
                IsItTrue = true;
                Debug.Log("Tile Pos (.5)");
                Debug.Log(CharList[i].PosXYZ);
                Debug.Log("Pos To Be Checked (.5)");
                Debug.Log(HalfDownPos);
            }
        }
        if (IsItTrue == true)
        { return true; }
        return false;
    }

    public bool CheckListBelow(Vector3 NewPos)
    {
        //hex that you are moving to
        Vector3 OneDownPos = NewPos - new Vector3(0, 1, 0);
        Vector3 HalfDownPos = NewPos - new Vector3(0, 1.5f, 0); 							///Change///

        bool IsItTrue = false;

        for (int i = 0; i < CharList.Count; i++)
        {
            if (CharList[i].PosXYZ == OneDownPos)
            {
                IsItTrue = true;
                break;
            }
            if (CharList[i].PosXYZ == HalfDownPos)
            {
                IsItTrue = true;
                break;
            };
        }
        if (IsItTrue == true)
        { return true; }
        return false;
    }
}