using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ISceneManager
{
    String GetStartScene();
    void ReloadCurrentScene();
}

public class SceneManager : MonoBehaviour, ISceneManager
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
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
