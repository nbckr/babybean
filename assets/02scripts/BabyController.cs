using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyController : MonoBehaviour
{
    public GameObject face;
    public int health;
	public float spareTime = 1f;
    public float faceAnimationBuffer = 0.5f;

    private Mood mood;
    private float lastFaceAnimation = 0f;
	private float lastDamageTime = 0f;
    private GameObject buttonUp;
    private GameObject buttonMiddle;
    private GameObject buttonDown;

    public enum Mood { happy, content, notamused, frown, shocked, horrified, screaming, screaming_red };

    void Start()
    {
        Debug.Log("new baby script");


        SetMood(Mood.happy);
        buttonDown = GameObject.FindGameObjectWithTag("ButtonDown");
        buttonMiddle = GameObject.FindGameObjectWithTag("ButtonMiddle");
        buttonUp = GameObject.FindGameObjectWithTag("ButtonUp");
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void SetMood(Mood mood)
    {
        this.mood = mood;

        if (Time.time > lastFaceAnimation + faceAnimationBuffer)
        {
            face.GetComponent<Renderer>().material.mainTexture = Resources.Load("Images/babybean_" + mood.ToString()) as Texture;
            lastFaceAnimation = Time.time;
        }
    }

    public void SubtractHealth(int damage)
    {
        Debug.Log("subtract health");

		if (Time.time > lastDamageTime + spareTime) {
			health -= damage;
			lastDamageTime = Time.time;

            switch (health) {
                case 2:
                    buttonDown.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 1:
                    buttonMiddle.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 0:
                    buttonUp.GetComponent<Renderer>().material.color = Color.red;
                    Die();
                    break;
            }
		}
    }

    public void Die()
    {
        // GameController.GameOver()
        // play audio
        SetMood(Mood.screaming_red);
        Debug.Log("I died");
    }

    public void Respawn()
    {
    }
}
