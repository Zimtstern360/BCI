using UnityEngine;
using System.Collections;

public class Project : MonoBehaviour {

    //Affective
    private float _boredomScore;
    private float _frustrationScore;
    private float _meditationScore;

    //Expressive
    private float _clenchExtent;
    private float _eyebrowExtent;
    private float _eyelidStateLeft;
    private float _eyelidStateRight;
    private float _eyeLocationX;
    private float _eyeLocationY;
    private bool _isBlink;
    private bool _isEyesOpen;
    private bool _isLeftWink;
    private bool _isLookingDown;
    private bool _isLookingLeft;
    private bool _isLookingRight;
    private bool _isLookingUp;
    private bool _isRightWink;
    private float _smileExtent;

    private int _number;
    public Texture _affectiveTextureBG;
    public Texture _expressiveTextureBG;
    public Texture _categoriesTextureBG;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

        _boredomScore = EmoAffectiv.boredomScore;
        _frustrationScore = EmoAffectiv.frustrationScore;
        _meditationScore = EmoAffectiv.meditationScore;

        _clenchExtent = EmoExpressiv.clenchExtent;
        _eyebrowExtent = EmoExpressiv.eyebrowExtent;
        _eyelidStateLeft = EmoExpressiv.eyelidStateLeft;
        _eyelidStateRight = EmoExpressiv.eyelidStateRight;
        _eyeLocationX = EmoExpressiv.eyeLocationX;
        _eyeLocationY = EmoExpressiv.eyeLocationY;
        _isBlink = EmoExpressiv.isBlink;
        _isEyesOpen = EmoExpressiv.isEyesOpen;
        _isLeftWink = EmoExpressiv.isLeftWink;
        _isLookingDown = EmoExpressiv.isLookingDown;
        _isLookingLeft = EmoExpressiv.isLookingLeft;
        _isLookingRight = EmoExpressiv.isLookingRight;
        _isLookingUp = EmoExpressiv.isLookingUp;
        _isRightWink = EmoExpressiv.isRightWink;
        _smileExtent = EmoExpressiv.smileExtent;
	}

    void OnGUI()
    {
        GUI.Label(new Rect((Screen.width/2)-100, (Screen.height/2)-100, _categoriesTextureBG.width, _categoriesTextureBG.height), _categoriesTextureBG);
            

        //Affective
        GUI.Label(new Rect(0, 0, _affectiveTextureBG.width, _affectiveTextureBG.height), _affectiveTextureBG);
            GUI.Box(new Rect(10, 10, 150, 20), "Boredom score: " + _boredomScore);
            GUI.Box(new Rect(10, 40, 150, 20), "Frustration score: " + _frustrationScore);
            GUI.Box(new Rect(10, 70, 150, 20), "Meditation score: " + _meditationScore);
        //Expressive
        GUI.Label(new Rect((Screen.width - 180), 0, _expressiveTextureBG.width, _expressiveTextureBG.height), _expressiveTextureBG);
            GUI.Box(new Rect((Screen.width - 165), 10, 150, 20), "Clench extent: " + _clenchExtent);
            GUI.Box(new Rect((Screen.width - 165), 40, 150, 20), "Eyebrow extent: " + _eyebrowExtent);
            GUI.Box(new Rect((Screen.width - 165), 70, 150, 20), "Eyelidstate left: " + _eyelidStateLeft);
            GUI.Box(new Rect((Screen.width - 165), 100, 150, 20), "Eyelidstate right: " + _eyelidStateRight);
            GUI.Box(new Rect((Screen.width - 165), 130, 150, 20), "Eye location X: " + _eyeLocationX);
            GUI.Box(new Rect((Screen.width - 165), 160, 150, 20), "Eye location Y: " + _eyeLocationY);
            GUI.Box(new Rect((Screen.width - 165), 190, 150, 20), "is blink: " + _isBlink);
            GUI.Box(new Rect((Screen.width - 165), 220, 150, 20), "is eyes open: " + _isEyesOpen);
            GUI.Box(new Rect((Screen.width - 165), 250, 150, 20), "is left wink: " + _isLeftWink);
            GUI.Box(new Rect((Screen.width - 165), 280, 150, 20), "is looking down: " + _isLookingDown);
            GUI.Box(new Rect((Screen.width - 165), 310, 150, 20), "is looking left: " + _isLookingLeft);
            GUI.Box(new Rect((Screen.width - 165), 340, 150, 20), "is looking right: " + _isLookingRight);
            GUI.Box(new Rect((Screen.width - 165), 370, 150, 20), "is looking up: " + _isLookingUp);
            GUI.Box(new Rect((Screen.width - 165), 400, 150, 20), "is right wink: " + _isRightWink);
            GUI.Box(new Rect((Screen.width - 165), 430, 150, 20), "smile extent: " + _smileExtent);
    }

}
