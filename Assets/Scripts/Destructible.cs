using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public GameObject current, shatter;

    public void DestroyShatter(GameObject laser) {
        StartCoroutine(laser.GetComponent<LaserBehavior>().DestroyDestructible(current, shatter));
    }
}
