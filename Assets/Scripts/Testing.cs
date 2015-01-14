using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Testing : MonoBehaviour
{
    private List<GameObject> _pointsList = new List<GameObject>();
    private List<float> _xCoordList = new List<float>();
    public GameObject _singlePoint;

    void Start()
    {
        for (int j = 0; j < 20; j++)
        {
            _xCoordList.Add(Random.Range(0.0f, 1.0f));
            Debug.Log(_xCoordList[j]);
        }

        BuildPoints();

    }
    
    
    void Update()
    {
        //delete an stelle 0
        //stelle 0 = stelle 0+1
        //stelle count-1 = stelle coord+1

    }

    void BuildPoints()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject _point = Instantiate(_singlePoint, new Vector3(i * 0.5F, _xCoordList[i], 0), Quaternion.identity) as GameObject;
            _pointsList.Add(_point);
        }
    }
}