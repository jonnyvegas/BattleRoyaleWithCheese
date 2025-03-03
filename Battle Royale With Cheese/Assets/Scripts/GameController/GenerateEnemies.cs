using System.Collections;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    // some game object to represent the enemy.
    public GameObject TheEnemy;
    public Transform GroundTransform;
    public MeshCollider GroundMeshCollider;
    public CapsuleCollider EnemyCapsule;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CreateEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int numEnemiesCreated = 0;
    
    IEnumerator CreateEnemies()
    {
        int numOfEnemies = 10;
        float xExtents = GroundMeshCollider.bounds.extents.x;
        float zExtents = GroundMeshCollider.bounds.extents.z;
        float xPosition = 0.0f;
        float yPosition = GroundTransform.position.y + (TheEnemy.GetComponentInChildren<CapsuleCollider>().height / 4);
        float zPosition = 0.0f;
        while (numEnemiesCreated < numOfEnemies)
        {
            xPosition = Random.Range(GroundTransform.position.x - xExtents, 
                                     GroundTransform.position.x + xExtents);
            zPosition = Random.Range(GroundTransform.position.z - zExtents, 
                                     GroundTransform.position.z + zExtents);
            Instantiate(TheEnemy, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);
            numEnemiesCreated++;

            yield return new WaitForSeconds(0.1f);
            
            
        }
        
        
    }
}
