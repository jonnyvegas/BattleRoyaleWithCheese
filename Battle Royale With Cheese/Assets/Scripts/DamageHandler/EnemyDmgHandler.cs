using UnityEngine;


public class EnemyDmgHandler : MonoBehaviour, IDamageHandler
{
    public void HandleDamage(float amt, GameObject gameObj)
    {
        // enemies likely face player when attacked.
        if (gameObj.TryGetComponent(out ICharacterHealth charHealth))
        {
            charHealth.ReduceHealth(amt);
        }
        Debug.Log("Handling enemy damage");
    }
}
