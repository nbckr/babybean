using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakJoint : MonoBehaviour {
    //private CharacterJoint charJ;
    private BabyController babyController;

    // Use this for initialization
    void Start () {
        //charJ = GetComponent<CharacterJoint>();
        babyController = GetComponentInParent<BabyController>();
    }

    void OnJointBreak(float breakForce)
    {
        Debug.Log(this.name + ": Joint broken!, force: " + breakForce);
        babyController.Die ();
    }
}