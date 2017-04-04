using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyController : MonoBehaviour
{

    public GameObject face;
    public int health = 3;
	public float spareTime = 1f;
    public float faceAnimationBuffer = 0.5f;

    private Mood mood;
    private float lastFaceAnimation = 0f;
	private float lastDamageTime = 0f;

    public enum Mood { happy, content, notamused, frown, shocked, horrified, screaming, screaming_red };

    void Start()
    {
        SetMood(Mood.happy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SetMood(Mood.screaming_red);
        }

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
		if (Time.time > lastDamageTime + spareTime) {
			health -= damage;
			lastDamageTime = Time.time;
			if (health <= 0) {
				Die ();
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
