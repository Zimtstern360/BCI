using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GraphPlotter : MonoBehaviour {

	private List<float> _xList = new List<float>(50);
    private List<float> _yList = new List<float>(50);
    private List<float> _zList = new List<float>(50);
    private List<float> _uList = new List<float>(50);

    private static Material mat;

    public float _offsetX = 0.025f;
    public float _offsetY = 0.25f;

	void Start()
	{

	}

    void Update()
    {
        RandomCoords(_xList);
        RandomCoords(_yList);
        RandomCoords(_zList);
        RandomCoords(_uList);

        if (_xList.Count >= 50)
        {
            _xList.RemoveAt(0);
        }

        if (_yList.Count >= 50)
        {
            _yList.RemoveAt(0);
        }

        if (_zList.Count >= 50)
        {
            _zList.RemoveAt(0);
        }

        if (_uList.Count >= 50)
        {
            _uList.RemoveAt(0);
        }
    }

    void Awake()
    {
        mat = new Material("Shader \"Lines/Colored Blended\" {" +
          "SubShader { Pass { " +
          "    Blend SrcAlpha OneMinusSrcAlpha " +
          "    ZWrite On Cull Off Fog { Mode Off } " +
          "    ZTest Always " +
          "    BindChannels {" +
          "      Bind \"vertex\", vertex Bind \"color\", color }" +
          "} } }");
        mat.hideFlags = HideFlags.HideAndDontSave;
        mat.shader.hideFlags = HideFlags.HideAndDontSave;
    }

    void RandomCoords(List<float> tempList)
    {
        float maxX = 2.0f;
        float minX = 0.0f;
        float tempX = 1.0f;

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
    }

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
                GL.Vertex3(0.05f * t, _xList[t] / 2, 0);
            }
            GL.Vertex3(0.05f * t, _xList[t] / 2, 0);
            //GL.Vertex3(1,1,0);
        }
        GL.End();

        //Begin Waveform Y
        GL.Begin(GL.LINES);
        GL.Color(Color.black);
        GL.Viewport(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2));
        for (int t = 0; t < 50; t++)
        {
            if (t > 0 && t < 50)
            {
                GL.Vertex3(0.05f * t, _yList[t] / 2, 0);
            }
            GL.Vertex3(0.05f * t, _yList[t] / 2, 0);
            //GL.Vertex3(1,1,0);
        }
        GL.End();

        //Begin Waveform Z
        GL.Begin(GL.LINES);
        GL.Color(Color.black);
        GL.Viewport(new Rect(0, 0, Screen.width / 2, Screen.height / 2));
		for (int t = 0; t < 50; t++) 
		{
			if (t>0 && t<50)
			{
                GL.Vertex3(0.05f * t, _zList[t] / 2, 0);
			}
            GL.Vertex3(0.05f * t, _zList[t] / 2, 0);
			//GL.Vertex3(1,1,0);
		}
		GL.End();

        //Begin Waveform U
        GL.Begin(GL.LINES);
        GL.Color(Color.black);
        GL.Viewport(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height / 2));
        for (int t = 0; t < 50; t++)
        {
            if (t > 0 && t < 50)
            {
                GL.Vertex3(0.05f * t, _uList[t] / 2, 0);
            }
            GL.Vertex3(0.05f * t, _uList[t] / 2, 0);
            //GL.Vertex3(1,1,0);
        }
        GL.End();

		GL.PopMatrix();
	}


    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width / 2, Screen.height / 2), "Waveform for X");
        GUI.Box(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height / 2), "Waveform for Y");
        GUI.Box(new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Waveform for Z");
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Waveform for U");
 
    }

    void OnApplicationQuit()
    {
        DestroyImmediate(mat);
    }

}