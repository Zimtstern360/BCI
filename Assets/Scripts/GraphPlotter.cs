using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GraphPlotter : MonoBehaviour {

    private float _listLength = 50;

    private List<float> _boredomList = new List<float>(50);
    private List<float> _frustrationList = new List<float>(50);
    private List<float> _meditationList = new List<float>(50);

    private static Material mat;

    private float _offset;
    private float _offsetY;
    private float _pointDis;

    //Affective
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
        _offset = 0.1f;
        _offsetY = 0.5f;
        _pointDis = (0.8f / _listLength);

        //temp file for saving values
        //TODO: funktion zum löschen und neu anlegen
        ClearTxtFiles();
        boredomFile = @"C:/Users/Steffi/Documents/Master/Masterthesis/boredomValues.txt";
        frustrationFile = @"C:/Users/Steffi/Documents/Master/Masterthesis/frustrationValues.txt";
        meditationFile = @"C:/Users/Steffi/Documents/Master/Masterthesis/meditationValues.txt";

        savePathBoredomNew = path + userName + pathEndBoredom;
        savePathFrustrationNew = path + userName + pathEndFrustration;
        savePathMeditationNew = path + userName + pathEndMeditation;

        //set affective states once for start
        _boredomScore = EmoAffectiv.boredomScore;
        _frustrationScore = EmoAffectiv.frustrationScore;
        _meditationScore = EmoAffectiv.meditationScore;

        //clear lists
        _boredomList.Clear();
        _frustrationList.Clear();
        _meditationList.Clear();
        //fill lists
        for (int i = 0; i < 50; i++ )
        {
            _boredomList.Add(0);
            _frustrationList.Add(0);
            _meditationList.Add(0);
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
        //Saving Boredom Values
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