using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    CharacterController controller;

    float directionToFace = 0;
    Coroutine DirectionMovementCoroutine;

    public float directionChangeInterval = 1f;
    public float maxDirectionChange = 30f;
    Vector3 targetDirection = Vector3.zero;

    public float speed = 1f;
    void Awake()
    {
        // Init controller.
        controller = GetComponent<CharacterController>();
        directionToFace = Random.Range(0f, 360f);
        // only want to face around yaw/Y axis.
        this.transform.eulerAngles = new Vector3(0, directionToFace, 0);
        // begin check for new direction to face.
        DirectionMovementCoroutine = StartCoroutine(NewDirection());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // as we get a new direction to face, want to lerp.
        this.transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetDirection,
                                        Time.deltaTime * directionChangeInterval);
        // get a forward vector from local to world space for (0, 0, 1).
        Vector3 forwardVector = transform.TransformDirection(Vector3.forward);
        // move in that direction over time.
        controller.SimpleMove(forwardVector * speed);
    }

    private IEnumerator NewDirection()
    {
        while (true)
        {
            NewDirectionRoutine();
            // get a new direction every so often.

                yield return new WaitForSeconds(directionChangeInterval);
        }
        yield return null;
    }

    void NewDirectionRoutine()
    {
        // between the direction - directionChange and direction + directionChange
        float floor = Mathf.Clamp(directionToFace - maxDirectionChange, 0f, 360f);
        float ceiling = Mathf.Clamp(directionToFace + maxDirectionChange, 0f, 360f);
        directionToFace = Random.Range(floor, ceiling);
        // set the new target direction to be used in Update to lerp to the new direction to face.
        targetDirection = new Vector3(0, directionToFace, 0);

    }
}
