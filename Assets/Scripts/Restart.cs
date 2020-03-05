using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick) && OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
        {
            SceneManager.LoadScene("VRMain");

        }

    }
}
