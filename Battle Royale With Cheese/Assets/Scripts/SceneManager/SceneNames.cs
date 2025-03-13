using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ISceneNames
{
    String GetStartScene();
}

public class SceneNames : MonoBehaviour, ISceneNames
{
    public String StartSceneName = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public String GetStartScene()
    { 
        return StartSceneName; 
    }
}
