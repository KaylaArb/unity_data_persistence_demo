using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI HighScoreUserText;
    public TMP_InputField inputValue;

    public void Start() {


        if (GameManager.Instance != null) {
            inputValue.text = GameManager.Instance.userName;
            HighScoreUserText.text = $"Best High Score: {GameManager.Instance.highScoreName} : {GameManager.Instance.highScore}" ;
        }
    }
    // Update is called once per frame
    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    public void LoadHighScoreScene()
    {
        SceneManager.LoadScene(1);
    }

    public void SetName(string inputName) {
        GameManager.Instance.userName = inputName;
    }
}
