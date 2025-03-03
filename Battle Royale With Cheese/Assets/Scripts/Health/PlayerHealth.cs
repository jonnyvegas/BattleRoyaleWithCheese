using UnityEngine;

public class PlayerHealth : CharacterHealth
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        SetRespondToZeroHealth(new PlayerRespondZeroHealth());
        base.Start();
    }

}
