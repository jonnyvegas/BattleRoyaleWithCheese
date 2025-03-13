using UnityEngine;

public interface IPlayerObjectRefs
{
    GameObject GetSceneManager();
}
public class PlayerObjectRefs : MonoBehaviour, IPlayerObjectRefs
{
    public GameObject SceneManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetSceneManager()
    {
        return SceneManager;
    }
}
