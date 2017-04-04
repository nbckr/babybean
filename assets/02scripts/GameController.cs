using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public float velocityFunny = 0.4f;
	public float velocityTooFast = 0.8f;

    private GameObject baby;
    private BabyController babyController;
    private GameObject head;
	private Rigidbody headRB;

    // Use this for initialization
    void Start () {
        baby = GameObject.FindGameObjectWithTag("Baby");
        head = GameObject.FindGameObjectWithTag("Head");
		headRB = head.GetComponent<Rigidbody>();
        babyController = baby.GetComponent<BabyController> ();	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (">> " + headRB.velocity.magnitude);

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

	}

    public void GameOver()
    { }

    public void StartGame ()
    {
        Start ();
    }
}