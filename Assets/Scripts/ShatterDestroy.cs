using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterDestroy : MonoBehaviour {

    // Use this for initialization
    public GameObject shatterMesh;
	void Start () {
        StartCoroutine(DestroyShatter(this.gameObject));
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private IEnumerator DestroyShatter(GameObject shatter)
    {
        yield return new WaitForSeconds(5f);
        Destroy(shatterMesh);
    }
}
