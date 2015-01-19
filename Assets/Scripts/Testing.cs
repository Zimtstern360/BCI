using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Testing : MonoBehaviour
{
    private List<GameObject> _pointsList = new List<GameObject>();
    private List<float> _xCoordList = new List<float>();
    public GameObject _singlePoint;

    public Camera _MainCamera;
    public int _Screenwidth = 1024;
    public int _Screenheight = 768;
    

    void Start()
    {
        InitializeScreen();

        for (int j = 0; j < 40; j++)
        {
            _xCoordList.Add(Random.Range(-1.0f, 1.0f));
            //Debug.Log(_xCoordList[j]);
        }

        BuildPoints();
        
        /*Debug.Log(_xCoordList.Count);
        Debug.Log("Element an Stelle 0:" +_xCoordList[0]);
        Debug.Log("Element an Stelle 1:" +_xCoordList[1]);

        _xCoordList.RemoveAt(0);
        _xCoordList.Add(0.5f);

        Debug.Log(_xCoordList.Count);
        Debug.Log("Neues Element Stelle 0:" +_xCoordList[0]);
        Debug.Log("Am Ende:" +_xCoordList[19]);*/

    }
    
    
    void Update()
    {
        //delete an stelle 0
        //stelle count-1 = stelle coord+1
        if(_xCoordList.Count > 20)
        {
            _xCoordList.RemoveAt(0);
            foreach (GameObject _singlePoint in _pointsList)
            {
                DestroyImmediate(_singlePoint);
            }
            _pointsList.Clear();
            BuildPoints();
        }
        

    }

    void OnGUI()
    {
        GUI.Box(new Rect(2, 2, 50, 15), "Max: ");
        GUI.Box(new Rect(2, 20, 50, 15), "Min: ");
        GUI.Box(new Rect(2, 40, 50, 15), "Average: ");
    }

    void BuildPoints()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject _point = Instantiate(_singlePoint, new Vector3(i * 0.25F, _xCoordList[i], 0), Quaternion.identity) as GameObject;
            _point.transform.parent = transform;
            _pointsList.Add(_point);
        }
    }

    void NewCoords()
    {
        //refresh points with new coords
        foreach (GameObject _singlePoint in _pointsList)
        {
           // _singlePoint.transform.position.y = whattheheck;
        }
    }


    private void InitializeScreen()
    {
        Screen.SetResolution(_Screenwidth, _Screenheight, false);
    }

}