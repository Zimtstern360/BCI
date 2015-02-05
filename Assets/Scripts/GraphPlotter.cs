using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

public class GraphPlotter : MonoBehaviour {

    private float _listLength = 50;

    private List<float> _boredomList = new List<float>(50);
    private List<float> _frustrationList = new List<float>(50);
    private List<float> _meditationList = new List<float>(50);

    private static Material mat;

    private float _offset;
    private float _offsetY;
    private float _pointDis;

    //Affective values and txt files
    private float _boredomScore;
    private float _frustrationScore;
    private float _meditationScore;

    private string boredomFile;
    private string frustrationFile;
    private string meditationFile;

    //file handling
    public string userName;
    private string path = "C:/Users/Steffi/Documents/Master/Masterthesis/Results/";
    private string pathEndBoredom = "Boredom.txt";
    private string pathEndFrustration = "Frustration.txt";
    private string pathEndMeditation = "Meditation.txt";

    string savePathBoredomNew;
    string savePathFrustrationNew;
    string savePathMeditationNew;

	void Start()
	{
        //offset values for displaying graphs
        _offset = 0.1f;
        _offsetY = 0.5f;
        _pointDis = (0.8f / _listLength);

        //temp file for saving values, gets moved and saved permanently later
        ClearTxtFiles();
        boredomFile = @"C:/Users/Steffi/Documents/Master/Masterthesis/boredomValues.txt";
        frustrationFile = @"C:/Users/Steffi/Documents/Master/Masterthesis/frustrationValues.txt";
        meditationFile = @"C:/Users/Steffi/Documents/Master/Masterthesis/meditationValues.txt";

        savePathBoredomNew = path + userName + pathEndBoredom;
        savePathFrustrationNew = path + userName + pathEndFrustration;
        savePathMeditationNew = path + userName + pathEndMeditation;

        //set affective states for start once
        _boredomScore = EmoAffectiv.boredomScore;
        _frustrationScore = EmoAffectiv.frustrationScore;
        _meditationScore = EmoAffectiv.meditationScore;

        //clear lists for once
        _boredomList.Clear();
        _frustrationList.Clear();
        _meditationList.Clear();
        //fill lists for once
        for (int i = 0; i < 50; i++ )
        {
            _boredomList.Add(2);
            _frustrationList.Add(4);
            _meditationList.Add(8);
        }
	}

    void Update()
    {
        #region boredomStuff
        //Boredom Stuff
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
        //Saving boredom values
        for (int i = 0; i < _boredomList.Count; i++ )
        {
             if (!File.Exists(boredomFile))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(boredomFile))
                {
                    sw.WriteLine("Values of Boredom Graph");
                    sw.WriteLine("...");
                }
            }

            using (StreamWriter sw = File.AppendText(boredomFile))
            {
                sw.WriteLine(_boredomList[i].ToString());
            }

        }
        #endregion 

        #region frustrationStuff
        //frustration Stuff
        if (_frustrationList.Count < 50)
        {
            if (_frustrationScore != EmoAffectiv.frustrationScore)
            {
                _frustrationScore = EmoAffectiv.frustrationScore;
                _frustrationList.Add(_frustrationScore);
            }
            else
            {
                _frustrationList.Add(_frustrationScore);
            }
        }
        if (_frustrationList.Count >= 50)
        {
            _frustrationList.RemoveAt(0);

            if (_frustrationScore != EmoAffectiv.frustrationScore)
            {
                _frustrationScore = EmoAffectiv.frustrationScore;
                _frustrationList.Add(_frustrationScore);
            }
            else
            {
                _frustrationList.Add(_frustrationScore);
            }
        }
        //Saving Frustration Values
        for (int i = 0; i < _frustrationList.Count; i++)
        {
            if (!File.Exists(frustrationFile))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(frustrationFile))
                {
                    sw.WriteLine("Values of Frustration Graph");
                    sw.WriteLine("...");
                }
            }

            using (StreamWriter sw = File.AppendText(frustrationFile))
            {
                sw.WriteLine(_frustrationList[i].ToString());
            }
        }
        #endregion

        #region meditationStuff
        //frustration Stuff
        if (_meditationList.Count < 50)
        {
            if (_meditationScore != EmoAffectiv.meditationScore)
            {
                _meditationScore = EmoAffectiv.meditationScore;
                _meditationList.Add(_meditationScore);
            }
            else
            {
                _meditationList.Add(_meditationScore);
            }
        }
        if (_meditationList.Count >= 50)
        {
            _meditationList.RemoveAt(0);

            if (_meditationScore != EmoAffectiv.meditationScore)
            {
                _meditationScore = EmoAffectiv.meditationScore;
                _meditationList.Add(_meditationScore);
            }
            else
            {
                _meditationList.Add(_meditationScore);
            }
        }
        //Saving Frustration Values
        for (int i = 0; i < _meditationList.Count; i++)
        {
            if (!File.Exists(meditationFile))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(meditationFile))
                {
                    sw.WriteLine("Values of Meditation Graph");
                    sw.WriteLine("...");
                }
            }

            using (StreamWriter sw = File.AppendText(meditationFile))
            {
                sw.WriteLine(_meditationList[i].ToString());
            }
        }
        #endregion

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

	void OnPostRender() {
		if (!mat) {
			Debug.LogError("Please Assign a material on the inspector");
			return;
		}
		GL.PushMatrix();
		mat.SetPass(0);
		GL.LoadOrtho();

        //Boredom Graph (upper left)
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

        //Frustration Graph (upper right)
        GL.Begin(GL.LINES);
        GL.Color(Color.black);
        GL.Viewport(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2));
        for (int t = 0; t < 50; t++)
        {
            if (t > 0 && t < 50)
            {
                GL.Vertex3(_offset + (_pointDis * t), (_boredomList[t] / 2f) + _offsetY, 0);
            }
            GL.Vertex3(_offset + (_pointDis * t), (_boredomList[t] / 2f) + _offsetY, 0);
        }
        GL.End();

        //Meditation Graph (lower left)
        GL.Begin(GL.LINES);
        GL.Color(Color.black);
        GL.Viewport(new Rect(0, 0, Screen.width / 2, Screen.height / 2));
        for (int t = 0; t < 50; t++)
        {
            if (t > 0 && t < 50)
            {
                GL.Vertex3(_offset + (_pointDis * t), (_boredomList[t] / 2f) + _offsetY, 0);
            }
            GL.Vertex3(_offset + (_pointDis * t), (_boredomList[t] / 2f) + _offsetY, 0);
        }
        GL.End();

        //End GL
		GL.PopMatrix();
	}

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width / 2, Screen.height / 2), "Boredom Graph");
        GUI.Box(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height / 2), "Frustration Graph");
        GUI.Box(new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Meditation Graph");
        //Max values
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "Max & Min Values");
        GUI.Box(new Rect((Screen.width / 2) + 25, (Screen.height / 2) + 20, 200, 25), "Max. Boredom Value: "+MaxValue(_boredomList));
        GUI.Box(new Rect((Screen.width / 2) + 25, (Screen.height / 2) + 45, 200, 25), "Max. Frustration Value: " + MaxValue(_frustrationList));
        GUI.Box(new Rect((Screen.width / 2) + 25, (Screen.height / 2) + 70, 200, 25), "Max. Meditation Value: " + MaxValue(_meditationList));
        //Min values
        GUI.Box(new Rect((Screen.width / 2) + 25, (Screen.height / 2) + 110, 200, 25), "Min. Boredom Value: " + MinValue(_boredomList));
        GUI.Box(new Rect((Screen.width / 2) + 25, (Screen.height / 2) + 135, 200, 25), "Min. Frustration Value: " + MinValue(_frustrationList));
        GUI.Box(new Rect((Screen.width / 2) + 25, (Screen.height / 2) + 160, 200, 25), "Min. Meditation Value: " + MinValue(_meditationList));
 
    }

    void ClearTxtFiles()
    {
        if(File.Exists(boredomFile))
        {
            File.Delete(boredomFile);
        }
        if (File.Exists(frustrationFile))
        {
            File.Delete(frustrationFile);
        }
        if (File.Exists(meditationFile))
        {
            File.Delete(meditationFile);
        }
    }

    //get max value from list with LINQ
    float MaxValue(List<float> givenList)
    {
        float result = (from res in givenList select res).Max();
        return result;
    }

    //get min value from list with LINQ
    float MinValue(List<float> givenList)
    {
        float result = (from res in givenList select res).Min();
        return result;
    }

    void OnApplicationQuit()
    {
        DestroyImmediate(mat);
        // Move boredom file
        if (File.Exists(savePathBoredomNew))
        {
            File.Delete(savePathBoredomNew);
        }
        File.Move(boredomFile, savePathBoredomNew);
        // Move frustration file
        if (File.Exists(savePathFrustrationNew))
        {
            File.Delete(savePathFrustrationNew);
        }
        File.Move(frustrationFile, savePathFrustrationNew);
        // Move meditation file
        if (File.Exists(savePathMeditationNew))
        {
            File.Delete(savePathMeditationNew);
        }
        File.Move(meditationFile, savePathMeditationNew);
    }
}