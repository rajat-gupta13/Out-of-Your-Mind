using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShutdownText : MonoBehaviour {
    private Text shutdownText;
    private bool fadeIn;

	// Use this for initialization
	void Start () {
        shutdownText = GetComponent<Text>();
        fadeIn = false;
	}
	
	// Update is called once per frame
	void Update () {
        shutdownText.color = Color.Lerp(new Color(1f, 0f, 0f, 0f), Color.red, Mathf.PingPong(Time.time, 1f));
	}
}
