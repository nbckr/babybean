using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

    public GameController gameController;
	
	private SteamVR_TrackedObject trackedObj;
	private GameObject collidingObject; 
	private GameObject objectInHand;

	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	private void SetCollidingObject(Collider col)
	{
		if (collidingObject || !col.GetComponent<Rigidbody>())
		{
			return;
		}
		collidingObject = col.gameObject;
	}

	private void GrabObject()
	{
		objectInHand = collidingObject;
		collidingObject = null;

		var joint = AddFixedJoint();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

        Animator objectAnim = objectInHand.GetComponent<Animator>();
        if (objectAnim != null)
        {
            objectAnim.applyRootMotion = false;
            Debug.Log("anime!!!!! : " + objectAnim.applyRootMotion);
        }

        if (true) //(objectInHand.transform.parent.CompareTag("Baby"))
        {
            Debug.Log("Controller grabbed: " + this.name);
            this.gameController.GrabBaby(1);
        }
	}

	private FixedJoint AddFixedJoint()
	{
		FixedJoint fx = gameObject.AddComponent<FixedJoint>();
		//fx.breakForce = 20000;
		//fx.breakTorque = 20000;
        fx.breakForce = 10000;
        fx.breakTorque = 10000;
        return fx;
	}

	private void ReleaseObject()
	{
		if (GetComponent<FixedJoint>())
		{
			GetComponent<FixedJoint>().connectedBody = null;
			Destroy(GetComponent<FixedJoint>());

			objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
			objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
		}

        if (true) //(objectInHand.transform.parent.CompareTag("Baby"))
        {
            gameController.GrabBaby(-1);
        }

        objectInHand = null;
    }

    void Update () {
		if (Controller.GetHairTriggerDown())
		{
			if (collidingObject)
			{
				GrabObject();
			}
		}

		if (Controller.GetHairTriggerUp())
		{
			if (objectInHand)
			{
				ReleaseObject();
			}
		}

        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            gameController.Respone();
        }
	}
		
	public void OnTriggerEnter(Collider other)
	{
		SetCollidingObject(other);
	}
		
	public void OnTriggerStay(Collider other)
	{
		SetCollidingObject(other);
	}

	public void OnTriggerExit(Collider other)
	{
		if (!collidingObject)
		{
			return;
		}

		collidingObject = null;
	}
}
