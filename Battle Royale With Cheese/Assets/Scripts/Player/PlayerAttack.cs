using System;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public ParticleSystem bulletPartcileSys;
    private ParticleSystem.EmissionModule emModule;

    float attackTimer = 0f;
    public float baseDamage = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        emModule = bulletPartcileSys.emission;
    }

    private float _fireRate = 10f;
    // Update is called once per frame
    void Update()
    {
        float fireButton = Input.GetAxis("Fire1");

        attackTimer += Time.deltaTime;

        if(attackTimer >= 1f/_fireRate && fireButton != 0)
        {
            attackTimer = 0f;
            Attack();
        }

        emModule.rateOverTime = fireButton != 0 ? _fireRate : 0f;
    }

    void Attack()
    {
        
        Ray theRay = new Ray(bulletPartcileSys.transform.position, bulletPartcileSys.transform.forward);
        RaycastHit theHit;
        if(Physics.Raycast(theRay, out theHit, 1000.0f))
        {
            IDamageHandler dmgHandler = theHit.collider.GetComponentInParent<IDamageHandler>();
            if (dmgHandler != null)
            {
               dmgHandler.HandleDamage(baseDamage, theHit.collider.gameObject);
               Debug.Log("hit success");
               // healthResponse.RespondToDamage(baseDamage, theHit.collider.gameObject);
            }
            else
            {
                Debug.Log("Failed to get component.");
            }
            
        }
       

 
        // Check for collision. Reduce health.

        //theRay.
    }
}
