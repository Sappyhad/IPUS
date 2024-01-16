using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        // Ładuje scenę z grą (zmień "GameScene" na nazwę twojej sceny z grą)
        SceneManager.LoadScene("GameScene");
    }

    public void Settings()
    {
        // Ładuje scenę z opcjami (zmień "SettingsScene" na nazwę twojej sceny z opcjami)
        SceneManager.LoadScene("SettingsScene");
    }

    public void QuitGame()
    {
        // Wychodzi z gry (tylko w buildzie; w edytorze może nie działać)
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
