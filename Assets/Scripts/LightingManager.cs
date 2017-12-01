using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ETC.Platforms;

public class LightingManager : MonoBehaviour {

    /// <summary>
    /// Set this Editor property to the value of the DMX controller's COM port.
    /// <example>COM22</example>
    /// </summary>
    public string ComPort;

    /// <summary>
    /// Instance of the DMX class used to control the lights.
    /// </summary>
    private DMX dmx;
 

    // Use this for initialization
    void Start () {
        this.dmx = new DMX(this.ComPort);

        this.SetColor(Color.black);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetColor(Color color)
    {
        int deviceID = 1;

        //this.GetComponent<Camera>().backgroundColor = color;
        this.dmx.Channels[deviceID + 0] = (byte)(255);
        this.dmx.Channels[deviceID + 1] = (byte)(255);

        this.dmx.Channels[deviceID + 2] = (byte)(Mathf.FloorToInt(255f * color.r));
        this.dmx.Channels[deviceID + 3] = (byte)(Mathf.FloorToInt(255f * color.g));
        this.dmx.Channels[deviceID + 4] = (byte)(Mathf.FloorToInt(255f * color.b));
        this.dmx.Send();
    }
}
