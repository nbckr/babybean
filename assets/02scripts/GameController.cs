using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public float velocityFunny = 0.4f;
	public float velocityTooFast = 0.8f;
    public bool babyOnCrib { get; set; }

    private GameObject baby;
    private GameObject crib;
    private BabyController babyController;
    private GameObject head;
	private Rigidbody headRB;
    private int handsOnBaby = 0;
    private int firsttime = 0;



    // Use this for initialization
    void Start () {
        Debug.Log("I started");

        refreshVariables();

        //sceneObjectName = sceneObject.name;
    }

    private void refreshVariables()
    {
        Debug.Log("refesh variables");

        baby = GameObject.FindGameObjectWithTag("Baby");
        head = GameObject.FindGameObjectWithTag("Head");
        crib = GameObject.FindGameObjectWithTag("Crib");
        Debug.Log(baby.name + " " + head + " " + crib.name);

        headRB = head.GetComponent<Rigidbody>();
        babyController = baby.GetComponent<BabyController>();
    }

    // Update is called once per frame
    void Update () {

        Debug.Log("Game Controller update + " + headRB);
        
		// Moving fast?
		if (headRB.velocity.magnitude > velocityFunny && headRB.velocity.magnitude < velocityTooFast) {
			babyController.SetMood (BabyController.Mood.happy);
		}

		// Moving too fast?
		if (headRB.velocity.magnitude > velocityTooFast) {
			babyController.SubtractHealth (1);
			babyController.SetMood (BabyController.Mood.horrified);
		}
			
		// Dropped or thrown away?
		if (false) {
		}

		// Wrong angle?
        float angle = head.transform.rotation.eulerAngles.x;
        if (!(angle > 240 && angle < 300))
        {
			babyController.SubtractHealth (1);
            babyController.SetMood(BabyController.Mood.frown);
        }
        
        // Won Game?
        if (babyOnCrib)
        {
            GameWon ();
        }

	}

    public void GrabBaby(int change)
    {
        Debug.Log("Grab method called, num of hands: " + this.handsOnBaby);
        this.handsOnBaby += change;
    }

    public void GameOver()
    {
        Debug.Log("LOST!!!");
    }

    public void GameWon ()
    {
        Debug.Log("WON!!!");
    }

    public void StartGame ()
    {
        refreshVariables();
    }

    public GameObject sceneObject;
    public GameObject prefabToRespon;

    private GameObject objectToRespon;
    private string sceneObjectName;

    public void Respone ()
    {
        Debug.Log("Pressed");
        if (firsttime == 0)
        {
            findObjectInSceneAndDelete();
            objectToRespon = Instantiate(prefabToRespon);
            firsttime++;
        }

        else
        {
            Destroy(objectToRespon);
            objectToRespon = Instantiate(prefabToRespon);
        }

        StartGame ();
    }

    private void findObjectInSceneAndDelete()
    {
        //GameObject sceneObject = GameObject.Find(sceneObjectName);
        Destroy(sceneObject);
    }
}