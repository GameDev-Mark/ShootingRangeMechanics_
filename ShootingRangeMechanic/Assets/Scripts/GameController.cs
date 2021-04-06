﻿using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    float minTimePerRound;
    float startTime;
    float currentTimeNow;
    float waitForNextRound;
    float minWaitTimeNextRound;
    float roundNumber;

    public TMP_Text timerText;
    public TMP_Text waitTimeText;
    public TMP_Text roundNumberText;

    public Score_LightChanger scoreScript;
    public Shooting shootingScript;
    public Movement movementScript;

    public GameObject UIbuttons;
    public GameObject readyGlass;

    public Texture2D cursorTexture;

    public AudioSource glassBreakSFX;

    // unitys start function
    void Start()
    {
        minTimePerRound = 0;
        startTime = 10;
        currentTimeNow = startTime;
        waitForNextRound = 5f;
        minWaitTimeNextRound = 0f;
        roundNumber = 1f;
        roundNumberText.text = "Round : " + roundNumber;
    }

    // unitys update function
    void Update()
    {
        ReadyShot();

        currentTimeNow -= Time.deltaTime;
        timerText.text = "Timer : " + Mathf.RoundToInt(currentTimeNow);

        if (currentTimeNow <= minTimePerRound)
        {
            if(scoreScript.currentScore >= scoreScript.scoreLimitPerRound)
            {
                waitForNextRound -= Time.deltaTime;
                waitTimeText.text = "Hold your fire : " + Mathf.RoundToInt(waitForNextRound);
                timerText.text = "Timer : - ";
                shootingScript.GetComponentInChildren<Animator>().SetTrigger("isIdle");
                shootingScript.bulletCount = shootingScript.bulletMax;
                shootingScript.enabled = !enabled;
                if (waitForNextRound <= minWaitTimeNextRound)
                {
                    scoreScript.currentScore = 0f;
                    startTime += 2;
                    currentTimeNow = startTime;
                    scoreScript.scoreLimitPerRound += scoreScript.addToScoreLimitPerRound;
                    waitTimeText.text = "";
                    waitForNextRound = 5f;
                    roundNumber++;
                    roundNumberText.text = "Round : " + roundNumber;
                    shootingScript.enabled = enabled;
                }
            }
            else
            {
                UIbuttons.SetActive(true);
                shootingScript.enabled = !enabled;
                movementScript.enabled = !enabled;
                waitTimeText.text = "highest round : " + Mathf.RoundToInt(roundNumber);
                timerText.text = "Failed";
                Cursor.lockState = CursorLockMode.None;
                Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
            }
        }

       
    }
    
    // shoot your gun when you are ready to start the game
    public void ReadyShot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitRay;
        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitRay))
            {
                if (hitRay.collider.name == "ReadyBox")
                {
                    Time.timeScale = 1f;
                    glassBreakSFX.Play();
                    readyGlass.GetComponent<Animator>().SetTrigger("isBroke");
                    Destroy(readyGlass, 1.5f);
                    Debug.Log("HIT");
                }
            }
        }
    }

    // restarts the game
    public void RestartGameButton()
    {
        SceneManager.LoadScene(1);
    }

    // quits to main menu
    public void ExitGameButton()
    {
        SceneManager.LoadScene(0);
    }

}