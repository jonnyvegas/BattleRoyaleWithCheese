using UnityEngine;

public class PlayerDmgHandler : MonoBehaviour, IDamageHandler
{
    public void HandleDamage(float amt, GameObject gameObj)
    {
        ICharacterHealth charHealth = gameObj.GetComponentInParent<ICharacterHealth>();
        if (charHealth != null )
        {
            charHealth.ReduceHealth(amt);
        }
        // shake screen or something. let player know direction from which hit and translate into where dmg comes from.
//         if (gameObj.TryGetComponent(out ICharacterHealth charHealth))
//         {
//             charHealth.ReduceHealth(amt);
//         }
        Debug.Log("Handling damage in player damage handler");
    }
}