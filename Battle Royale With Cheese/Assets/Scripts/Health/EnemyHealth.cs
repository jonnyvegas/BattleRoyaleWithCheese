using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : CharacterHealth
{
    public override void Start()
    {
        SetRespondToZeroHealth(new EnemyRespondZeroHealth());
        base.Start();
    }
}
