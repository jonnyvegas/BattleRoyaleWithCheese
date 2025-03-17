using UnityEngine;
using UnityEngine.Rendering.Universal;

public class KillZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Something entered collision");
        if(collision.gameObject.TryGetComponent(out ICharacterHealth health))
        {
            health.ReduceHealth(1000.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ICharacterHealth health))
        {
            health.ReduceHealth(1000.0f);
        }
    }

}
