using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public Transform bottom;
    public Transform top;

    public float doorSpeed = 2f;
	// Use this for initialization
	void Start () {

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            StopCoroutine("CloseDoor");
            StartCoroutine("OpenDoor");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("CloseDoor");
            StopCoroutine("OpenDoor");
        }
    }
    IEnumerator OpenDoor()
    {
        while(Vector3.Distance (transform.position, top.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, top.position, doorSpeed * Time.deltaTime);

            yield return null;
        }
    }
    IEnumerator CloseDoor()
    {
        while (Vector3.Distance(transform.position, bottom.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, bottom.position, doorSpeed * Time.deltaTime);

            yield return null;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
