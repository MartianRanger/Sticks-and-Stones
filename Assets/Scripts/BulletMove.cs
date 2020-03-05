using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * 100;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
