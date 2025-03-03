using UnityEngine;

public interface IPlayerLives
{
    bool CheckIfDead();
    int GetNumLives();
    void ReduceLives();
    void ResetLives();
}

public class PlayerLives : MonoBehaviour, IPlayerLives
{
    int numLives = 3;

    public bool CheckIfDead()
    {
        return numLives > 0;
    }

    public int GetNumLives()
    {
        return numLives;
    }

    public void ReduceLives()
    {
        numLives--;
    }
   
    public void ResetLives()
    {
        numLives = 3;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
