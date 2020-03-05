using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStarter : MonoBehaviour {

    public float speed;
    Vector2 primaryAxis;
    public Rigidbody player;
    void Start () {
        player = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update () {
        primaryAxis += OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Debug.Log(primaryAxis.ToString());
        Vector3 newPos = new Vector3(primaryAxis.x, 0, primaryAxis.y);
        //Debug.Log("newPos = " + newPos.ToString());
        transform.position = newPos;
        Vector3 yVelFix = new Vector3(0, player.velocity.y, 0);
        player.velocity += yVelFix;

    }
}
