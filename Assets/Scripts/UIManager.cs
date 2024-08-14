using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI HighScoreUserText;

    public void Start() {

        if (GameManager.Instance != null) {
            HighScoreUserText.text = $"Best High Score: {GameManager.Instance.highScoreName} : {GameManager.Instance.highScore}" ;
        }
    }
    // Update is called once per frame
    public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void LoadHighScoreScene()
    {
        SceneManager.LoadScene(2);
    }
}
