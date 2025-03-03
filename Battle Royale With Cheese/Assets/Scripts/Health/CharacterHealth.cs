using UnityEngine;

public interface ICharacterHealth
{
    public void ReduceHealth(float amtToReduce);
}
public class CharacterHealth : MonoBehaviour, ICharacterHealth
{
    private float _health = 100f;
    public float maxHealth = 100f;

    private IRespondToZeroHealth respondToZeroHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    virtual public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth(float amtToReduce)
    {
        _health -= amtToReduce;
        ClampHealth();
        if( _health <= 0.0f )
        {
            respondToZeroHealth.ZeroHealthResponse(this.gameObject);
        }
    }

    void IncreaseHealth(float amtToIncrease)
    {
        _health += amtToIncrease;
        ClampHealth();
    }

    void ClampHealth()
    {
        Mathf.Clamp(_health, 0.0f, maxHealth);
    }

    public void SetRespondToZeroHealth(IRespondToZeroHealth respondToZeroHealthNew)
    {
        this.respondToZeroHealth = respondToZeroHealthNew;
    }

}
