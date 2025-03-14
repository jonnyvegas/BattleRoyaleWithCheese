using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public ParticleSystem bulletParticleSystem;
    public float TimeBetweenAttacks = 0.5f;
    private ParticleSystem.EmissionModule em;
    private int RaycastLength = 10;
    private float FiringRate = 10f;
    private bool CanAttack = true;
    private Coroutine CoroutineTimer;
    private float currentTime = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        em = bulletParticleSystem.emission;
        CoroutineTimer = StartCoroutine(BeginTimer());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, forward, out RaycastHit HitInfo, RaycastLength))
        {
            //Debug.Log("raycasting hit something " + HitInfo.collider.transform.gameObject.name);
            if (CanAttack)
            {
                Attack();
                StopCoroutine(CoroutineTimer);
                CanAttack = false;
                CoroutineTimer = StartCoroutine(BeginTimer());
            }
            em.rateOverTime = FiringRate;
        }
        else
        {
            em.rateOverTime = 0f;
        }
    }

    void Attack()
    {
        Ray ray = new Ray(bulletParticleSystem.transform.position, bulletParticleSystem.transform.forward);
        float rayLength = 100f;
        if(Physics.Raycast(ray, out RaycastHit hitInfo, rayLength))
        {
            //if(hitInfo.collider.TryGetComponent(out IDamageHandler dmgHandler))
            //{
            //    dmgHandler.HandleDamage(10f, hitInfo.collider.gameObject);
            //    Debug.Log("Found damage handler on collider. handling damage.");
            //}
            if(hitInfo.collider.gameObject.TryGetComponent(out IDamageHandler damageHandler))
            {
                damageHandler.HandleDamage(10f, hitInfo.collider.gameObject);
                Debug.Log("Found damage handler on parent somewhere. handling damage");
            }
            else
            {
                Debug.Log("Did not find damage handler");
            }
                Debug.Log("attack " + hitInfo.collider.gameObject.name);

        }
        else
        {
            Debug.Log("Attack raycast hit nothing.");
        }
    }

    private IEnumerator BeginTimer()
    {
        currentTime += Time.deltaTime;
        if(currentTime > TimeBetweenAttacks)
        {
            CanAttack = true;
            currentTime = 0f;
        }
        yield return null;
    }
}
