using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeScript : MonoBehaviour {

    public manager_video manager;
    public GameObject myGameObject;

    public bool flag;

	// Use this for initialization
	void Start ()
    {
        flag = true;
    }
	
	// Update is called once per frame
	void Update () {
        bool visible = GetComponent<Renderer>().isVisible;
        manager = myGameObject.GetComponent<manager_video>();
        Debug.Log(visible.ToString());

        if (visible && flag)
        {
            manager.StartVideo();
            // Si entra una vez entonces cambiaremos la bandera y asi poder solo pausar el video
            // en lugar de iniciar el video desde cero otra vez
            flag = false;
            return;
        }

        if (!flag && !visible)
        {
            manager.PauseVideo();
            return;
        }

        if (visible)
        {
            manager.ContinueVideo();
        }
        
    }
    
}
