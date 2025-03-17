using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;


public class GroundShrink : MonoBehaviour
{
    //public GameObject theGround;
    private Vector3 GroundScale;
    private float ShrinkRate = 1f;
    public float ScaleChange = 1f;
    public float MinScale = 1f;
    public float ShrinkFreq = 0.5f;
    //private Vector3 NewGroundScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GroundScale = gameObject.transform.localScale;
        StartCoroutine(ShrinkGround());
        //Debug.Log("Ground scale: " + GroundScale);

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = Vector3.Slerp(gameObject.transform.localScale, GroundScale, Time.deltaTime * ShrinkRate);
    }

    public IEnumerator ShrinkGround()
    {
        while (GroundScale.x > MinScale)
        {
            GroundScale.x = GroundScale.x - ScaleChange;
            GroundScale.z = GroundScale.z - ScaleChange;
            yield return new WaitForSeconds(ShrinkFreq);
        }
        //yield return null;
    }
}
