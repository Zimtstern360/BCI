using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Brainwaves : MonoBehaviour
{
    private List<GameObject> _pointsList = new List<GameObject>();
    private List<GameObject> _fillerPointsList = new List<GameObject>();
    private List<float> _xCoordList = new List<float>();
    public GameObject _singlePoint;

    public GameObject _parentPoints;
    public GameObject _parentFillerPoints;

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
        RandomCoords();

        if(_xCoordList.Count > 20)
        {
            _xCoordList.RemoveAt(0);
            foreach (GameObject _singlePoint in _pointsList)
            {
                DestroyImmediate(_singlePoint);
            }
            foreach (GameObject _fillerPoint in _fillerPointsList)
            {
                DestroyImmediate(_fillerPoint);
            }
            _pointsList.Clear();
            _fillerPointsList.Clear();
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
            GameObject _point = Instantiate(_singlePoint, new Vector3(i * 0.125F, _xCoordList[i], 0), Quaternion.identity) as GameObject;
            Debug.Log("Single Point: "+_singlePoint.transform.position.y);
            _point.transform.parent = _parentPoints.transform;
            _pointsList.Add(_point);

            GameObject _fillerPoint = Instantiate(_singlePoint, new Vector3(i * 0.125f, ((_point.transform.position.y > this.transform.position.y) ? (_point.transform.position.y * 0.9f) : 1), (_point.transform.position.y * 1.1f)), Quaternion.identity) as GameObject;
            Debug.Log("Filler Point: " + _fillerPoint.transform.position.y);
            _fillerPoint.transform.parent = _parentFillerPoints.transform;
            _fillerPointsList.Add(_fillerPoint);
        }
    }

    void BuildFillerPoints()
    {
        
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


    void RandomCoords()
    {
        _xCoordList.Add(Random.Range(-1.0f, 1.0f));
    }


}