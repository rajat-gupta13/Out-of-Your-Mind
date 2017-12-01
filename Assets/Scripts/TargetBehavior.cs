using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetBehavior : MonoBehaviour {

    public float laserDistance;
    public Image target;
    public Sprite[] target_sprites; // 0 is normal, 1 is red

    private Camera playerCam;

	// Use this for initialization
	void Start () {
        playerCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, playerCam.transform.forward, out hit, laserDistance)) {
            if (hit.collider.gameObject.tag == "OuterWheel" && MazeChanger.outer > 0)
            {
                target.sprite = target_sprites[1];
                MazeChanger.outerRing = true;
                MazeChanger.middleRing = false;
                MazeChanger.innerRing = false;
            }
            else if (hit.collider.gameObject.tag == "MiddleWheel" && MazeChanger.middle > 0)
            {
                target.sprite = target_sprites[1];
                MazeChanger.outerRing = false;
                MazeChanger.middleRing = true;
                MazeChanger.innerRing = false;
            }
            else if (hit.collider.gameObject.tag == "InnerWheel" && MazeChanger.inner > 0)
            {
                target.sprite = target_sprites[1];
                MazeChanger.outerRing = false;
                MazeChanger.middleRing = false;
                MazeChanger.innerRing = true;
            }
            else if (hit.collider.gameObject.tag == "TrenchCube")
            {
                target.sprite = target_sprites[1];
                MazeChanger.trenchCube = true;
            }
            else if (hit.collider.gameObject.tag == "DiscoCube")
            {
                target.sprite = target_sprites[1];
                MazeChanger.discoCube = true;
            }
            else
            {
                target.sprite = target_sprites[0];
            }


        } else {
            target.sprite = target_sprites[0];
            MazeChanger.outerRing = false;
            MazeChanger.middleRing = false;
            MazeChanger.innerRing = false;
            MazeChanger.trenchCube = false;
            MazeChanger.discoCube = false;
        }
	}
}
