using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTracker : MonoBehaviour {

    public GameObject laserPrefab;
    //public GameObject laserSpawn;

    private static FoveInterface2 _fove;


    void Awake()
    {
        if (_fove == null)
        {
            _fove = FindObjectOfType(typeof(FoveInterface2)) as FoveInterface2;
            if (_fove == null)
            {
                Debug.LogError("No FoveInterface2 object found in the scene! :");
                return;
            }
        }
    }

        // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      
    }
}
