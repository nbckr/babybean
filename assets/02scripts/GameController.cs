using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private GameObject baby;
    private BabyController babyController;
    private GameObject head;



    // Use this for initialization
    void Start () {
        baby = GameObject.FindGameObjectWithTag("Baby");
        head = GameObject.FindGameObjectWithTag("Head");
        babyController = baby.GetComponent<BabyController> ();	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Hallo " + head.transform.rotation.eulerAngles.x);

        float angle = head.transform.rotation.eulerAngles.x;
        if (!(angle > 240 && angle < 300))
        {
            Debug.Log("Hallo " + head.transform.rotation.eulerAngles.x);
            babyController.SetMood(BabyController.Mood.shocked);
        }

	}

    public void GameOver()
    { }

    public void StartGame ()
    {
        Start ();
    }
}