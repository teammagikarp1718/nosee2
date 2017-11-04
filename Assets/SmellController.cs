using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmellController : MonoBehaviour {

    public Camera camera;

    private bool smellMode = false;

	// Use this for initialization
	void Start () {
        updateMode();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Space))
        {
            updateMode();
        }
	}

    private void updateMode()
    {
        if (smellMode)
        {
            camera.cullingMask = (1 << LayerMask.NameToLayer("SmellMode")) | (1 << LayerMask.NameToLayer("UI")) | (1 << LayerMask.NameToLayer("Default"));
        }
        else
        {
            camera.cullingMask = (1 << LayerMask.NameToLayer("SightMode")) | (1 << LayerMask.NameToLayer("UI")) | (1 << LayerMask.NameToLayer("Default"));
        }

        smellMode = !smellMode;
    }
}
