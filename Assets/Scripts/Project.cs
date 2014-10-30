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

	// Use this for initialization
	void Start () {
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

	// Update is called once per frame
	void Update () {

        //Affective
        //boredom
        if (EmoAffectiv.boredomScore != _boredomScore)
        {
            _boredomScore = EmoAffectiv.boredomScore;
            Debug.Log("New boredome Score: "+ _boredomScore);
        }
        //frustration
        if (EmoAffectiv.frustrationScore != _frustrationScore)
        {
            _frustrationScore = EmoAffectiv.frustrationScore;
            Debug.Log("New frustration Score: " + _frustrationScore);
        }
        //meditation
        if (EmoAffectiv.meditationScore != _meditationScore)
        {
            _meditationScore = EmoAffectiv.meditationScore;
            Debug.Log("New meditation Score: " + _meditationScore);
        }

        //Expressive
        //Clench extent
        if (EmoExpressiv.clenchExtent != _clenchExtent)
        {
            _clenchExtent = EmoExpressiv.clenchExtent;
            Debug.Log("New clench extent: " + _clenchExtent);
        }
        //Eyebrow extent
        if (EmoExpressiv.eyebrowExtent != _eyebrowExtent)
        {
            _eyebrowExtent = EmoExpressiv.eyebrowExtent;
            Debug.Log("New clench extent: " + _eyebrowExtent);
        }
        //Eyelid state left
        if (EmoExpressiv.eyelidStateLeft != _eyelidStateLeft)
        {
            _eyelidStateLeft = EmoExpressiv.eyelidStateLeft;
            Debug.Log("New clench extent: " + _eyelidStateLeft);
        }
        //Eyelid state right
        if (EmoExpressiv.eyelidStateRight != _eyelidStateRight)
        {
            _eyelidStateRight = EmoExpressiv.eyelidStateRight;
            Debug.Log("New clench extent: " + _eyelidStateRight);
        }
        //Eyelid location X
        if (EmoExpressiv.eyeLocationX != _eyeLocationX)
        {
            _eyeLocationX = EmoExpressiv.eyeLocationX;
            Debug.Log("New clench extent: " + _eyeLocationX);
        }
        //Eyelid location Y
        if (EmoExpressiv.eyeLocationY != _eyeLocationY)
        {
            _eyeLocationY = EmoExpressiv.eyeLocationY;
            Debug.Log("New clench extent: " + _eyeLocationY);
        }
        //is blink
        if (EmoExpressiv.isBlink != _isBlink)
        {
            _isBlink = EmoExpressiv.isBlink;
            Debug.Log("New clench extent: " + _isBlink);
        }
        //is eyes open
        if (EmoExpressiv.isEyesOpen != _isEyesOpen)
        {
            _isEyesOpen = EmoExpressiv.isEyesOpen;
            Debug.Log("New clench extent: " + _isEyesOpen);
        }
        //is left wink
        if (EmoExpressiv.isLeftWink != _isLeftWink)
        {
            _isLeftWink = EmoExpressiv.isLeftWink;
            Debug.Log("New clench extent: " + _isLeftWink);
        }
        //is looking down
        if (EmoExpressiv.isLookingDown != _isLookingDown)
        {
            _isLookingDown = EmoExpressiv.isLookingDown;
            Debug.Log("New clench extent: " + _isLookingDown);
        }
        //is looking left
        if (EmoExpressiv.isLookingLeft != _isLookingLeft)
        {
            _isLookingLeft = EmoExpressiv.isLookingLeft;
            Debug.Log("New clench extent: " + _isLookingLeft);
        }
        //is looking right
        if (EmoExpressiv.isLookingRight != _isLookingRight)
        {
            _isLookingRight = EmoExpressiv.isLookingRight;
            Debug.Log("New clench extent: " + _isLookingRight);
        }
        //is looking up
        if (EmoExpressiv.isLookingUp != _isLookingUp)
        {
            _isLookingUp = EmoExpressiv.isLookingUp;
            Debug.Log("New clench extent: " + _isLookingUp);
        }
        //is right wink
        if (EmoExpressiv.isRightWink != _isRightWink)
        {
            _isRightWink = EmoExpressiv.isRightWink;
            Debug.Log("New clench extent: " + _isRightWink);
        }
        //smile extent
        if (EmoExpressiv.smileExtent != _smileExtent)
        {
            _smileExtent = EmoExpressiv.smileExtent;
            Debug.Log("New clench extent: " + _smileExtent);
        }
       
	}

    void OnGUI()
    {
        //Affective
        GUI.Label(new Rect(0, 0, _affectiveTextureBG.width, _affectiveTextureBG.height), _affectiveTextureBG);
            //GUI.Box(new Rect(0, 0, 150, 50), "Laber."+_number);
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
