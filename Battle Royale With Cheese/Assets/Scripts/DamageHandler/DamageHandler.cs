using UnityEngine;

public interface IDamageHandler
{
    void HandleDamage(float amt, GameObject gameObj);
}
public class CharacterDamageHandler : MonoBehaviour, IDamageHandler
{
    public void HandleDamage(float amt, GameObject gameObj)
    {
        if (gameObj.TryGetComponent(out CharacterHealth charHealth))
        {
            charHealth.ReduceHealth(amt);
        }
    }
}


