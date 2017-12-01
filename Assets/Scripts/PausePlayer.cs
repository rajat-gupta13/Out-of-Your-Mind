using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Virtuix;

public class PausePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<OmniController>().enabled = false;
        }
    }
}
