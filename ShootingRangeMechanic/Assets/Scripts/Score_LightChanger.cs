using TMPro;
using UnityEngine;

public class Score_LightChanger : MonoBehaviour
{
    public TMP_Text scoreText; 
    public TextMesh _LiveScoreText;
    public TextMesh scoreNeededText;

    public float currentScore;
    public float scoreLimitPerRound;
    public float addToScoreLimitPerRound;
    float redScore;
    float blueScore;
    float greenScore;
    float yellowScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0f;
        scoreLimitPerRound = 50f;
        addToScoreLimitPerRound = 20f;
        redScore = 50f;
        blueScore = 15f;
        greenScore = 7f;
        yellowScore = 4f;
    }

    // unitys update function
    void Update()
    {
        scoreText.text = "Score : " + currentScore;
        _LiveScoreText.text = scoreText.text;
        scoreNeededText.text = "Get : " + scoreLimitPerRound;
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
