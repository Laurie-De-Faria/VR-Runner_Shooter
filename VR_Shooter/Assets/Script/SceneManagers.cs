using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagers : MonoBehaviour {

#if UNITY_WEBPLAYER
        public static string webplayerQuitURL = "http://google.com";
#endif

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Scene_Start()
    {
        SceneManager.LoadScene(1);
    }

    public void Scene_Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit_Simulation()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
        Application.Quit();
#endif
    }
}
