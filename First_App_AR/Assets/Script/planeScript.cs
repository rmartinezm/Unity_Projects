using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeScript : MonoBehaviour {


	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
        bool visible = GetComponent<Renderer>().isVisible;
        if (visible)
        {
            gameObject.SendMessage("StartVideo");

        }
    }
    
}
