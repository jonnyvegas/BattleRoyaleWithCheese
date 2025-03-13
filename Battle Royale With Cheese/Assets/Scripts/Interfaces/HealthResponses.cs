using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public interface IRespondToZeroHealth
{
    void ZeroHealthResponse(GameObject theGameObject);
}

public class EnemyRespondZeroHealth : IRespondToZeroHealth
{
    public void ZeroHealthResponse(GameObject theGameObject) 
    { 
        Debug.Log("Responding to zero health from enemy"); 
        theGameObject.SetActive(false);
    }
}

public class PlayerRespondZeroHealth : IRespondToZeroHealth
{
    public void ZeroHealthResponse(GameObject theGameObject)
    {
        Debug.Log("Responding to zero health from Player");
        if (theGameObject.TryGetComponent(out IPlayerObjectRefs theObject))
        {
            if(theObject.GetSceneManager().TryGetComponent(out ISceneManager sceneManager))
            {
                if(sceneManager != null)
                {
                    sceneManager.ReloadCurrentScene();
                }
            }
            else
            {
                Debug.Log("object valid from IPlayerObectRefs but ISceneNames was not valid - ZeroHealthResponse");
            }
        }
        else
        {
            Debug.Log("Did not get IPlayerObjectRefs from ZeroHealthResponse GameObject passed");
        }
        //if(theGameObject.TryGetComponent(out IPlayerLives playerLives))
        //{
        //    playerLives.ReduceLives();
        //    if(playerLives.CheckIfDead())
        //    {
        //        Debug.Log("game over, reset");
        //    }
        //    else
        //    {
        //        Debug.Log("Reset level");
        //    }
        //}
    }
}

// TODO: Move to another class. These need to be separated properly.


