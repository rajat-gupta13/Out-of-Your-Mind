using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaSystem : MonoBehaviour {

    private bool inCategory;
    private int currentWord;
    private string[] currentCategory;
    private LightingManager lightManager;
    private bool bgmPlayed = false;
    private bool teamOneTurn;
    private int oneScore;
    private int twoScore;

    public float roundTime;
    public Image background;
    public Text word;
    public Text timer;
    public Text teamOne;
    public Text teamTwo;

    [Header("Backgrounds")]
    public Sprite original;
    public Sprite red;
    public Sprite teal;
    public Sprite pink;
    public Sprite green;
    public Sprite purple;
    public Sprite yellow;

    [Header("Category Words")]
    public string defaultText;
    public string[] worldWar;
    public string[] disco;
    public string[] herstory;
    public string[] christmas;
    public string[] spaceTrack;
    public string[] wildWest;

    //public GameObject lightingManager;
    public SoundManager soundManager;

    private enum Category {
        WorldWar,
        Disco,
        Herstory,
        Christmas,
        SpaceTrack,
        WildWest
    }

	// Use this for initialization
	void Start () {
        inCategory = false;
        currentWord = 0;
        word.text = defaultText;
        oneScore = 0;
        twoScore = 0;
        teamOneTurn = true;
        //lightManager = lightingManager.GetComponent<LightingManager>();
        //lightManager.SetColor(new Color(1, 0.3921f, 0, 1));
    }

    private void OnEnable()
    {
        //lightManager.SetColor(new Color(1, 0.3921f, 0, 1));
    }

    // Update is called once per frame
    void Update() {
        if (inCategory) {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (currentWord == 0 && !bgmPlayed)
                {
                    soundManager.bGM.clip = soundManager.pyramidGameBGM;
                    soundManager.bGM.Play();
                    bgmPlayed = true;
                }
                if (currentWord > 0)
                {
                    soundManager.sFX.clip = soundManager.correctAnswerSFX;
                    soundManager.sFX.Play();
                }
                Continue(1);
            }

            if (Input.GetKeyDown(KeyCode.KeypadPlus)) {
                if (currentWord > 0) {
                    soundManager.sFX.clip = soundManager.wrongAnswerSFX;
                    soundManager.sFX.Play();
                }
                Continue(0);
            }
        } else {
            if (Input.GetKeyDown(KeyCode.Z)) {
                StartCategory(Category.WorldWar);
            } else if (Input.GetKeyDown(KeyCode.X)) {
                StartCategory(Category.Disco);
            } else if (Input.GetKeyDown(KeyCode.C)) {
                StartCategory(Category.Herstory);
            } else if (Input.GetKeyDown(KeyCode.V)) {
                StartCategory(Category.Christmas);
            } else if (Input.GetKeyDown(KeyCode.B)) {
                StartCategory(Category.SpaceTrack);
            } else if (Input.GetKeyDown(KeyCode.N)) {
                StartCategory(Category.WildWest);
            }
            //lightingManager.GetComponent<LightingManager>().SetColor(new Color(1,0.647f,0,1));
        }
	}

    void StartCategory(Category cat) {
        currentWord = 0;
        inCategory = true;
        switch (cat) {
            case Category.WorldWar:
                currentCategory = worldWar;
                background.sprite = red;
                word.text = currentCategory[currentWord];
                //lightManager.SetColor(Color.red);
                break;
            case Category.Disco:
                currentCategory = disco;
                background.sprite = teal;
                word.text = currentCategory[currentWord];
                //lightManager.SetColor(Color.cyan);
                break;
            case Category.Herstory:
                currentCategory = herstory;
                background.sprite = pink;
                word.text = currentCategory[currentWord];
                //lightManager.SetColor(new Color(1, 0.141f, 0.6035f, 1));
                break;
            case Category.Christmas:
                currentCategory = christmas;
                background.sprite = green;
                word.text = currentCategory[currentWord];
                //lightManager.SetColor(Color.green);
                break;
            case Category.SpaceTrack:
                currentCategory = spaceTrack;
                background.sprite = purple;
                word.text = currentCategory[currentWord];
                //lightManager.SetColor(Color.magenta);
                break;
            case Category.WildWest:
                currentCategory = wildWest;
                background.sprite = yellow;
                word.text = currentCategory[currentWord];
                //lightManager.SetColor(Color.yellow);
                break;
        }
    }

    void Continue(int addScore) {
        currentWord++;
        if (1 < currentWord) {
            if (teamOneTurn) {
                oneScore += addScore;
                teamOne.text = "Team One: " + oneScore.ToString();
            } else {
                twoScore += addScore;
                teamTwo.text = "Team Two: " + twoScore.ToString();
            }
        }
        if (currentWord < currentCategory.Length) {
            word.text = currentCategory[currentWord];     
            if (currentWord == 1) {
                StartCoroutine(Timer());
            }
        } else {
            EndCategory();
        }
    }

    void EndCategory() {
        inCategory = false;
        background.sprite = original;
        word.text = defaultText;
        timer.text = ""; soundManager.bGM.Stop();
        bgmPlayed = false;
        teamOneTurn = !teamOneTurn;
        //lightManager.SetColor(new Color(1, 0.3921f, 0, 1));
    }

    IEnumerator Timer() {
        float timeRemaining = roundTime;
        while (timeRemaining > 0 && inCategory) {
            timer.text = "0:" + timeRemaining.ToString().PadLeft(2, '0');
            yield return new WaitForSeconds(1);
            timeRemaining--;
        }
        if (timeRemaining == 0)
        {
            soundManager.sFX.clip = soundManager.endRoundSFX;
            soundManager.sFX.Play();
            Invoke("EndCategory", 0.5f);
        }
    }
}
