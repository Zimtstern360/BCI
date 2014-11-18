using UnityEngine;
using System.Collections;

public class ChangeSprite : MonoBehaviour {


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Change it
    public void Change (Sprite _changeableSprite)
    {
        this.GetComponent<SpriteRenderer>().sprite = _changeableSprite;
    }
}
