using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Brainwaves : MonoBehaviour
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

        for (int j = 0; j < 200; j++)
        {
            _xCoordList.Add(Random.Range(-1.0f, 1.0f));
        }

        BuildPoints();
    }
    
    
    void Update()
    {
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
        GUI.Box(new Rect(2, 10, 100, 20), "Max: ");
        GUI.Box(new Rect(2, 40, 100, 20), "Min: ");
        GUI.Box(new Rect(2, 70, 100, 20), "Average: ");
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

    void MaxCoord()
    {
        //LINQ undso...
        //int max = _xCoordList.Max(r => r.Age);
    }
    void MinCoord()
    {
        foreach (float min in _xCoordList)
        {

        }
    }
    void AvCoord()
    {
        foreach (float av in _xCoordList)
        {

        }
    }


    private void InitializeScreen()
    {
        Screen.SetResolution(_Screenwidth, _Screenheight, false);
    }

}