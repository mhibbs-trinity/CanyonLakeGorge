using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaycastToButtons : MonoBehaviour {

    public LayerMask hittable;
    public string aimedButtonName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, hittable)) {
            aimedButtonName = hit.transform.gameObject.name;
            bool select = false;
            if(Input.GetMouseButtonDown(0)) {
                select = true;
            }
            if(Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Ended) {
                    select = true;
                }
            }

            if (select) {
                Debug.Log(aimedButtonName);
                SceneManager.LoadScene(aimedButtonName);
                Debug.Log("after the load scene");
            }
        } else {
            aimedButtonName = "";
        }

	}
}
