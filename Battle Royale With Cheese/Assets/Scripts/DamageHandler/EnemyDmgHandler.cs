using UnityEngine;


public class EnemyDmgHandler : MonoBehaviour, IDamageHandler
{
    public void HandleDamage(float amt, GameObject gameObj)
    {
        // enemies likely face player when attacked.
        if (gameObj.transform.parent.TryGetComponent(out ICharacterHealth charHealth))
        {
            charHealth.ReduceHealth(amt);
        }
        else
        {
            Debug.Log("failed to get charHealth");
        }
        Debug.Log("Handling enemy damage");
    }
}
