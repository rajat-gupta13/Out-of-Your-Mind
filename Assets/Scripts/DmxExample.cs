using UnityEngine;
using System.Collections;
using ETC.Platforms;

public class DmxExample : MonoBehaviour
{
    private DMX dmx;


    void Start()
    {
        this.dmx = new DMX("COM3");
        this.dmx.Channels[1] = 44;
        this.dmx.Channels[2] = 44;
        this.dmx.Channels[3] = 44;
        this.dmx.Send();
    }
}