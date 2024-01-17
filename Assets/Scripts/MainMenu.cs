using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        // Ładuj scenę z grą
        SceneManager.LoadScene("GameScene");
    }

    public void Settings()
    {
        // Ładuj scenę z opcjami
        SceneManager.LoadScene("SettingsScene");
    }

    public void QuitGame()
    {
        // Wyjdź gry (tylko w buildzie; w edytorze nie działa)
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
