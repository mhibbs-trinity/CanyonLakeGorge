using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changingscenes : MonoBehaviour {
    public string backScene;
    public string forwardScene;
    public static bool created = false;
    public bool sceneSelect = false;

    private float timer;
    public float gazeTime = 2f;
    private bool gazedAt;
    public string scene;
	// Use this for initialization
	void Start () {
		
	}

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }

    public void LoadScene(string scene)
    {
        if (SceneManager.GetActiveScene().name == "vid0")
        {
            if (scene == "backScene")
            {
                sceneSelect = true;
                SceneManager.LoadScene("sceneSelect", LoadSceneMode.Single);
            }
            else if (scene == "forwardScene")
            {
                sceneSelect = false;
                SceneManager.LoadScene("vid1", LoadSceneMode.Single);
            }
        }
        if (SceneManager.GetActiveScene().name == "vid31")
        {

             if (scene == "forwardScene")
            {
                SceneManager.LoadScene("vid0", LoadSceneMode.Single);
            }
        }

        if(sceneSelect){
           if (SceneManager.GetActiveScene().name == "sceneSelect")
            {  /*
                //back
                //forward
                //F I X !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (gazedAt)
                {
                    timer += Time.deltaTime;

                    if (timer >= gazeTime)
                    {
                        SceneManager.LoadScene(scene);
                    }
                }*/

            }
            else
            {
                //We're in a vid
                if (scene == "backScene")
                {
                    SceneManager.LoadScene("sceneSelect", LoadSceneMode.Single);
                }
                else if (scene == "forwardScene")
                {
                    SceneManager.LoadScene("sceneSelect", LoadSceneMode.Single);
                }
            }
        }
        else{
            //We're playing all the videos 
            string currentVid = SceneManager.GetActiveScene().name;
            string num = "";
            if(currentVid.Length > 4){
                 num = currentVid.Substring(3, 2);
            }
            else {
                num = currentVid.Substring(3, 1);
            }
            int vidNum = int.Parse(num);
            if(scene == "backScene"){
                SceneManager.LoadScene("vid"+((vidNum-1).ToString()), LoadSceneMode.Single);
            }
            else if (scene == "forwardScene")
            {
                SceneManager.LoadScene("vid" + ((vidNum + 1).ToString()), LoadSceneMode.Single);
            }

        }
       
   }
	
	// Update is called once per frame
	void Update () {

        //if (Input.touchCount == 1 || Input.anyKeyDown)
        {
           // var touch = Input.touches[0];
            if (/*touch.position.x < Screen.width / 2 ||*/ Input.GetKeyDown(KeyCode.B)) // left side
            {
                LoadScene("backScene");
            }
            else if (/*touch.position.x > Screen.width / 2 ||*/ Input.GetKeyDown(KeyCode.F)) // right side
            {
                LoadScene("forwardScene");
            }
        }
	}

    public void PointerEnter()
    {
        gazedAt = true;
    }

    public void PointerExit()
    {
        gazedAt = false;
    }
}
