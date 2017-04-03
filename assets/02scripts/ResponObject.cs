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

    void Start()
    {
        sceneObjectName = sceneObject.name;
    }

    void Update () {
        if (Input.GetKey(key))
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