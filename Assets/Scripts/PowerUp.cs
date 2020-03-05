using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public string type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(Time.deltaTime * 50, 0, 0));
	}

    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup(other);
            other.GetComponent<Health>().currentHealth += 25;
        }
    }
    void Pickup(Collider player)
    {
        Destroy(gameObject);
    }
}
