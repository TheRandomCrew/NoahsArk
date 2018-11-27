using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UploadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SceneToUpload(string Name_scene_Upload)
    {
        SceneManager.LoadScene(Name_scene_Upload);
    }
}
