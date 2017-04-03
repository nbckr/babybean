using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyController : MonoBehaviour
{

    public GameObject face;
    public int health = 3;
    public float faceAnimationBuffer = 0.5f;

    private Mood mood;
    private float lastFaceAnimation = 0;

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

    public void Hurt(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
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
