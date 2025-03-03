using System;
using UnityEngine;


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
        if(theGameObject.TryGetComponent(out IPlayerLives playerLives))
        {
            playerLives.ReduceLives();
            if(playerLives.CheckIfDead())
            {
                Debug.Log("game over, reset");
            }
            else
            {
                Debug.Log("Reset level");
            }
        }
    }
}

// TODO: Move to another class. These need to be separated properly.


