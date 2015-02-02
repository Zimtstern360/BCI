using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GraphPlotter : MonoBehaviour {

    private float _listLength = 50;

	//private List<float> _xList = new List<float>(50);
    private List<float> _boredomList = new List<float>(50);

    private static Material mat;

    private float _offset;
    private float _offsetY;
    private float _pointDis;

    //Affective
    private float _boredomScore;
    private float _frustrationScore;
    private float _meditationScore;

	void Start()
	{
        _offset = 0.1f;
        _offsetY = 0.5f;
        _pointDis = (0.8f / _listLength);

        //set affective states once for start
        _boredomScore = EmoAffectiv.boredomScore;
        _frustrationScore = EmoAffectiv.frustrationScore;
        _meditationScore = EmoAffectiv.meditationScore;

        //clear list
        _boredomList.Clear();
        //fill list
        for (int i = 0; i < 50; i++ )
        {
            _boredomList.Add(0);
        }
	}

    void Update()
    {
        //RandomCoords(_xList);

        /*if (_xList.Count >= 50)
        {_xList.RemoveAt(0);}*/
        Debug.Log("boredom: " + _boredomScore);
        Debug.Log(_boredomList.Count);
        Debug.Log("Wert: " +_boredomList[0]);
        if(_boredomList.Count < 50)
        {
            if (_boredomScore != EmoAffectiv.boredomScore)
            {
                _boredomScore = EmoAffectiv.boredomScore;
                _boredomList.Add(_boredomScore);
            }
            else
            {
                _boredomList.Add(_boredomScore);
            }
        }
        if(_boredomList.Count >= 50)
        {
            _boredomList.RemoveAt(0);

            if (_boredomScore != EmoAffectiv.boredomScore)
            {
                _boredomScore = EmoAffectiv.boredomScore;
                _boredomList.Add(_boredomScore);
            }
            else
            {
                _boredomList.Add(_boredomScore);
            }
        }
    }

    void Awake()
    {
        mat = new Material("Shader \"Lines/Colored Blended\" {" +
          "SubShader { Pass { " +
          "    Blend SrcAlpha OneMinusSrcAlpha " +
          "    ZWrite Off Cull Off Fog { Mode Off } " +
          "    ZTest Always " +
          "    BindChannels {" +
          "      Bind \"vertex\", vertex Bind \"color\", color }" +
          "} } }");
        mat.hideFlags = HideFlags.HideAndDontSave;
        mat.shader.hideFlags = HideFlags.HideAndDontSave;
    }

    /*void RandomCoords(List<float> tempList)
    {
        float maxX = 1.0f;
        float minX = -1.0f;
        float tempX = 0.0f;

        for (int i = 0; i < 50; i++)
        {
            float random = Random.Range(-0.05f,0.15f);

            if((tempX + random) > maxX)
            {
                tempList.Add(tempX-random);
            }
            if ((tempX + random) < minX)
            {
                tempList.Add(tempX + random);
            }
            else
            {
                tempList.Add(tempX + random);
            }
            //if(x+random.range > maxX) -> x-random.range
            //if(x+random.range < minX) -> x+random.range
            //else 
            //add(x + random.range)
            //tempList.Add(Random.Range(0.0f, 2.0f));
        }
    }*/

	void OnPostRender() {
		if (!mat) {
			Debug.LogError("Please Assign a material on the inspector");
			return;
		}
		GL.PushMatrix();
		mat.SetPass(0);
		GL.LoadOrtho();

        //Begin Waveform X
        GL.Begin(GL.LINES);
        GL.Color(Color.black);
        GL.Viewport(new Rect(0, Screen.height/2, Screen.width/2, Screen.height/2));
        for (int t = 0; t < 50; t++)
        {
            if (t > 0 && t < 50)
            {
                GL.Vertex3(_offset + (_pointDis * t), (_boredomList[t] / 2f) + _offsetY, 0);
            }
            GL.Vertex3(_offset + (_pointDis * t), (_boredomList[t] / 2f) + _offsetY, 0);
        }
        GL.End();
		GL.PopMatrix();
	}


    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width / 2, Screen.height / 2), "Waveform for X");
        /*GUI.Box(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height / 2), "Waveform for Y");
        GUI.Box(new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Waveform for Z");
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Waveform for U");*/
 
    }

    void OnApplicationQuit()
    {
        DestroyImmediate(mat);
    }

}