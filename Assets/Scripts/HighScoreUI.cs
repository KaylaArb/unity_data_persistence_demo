using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoreUI : MonoBehaviour
{
    public TextMeshProUGUI userList;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null) {
            string value = "";

            foreach(GameManager.HighScoreUser user in GameManager.Instance.HighScoreList.highScoreList) {
                value = value + $"{user.name} : {user.score} \n";
            }

            userList.text = value;
        } 
        
    }


    public void BackToMenu() {
        SceneManager.LoadScene(1);
    }
}
