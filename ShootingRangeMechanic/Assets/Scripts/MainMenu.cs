using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Texture2D cursorTexture;
    public AudioSource gunshotClick;
    //public GameObject settingsMenuButton;
    //public Slider volumeSlider;

    // unitys update function
    void Update()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);

        //AudioListener.volume = volumeSlider.value;

        if (gunshotClick.time >= 0.4f) // after the audio has played start scene
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 0f;
        }
    }

    // loads main scene , starting the game
    public void StartButton()
    {
        gunshotClick.Play();
    }

    // quits the game / application
    public void QuitButton()
    {
        Application.Quit();
    }

    //// click to open settings menu
    //public void SettingsButton()
    //{
    //    settingsMenuButton.SetActive(true);
    //}

    //// button to go back to the main menu from the settings menu
    //public void BackToMainMenuButton()
    //{
    //    settingsMenuButton.SetActive(false);
    //}
}