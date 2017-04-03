using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBean : MonoBehaviour {
    private Mood mood;
    private Renderer renderer;
    public Material[] materials;

    enum Mood { happy, content, notAmused, frown, shocked, horified, screaming, screamingRed };

    void Start () {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
        renderer.sharedMaterial = materials[0];
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.RightArrow))
        {
            renderer.sharedMaterial = materials[1];
            Debug.Log("test material");
        }
	}

    private void SetMood(Mood mood)
    {
        renderer.sharedMaterial = materials[1];
    }
}