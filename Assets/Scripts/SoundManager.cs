using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    public AudioSource bGM, sFX, bGM1;
    public AudioClip gameShowBGM, prizeMusicBGM, commercialBGM, gameTensionBGM, dubstepBGM, endingBGM, contestantBGM, pyramidGameBGM;
    public AudioClip oohSFX, aahSFX, cashRegisterSFX, laserGunSFX, pluginSFX, simulationEndingSFX, tromboneSFX, correctAnswerSFX, 
                    endRoundSFX, wrongAnswerSFX, mazeDoorSFX, applauseSFX, laughterSFX;

    public GameObject lightingManager, player, maze, ramps, mainCamera, canvas, alexVid;
    public float subtractor = 1;
    //private LightingManager lightManager;


    // Use this for initialization
    void Start () {
        
  
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            bGM.volume -= subtractor * Time.deltaTime;
            bGM1.volume -= subtractor * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            bGM.volume = 1;
            bGM1.volume = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            bGM.Stop();
            bGM1.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Debug.Log("Play Game Show BGM");
            bGM.clip = gameShowBGM;
            bGM.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.Log("Play Prize Music BGM");
            bGM.clip = prizeMusicBGM;
            bGM.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("Play Commercial BGM");
            bGM.clip = commercialBGM;
            bGM.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Debug.Log("Play Game Show Tension BGM");
            bGM1.clip = gameTensionBGM;
            bGM1.Play();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Play Contestant Music");
            bGM.clip = contestantBGM;
            bGM.Play();
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("power surge SFX");
            sFX.clip = pluginSFX;
            sFX.Play();
            bGM1.Stop();
            StartCoroutine(StartGame());
        }

        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Debug.Log("ooh SFX");
            sFX.clip = oohSFX;
            sFX.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Debug.Log("aah SFX");
            sFX.clip = aahSFX;
            sFX.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            Debug.Log("cha-ching SFX");
            sFX.clip = cashRegisterSFX;
            sFX.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            Debug.Log("laser gun SFX");
            sFX.clip = laserGunSFX;
            sFX.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            Debug.Log("sad trombone SFX");
            sFX.clip = tromboneSFX;
            sFX.Play();
        }

        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            Debug.Log("Play Ending BGM");
            mainCamera.SetActive(true);
            canvas.SetActive(true);
            player.SetActive(false);
            maze.SetActive(false);
            ramps.SetActive(false);
            alexVid.SetActive(false);
            bGM.clip = endingBGM;
            bGM.Play();
            bGM1.Stop();
            sFX.Stop();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("wrong answer SFX");
            sFX.clip = wrongAnswerSFX;
            sFX.Play();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("applause SFX");
            sFX.clip = applauseSFX;
            sFX.Play();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("laughter SFX");
            sFX.clip = laughterSFX;
            sFX.Play();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Play Alex's Adventure Video");
            sFX.Stop();
            bGM.Stop();
            bGM1.Stop();
            player.SetActive(false);
            alexVid.SetActive(true);
            MovieTexture mt = alexVid.GetComponent<RawImage>().texture as MovieTexture;
            mt.Play();
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2f);
        mainCamera.SetActive(false);
        canvas.SetActive(false);
        player.SetActive(true);
        maze.SetActive(true);
        ramps.SetActive(true);
        Debug.Log("Play Dubstep BGM");
        bGM1.clip = dubstepBGM;
        bGM1.Play();
    }
}
