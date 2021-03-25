using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText; 

    float currentScore;
    float redScore;
    float blueScore;
    float greenScore;
    float yellowScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + currentScore;

        currentScore = 0f;
        redScore = 50f;
        blueScore = 15f;
        greenScore = 7f;
        yellowScore = 4f;
    }

    // animation event - when you hit the red part of the target
    public void RedScoreHit()
    {
        currentScore += redScore;
        scoreText.text = "Score : " + currentScore;
    }

    // animation event - when you hit the red part of the target
    public void GreenScoreHit()
    {
        currentScore += greenScore;
        scoreText.text = "Score : " + currentScore;
    }

    // animation event - when you hit the red part of the target
    public void BlueScoreHit()
    {
        currentScore += blueScore;
        scoreText.text = "Score : " + currentScore;
    }

    // animation event - when you hit the red part of the target
    public void YellowScoreHit()
    {
        currentScore += yellowScore;
        scoreText.text = "Score : " + currentScore;
    }
}
