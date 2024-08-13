using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class UIManager : MonoBehaviour
{
    // Update is called once per frame
    public void LoadGame()
    {
        SceneManager.LoadScene(0);

        // if (GameManager.Instance != null)
        // {
        //     // ScoreTextWithName = $"Best Score: {GameManager.Instance.name}: ${m_Points}" ;
        // }
    }
}
