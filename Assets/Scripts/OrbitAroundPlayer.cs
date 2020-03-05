using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundPlayer : MonoBehaviour
{
    public float speed;
    public Vector3 originPoint;

    // Start is called before the first frame update
    void Start()
    {
        originPoint = new Vector3(0.0f, 0.0f, 0.0f);
        speed = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(originPoint, Vector3.up, speed * Time.deltaTime);
    }
}
