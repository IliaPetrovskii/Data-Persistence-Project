using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text bestScore;
    public TMP_Text currentNameTMP;
    public TMP_InputField inputName;
    public Button startButton;
    
    private void Start()
    {
        bestScore.text = "Best Score: " + MainManager.Instance.bestScoreName + " - " + MainManager.Instance.bestScore;
    }

    private void Update()
    {
        if(string.IsNullOrEmpty(inputName.text.Trim()))
        {
            startButton.interactable = false;
        }
        else
        {
            startButton.interactable = true;
        }
    }

    public void StartNew()
    {
        MainManager.Instance.currentPlayerName = inputName.text.Trim();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit(); // original code to quit Unity player
    #endif
    }
}
