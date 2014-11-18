using UnityEngine;
using System.Collections;

public class AnimatedFace : MonoBehaviour {

    //Resolution
    private int _ScreenWidth;
    private int _ScreenHeight;
    public Camera _MainCam;

    public ChangeSprite _leftBrow;
    public ChangeSprite _rightBrow;
    public ChangeSprite _leftEye;
    public ChangeSprite _rightEye;
    public ChangeSprite _leftLid;
    public ChangeSprite _rightLid;
    public ChangeSprite _mouthC;
    public ChangeSprite _headLeft;
    public ChangeSprite _headRight;
    public ChangeSprite _headUp;
    public ChangeSprite _headDown;

    //Sprites active
    public Sprite _headActiveSprite;
    public Sprite _browActiveLeft;
    public Sprite _browActiveRight;
    public Sprite _eyeActiveLeft;
    public Sprite _eyeActiveRight;
    public Sprite _lidActiveLeft;
    public Sprite _lidActiveRight;
    public Sprite _mouthActive;
    public Sprite _headDownC;
    public Sprite _headUpC;
    public Sprite _headLeftC;
    public Sprite _headRightC;
    //Sprites default
    public Sprite _headSprite;
    public Sprite _browLeft;
    public Sprite _browRight;
    public Sprite _eyeLeft;
    public Sprite _eyeRight;
    public Sprite _lidLeft;
    public Sprite _lidRight;
    public Sprite _mouth;
    //Affective States
    private float _boredomScore;
    private float _frustrationScore;
    private float _meditationScore;
    //Expressive States
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


	// Use this for initialization
	void Start () {

        _ScreenHeight = 786;
        _ScreenWidth = 1024;
        //_MainCam.orthographicSize = 7.5f;
        Screen.SetResolution(_ScreenWidth, _ScreenHeight, false);

	}
	
	// Update is called once per frame
	void Update () {

        if(_clenchExtent != 0)
        {
            _mouthC.Change(_mouthActive);
        }
        if(_eyebrowExtent != 0)
        {
            _leftBrow.Change(_browActiveLeft);
            _rightBrow.Change(_browActiveRight);
        }
        if(_eyelidStateLeft != 0)
        {
            _leftLid.Change(_lidActiveLeft);
        }
        if(_eyelidStateRight != 0)
        {
            _rightLid.Change(_lidActiveRight);
        }
        if(_isBlink == true)
        {
            _leftLid.Change(_lidActiveLeft);
            _rightLid.Change(_lidActiveRight);
        }
        if(_isEyesOpen == false)
        {
            _leftLid.Change(_lidActiveLeft);
            _rightLid.Change(_lidActiveRight);
        }
        if(_isLeftWink == true)
        {
            _leftLid.Change(_lidActiveLeft);
        }
        if (_isRightWink == true)
        {
            _rightLid.Change(_lidActiveRight);
        }
        if (_smileExtent != 0)
        {
            _mouthC.Change(_mouthActive);
        }
        if (_isLookingDown == true)
        {
            _headDown.Change(_headDownC);
        }
        if (_isLookingUp == true)
        {
            _headUp.Change(_headUpC);
        }
        if (_isLookingLeft == true)
        {
            _headLeft.Change(_headLeftC);
        }
        if (_isLookingRight == true)
        {
            _headRight.Change(_headRightC);
        }
        else {
            //funzt des so überhaupt
            _leftBrow.Change(_browLeft);
            _rightBrow.Change(_browRight);
            _leftEye.Change(_eyeLeft);
            _rightEye.Change(_eyeRight);
            _leftLid.Change(_lidLeft);
            _rightLid.Change(_lidRight);
            _mouthC.Change(_mouth);
        }


	}

    void OnGUI()
    {
        //Affective
        GUI.Box(new Rect(10, 10, 150, 20), "Boredom score: " + _boredomScore);
        GUI.Box(new Rect(10, 40, 150, 20), "Frustration score: " + _frustrationScore);
        GUI.Box(new Rect(10, 70, 150, 20), "Meditation score: " + _meditationScore);
        //Expressive
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
