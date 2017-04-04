using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CribController : MonoBehaviour {

    public GameController gameController;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void OnTriggerEnter () {
        gameController.babyOnCrib = true;
	}

    void OnTriggerExit()
    {
        gameController.babyOnCrib = false;
    }
}
