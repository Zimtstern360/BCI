using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interface : MonoBehaviour {

    private Text _max;
    private Text _min;
    private Text _avg;

    private float _maximum = 0.0f;
    private float _minimum = 0.0f;
    private float _average = 0.0f;


	// Use this for initialization
	void Start () {

        _max = gameObject.GetComponent<Text>();
        _min = gameObject.GetComponent<Text>();
        _avg = gameObject.GetComponent<Text>();

        if(gameObject.tag == "Maximum")
        {
            _max.text = "Maximum: ";
        }
        if(gameObject.tag == "Minimum")
        {
            _min.text = "Minimum: ";
        }
        if (gameObject.tag == "Average")
        {
            _avg.text = "Average: ";
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.tag == "Maximum")
        {
            _max.text = "Maximum: " + _maximum;
        }
        if (gameObject.tag == "Minimum")
        {
            _min.text = "Minimum: " + _minimum;
        }
        if (gameObject.tag == "Average")
        {
            _avg.text = "Average: " + _average;
        }

	}
}



/*
     // Update is called once per frame
     void Update () {
         txt.text="Score : " + currentscore;  
         currentscore = PlayerPrefs.GetInt("TOTALSCORE"); 
         PlayerPrefs.SetInt("SHOWSTARTSCORE",currentscore); 
     }*/