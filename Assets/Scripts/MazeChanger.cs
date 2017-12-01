using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Virtuix;

public class MazeChanger : MonoBehaviour
{
    private enum WheelColor
    {
        Red,
        Yellow,
        Purple,
        Green,
        Pink,
        Teal
    }

    private bool trenchDoor = false;
    private bool discoDoor = false;
    private bool vaultDoor = false;
    private bool outerLocked = false;
    private bool middleLocked = false;
    private bool innerLocked = false;
    private LightingManager lightManager;
    private Color[] lightColors = { Color.red, Color.green, Color.blue, new Color(1, 0.141f, 0.6035f, 1) };
    private int rowCounter = 1;
    private int colorCounter = 1;
    private bool discoColorCalled = false;
    private WheelColor currColor;
    private bool vaultColorSet = false;

    public static int outer = 2;
    public static int middle = 1;
    public static int inner = 3;
    public static bool outerRing = false;
    public static bool middleRing = false;
    public static bool innerRing = false;
    public static bool trenchCube = false;
    public static bool discoCube = false;

    public GameObject innerWheel, middleWheel, outerWheel;
    public GameObject[] set1, set2, set3, set4;
    public GameObject discoDoorCube;
    public Material blackMaterial;
    //public GameObject lightingManager;
    public Material[] materials; //0 is red, 1 is green, 2 is blue and 3 is pink.
    public SoundManager soundManager;
    public GameObject target;
    public GameObject shutdownText;
    public GameObject player;
    

    // Use this for initialization
    void Start()
    {
        //lightManager = lightingManager.GetComponent<LightingManager>();
        StartCoroutine(ColorSetter());
    }

    IEnumerator ColorSetter()
    {
        yield return new WaitForSeconds(0.5f);
        //lightManager.SetColor(Color.red);
    }

    IEnumerator DiscoColorChanger()
    {
        while (!discoDoor)
        {
            yield return new WaitForSeconds(0.5f);
            if (colorCounter % 4 == 1)
            {
                discoDoorCube.GetComponent<Renderer>().material = materials[0];
                //lightManager.SetColor(lightColors[0]);
                if (rowCounter % 4 == 1)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = materials[0];
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    rowCounter++;
                }
                else if (rowCounter % 4 == 2)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = materials[0];
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    rowCounter++;
                }
                else if (rowCounter % 4 == 3)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = materials[0];
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    rowCounter++;
                }
                else if (rowCounter % 4 == 0)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = materials[0];
                    }
                    rowCounter++;
                    colorCounter++;
                }
            }
            else if (colorCounter % 4 == 2)
            {
                discoDoorCube.GetComponent<Renderer>().material = materials[1];
                //lightManager.SetColor(lightColors[1]);
                if (rowCounter % 4 == 1)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = materials[1];
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    rowCounter++;
                }
                else if (rowCounter % 4 == 2)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = materials[1];
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    rowCounter++;
                }
                else if (rowCounter % 4 == 3)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = materials[1];
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    rowCounter++;
                }
                else if (rowCounter % 4 == 0)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = materials[1];
                    }
                    rowCounter++;
                    colorCounter++;
                }
            }
            else if (colorCounter % 4 == 3)
            {
                discoDoorCube.GetComponent<Renderer>().material = materials[2];
                //lightManager.SetColor(lightColors[2]);
                if (rowCounter % 4 == 1)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = materials[2];
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    rowCounter++;
                }
                else if (rowCounter % 4 == 2)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = materials[2];
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    rowCounter++;
                }
                else if (rowCounter % 4 == 3)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = materials[2];
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    rowCounter++;
                }
                else if (rowCounter % 4 == 0)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = materials[2];
                    }
                    rowCounter++;
                    colorCounter++;
                }
            }
            else if (colorCounter % 4 == 0)
            {
                discoDoorCube.GetComponent<Renderer>().material = materials[3];
                //lightManager.SetColor(lightColors[3]);
                if (rowCounter % 4 == 1)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = materials[3];
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    rowCounter++;
                }
                else if (rowCounter % 4 == 2)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = materials[3];
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    rowCounter++;
                }
                else if (rowCounter % 4 == 3)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = materials[3];
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    rowCounter++;
                }
                else if (rowCounter % 4 == 0)
                {
                    foreach (GameObject gO in set1)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set2)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set3)
                    {
                        gO.GetComponent<Renderer>().material = blackMaterial;
                    }
                    foreach (GameObject gO in set4)
                    {
                        gO.GetComponent<Renderer>().material = materials[3];
                    }
                    rowCounter++;
                    colorCounter++;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Cur color: " + currColor);
        if (!trenchDoor)
        {
            if (trenchCube)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    GetComponent<Animator>().SetBool("TrenchRoomOpen", true);
                    soundManager.sFX.clip = soundManager.mazeDoorSFX;
                    soundManager.sFX.Play();
                    trenchDoor = true;
                }
            }
            
        }
        else if (trenchDoor && !discoDoor)
        {
            if (!discoColorCalled)
            {
                StartCoroutine(DiscoColorChanger());
                discoColorCalled = true;
            }
            if (discoCube)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    GetComponent<Animator>().SetBool("DiscoRoomOpen", true);
                    soundManager.sFX.clip = soundManager.mazeDoorSFX;
                    soundManager.sFX.Play();
                    discoDoor = true;
                    //lightManager.SetColor(Color.yellow);
                }
            }
        }
        else if (trenchDoor && discoDoor && !vaultDoor)
        {
            //lightManager.SetColor(Color.yellow);
               
            if (outerWheel.transform.localEulerAngles == new Vector3(0f, 0f, 120f))
            {
                outerLocked = true;
            }

            if (middleWheel.transform.localEulerAngles == new Vector3(0f, 0f, 120f))
            {
                middleLocked = true;
            }

            if (innerWheel.transform.localEulerAngles == new Vector3(0f, 0f, 120f))
            {
                innerLocked = true;
            }

            if (outerRing && !outerLocked)
            {
                if (Input.GetKeyDown(KeyCode.W)) // pink
                {
                    if (currColor == WheelColor.Teal)
                    {
                        outerWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    } else if (currColor == WheelColor.Green)
                    {
                        outerWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.A)) // green
                {
                    if (currColor == WheelColor.Pink)
                    {
                        outerWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Purple)
                    {
                        outerWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.S)) // purple 
                {
                    if (currColor == WheelColor.Green)
                    {
                        outerWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Yellow)
                    {
                        outerWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.D)) // yellow
                {
                    if (currColor == WheelColor.Purple)
                    {
                        outerWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Red)
                    {
                        outerWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.F)) // red
                {
                    if (currColor == WheelColor.Yellow)
                    {
                        outerWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Teal)
                    {
                        outerWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.G)) // teal
                {
                    if (currColor == WheelColor.Red)
                    {
                        outerWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Pink)
                    {
                        outerWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
            }

            else if (middleRing && !middleLocked)
            {
                if (Input.GetKeyDown(KeyCode.W)) // pink
                {
                    if (currColor == WheelColor.Teal)
                    {
                        middleWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Green)
                    {
                        middleWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.A)) // green
                {
                    if (currColor == WheelColor.Pink)
                    {
                        middleWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Purple)
                    {
                        middleWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.S)) // purple 
                {
                    if (currColor == WheelColor.Green)
                    {
                        middleWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Yellow)
                    {
                        middleWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.D)) // yellow
                {
                    if (currColor == WheelColor.Purple)
                    {
                        middleWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Red)
                    {
                        middleWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.F)) // red
                {
                    if (currColor == WheelColor.Yellow)
                    {
                        middleWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Teal)
                    {
                        middleWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.G)) // teal
                {
                    if (currColor == WheelColor.Red)
                    {
                        middleWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Pink)
                    {
                        middleWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
            }
            else if (innerRing && !innerLocked)
            {
                if (Input.GetKeyDown(KeyCode.W)) // pink
                {
                    if (currColor == WheelColor.Teal)
                    {
                        innerWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Green)
                    {
                        innerWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.A)) // green
                {
                    if (currColor == WheelColor.Pink)
                    {
                        innerWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Purple)
                    {
                        innerWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.S)) // purple 
                {
                    if (currColor == WheelColor.Green)
                    {
                        innerWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Yellow)
                    {
                        innerWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.D)) // yellow
                {
                    if (currColor == WheelColor.Purple)
                    {
                        innerWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Red)
                    {
                        innerWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.F)) // red
                {
                    if (currColor == WheelColor.Yellow)
                    {
                        innerWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Teal)
                    {
                        innerWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.G)) // teal
                {
                    if (currColor == WheelColor.Red)
                    {
                        innerWheel.transform.localEulerAngles += new Vector3(0f, 0f, 60f);
                    }
                    else if (currColor == WheelColor.Pink)
                    {
                        innerWheel.transform.localEulerAngles -= new Vector3(0f, 0f, 60f);
                    }
                }
            }
            else if (outerLocked && middleLocked && innerLocked && !vaultDoor)
            {
                GetComponent<Animator>().SetBool("VaultOpen", true);
                player.GetComponent<OmniController>().enabled = true;
                soundManager.sFX.clip = soundManager.mazeDoorSFX;
                soundManager.sFX.Play();
                vaultDoor = true;
                StartCoroutine(PlayAlarm());
                target.SetActive(false);
                shutdownText.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            currColor = WheelColor.Pink;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currColor = WheelColor.Green;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currColor = WheelColor.Purple;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currColor = WheelColor.Yellow;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            currColor = WheelColor.Red;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            currColor = WheelColor.Teal;
        }
    }

    IEnumerator PlayAlarm()
    {
        yield return new WaitForSeconds(3.0f);
        soundManager.sFX.clip = soundManager.simulationEndingSFX;
        soundManager.sFX.Play();
    }
}
