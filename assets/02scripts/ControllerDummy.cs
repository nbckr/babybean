using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDummy : MonoBehaviour {
    public float breakForceValue;
    public float breakTorqueValue;

    private Rigidbody rb;
    private float force = 40f;
    private GameObject collidingObject;
    private GameObject objectInHand;

    void Start()
    {
        breakForceValue = 10000f;
        breakTorqueValue = 10000f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (collidingObject)
            {
                GrabObject();
                logComponent("GrabObjekt: " + objectInHand.name);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (objectInHand)
            {
                ReleaseObject();
                logComponent("ReleaseObjekt:" + objectInHand.name);
            }
        }
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            //addforceForThrowing();
        }
    }

    private void addforceForThrowing()
    {
        objectInHand.GetComponent<Rigidbody>().velocity = new Vector3(1,1,1);
        objectInHand.GetComponent<Rigidbody>().angularVelocity = new Vector3(1, 1, 1);
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;

        AddFixedJoint();
    }

    private void AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = breakForceValue;
        fx.breakTorque = breakTorqueValue;
        fx.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //float h = Input.GetAxis("Horizontal") * Time.deltaTime;
        //float v = Input.GetAxis("Vertical") * Time.deltaTime;
        //float mH = Input.GetAxis("Mouse X") * horizontalMouseSpeed;
        //float mV = Input.GetAxis("Mouse Y") * verticalMouseSpeed;

        //rb.AddForce(transform.forward * force * mH , ForceMode.Force);
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
        //logComponent("triggerStay" + collidingObject.name);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }
        //logComponent("triggerExit");

        collidingObject = null;
    }


    private void SetCollidingObject(Collider collider)
    {
        if (!collider.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = collider.gameObject;
    }

    private void logComponent(string keyname)
    {
        Debug.Log(this.name + " : " + keyname);
    }
}