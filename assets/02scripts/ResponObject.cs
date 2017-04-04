using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponObject : MonoBehaviour {
    private const KeyCode key = KeyCode.LeftArrow;

    public GameObject prefabToRespon;
    public GameObject sceneObject;

    private string sceneObjectName;
    private GameObject objectToRespon;
    private int firsttime = 0;
    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


    void Start()
    {
        sceneObjectName = sceneObject.name;
    }

    void Update () {
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (firsttime == 0)
            {
                findObjectInSceneAndDelete();
                objectToRespon = Instantiate(prefabToRespon);
                firsttime++;
            } else
            {
                Destroy(objectToRespon);
                objectToRespon = Instantiate(prefabToRespon);
            }
            
            // Fals position sich zum ursprüglichen prefab ändern soll.
            //babyBean.SetActive(true);
            //babyBean.transform.position = new Vector3(0.94f, 5.6f, 0f);

            logComponent("ResponButton pressed " + key);
        }

    }

    private void findObjectInSceneAndDelete()
    {
        GameObject sceneObject = GameObject.Find(sceneObjectName);
        Destroy(sceneObject);
    }

    private void logComponent(string keyname)
    {
        Debug.Log(this.name + " : " + keyname);
    }
}