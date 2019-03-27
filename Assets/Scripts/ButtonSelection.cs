using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSelection : MonoBehaviour {

    RaycastToButtons caster;
    Text textLabel;

	// Use this for initialization
	void Start () {
        caster = GameObject.Find("RaycastController").GetComponent<RaycastToButtons>();
        textLabel = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if(caster.aimedButtonName == gameObject.name) {
            textLabel.color = Color.red;
        } else {
            textLabel.color = Color.black;
        }

	}

}
