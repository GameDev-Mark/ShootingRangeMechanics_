using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    bool nextRound;

    float minTimePerRound;
    float startTime;
    float currentTimeNow;
    float waitForNextRound;
    float minWaitTimeNextRound;

    public TMP_Text timerText;
    public TMP_Text waitTimeText;

    public Score_LightChanger scoreScript;
    public Shooting shootingScript;

    // unitys start function
    void Start()
    {
        minTimePerRound = 0;
        startTime = 10;
        currentTimeNow = startTime;
        waitForNextRound = 5f;
        minWaitTimeNextRound = 0f;
    }

    // unitys update function
    void Update()
    {
        currentTimeNow -= Time.deltaTime;
        timerText.text = "Timer : " + Mathf.RoundToInt(currentTimeNow);

        if (currentTimeNow <= minTimePerRound)
        {
            if(scoreScript.currentScore >= scoreScript.scoreLimitPerRound)
            {
                waitForNextRound -= Time.deltaTime;
                waitTimeText.text = "Hold your fire : " + Mathf.RoundToInt(waitForNextRound);
                timerText.text = "Timer : - ";
                shootingScript._canShoot = false;
                if (waitForNextRound <= minWaitTimeNextRound)
                {
                    scoreScript.currentScore = 0f;
                    startTime += 2;
                    currentTimeNow = startTime;
                    scoreScript.scoreLimitPerRound += scoreScript.addToScoreLimitPerRound;
                    waitTimeText.text = "";
                    waitForNextRound = 5f;
                    shootingScript._canShoot = true;
                }
            }
            else
            {
                timerText.text = "Failed";
            }
        }
    }
}