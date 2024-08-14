using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public string userName;
    public int highScore;
    public string highScoreName;

    public HighScoreUserList HighScoreList = new HighScoreUserList();


    public void Awake() {
        
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScoreUser();
    }


    [System.Serializable]
    public class HighScoreUser {
        public string name;
        public int score;
    }

    [System.Serializable]
    public class HighScoreUserList {
        public List<HighScoreUser> highScoreList;
    }


    public void SaveHighScoreUser(int points) {
        HighScoreUser user = new HighScoreUser();
        user.name = userName;
        user.score = points;

        //Adds new user score
        HighScoreList.highScoreList.Add(user);
        // Sorts the list with new score from user
        HighScoreList.highScoreList.Sort((user1, user2) => user2.score.CompareTo(user1.score)); 
        // Removes the last index because only 5 can remain in top list
        HighScoreList.highScoreList.RemoveAt(HighScoreList.highScoreList.Count - 1);
        // Readds to top name and score
        highScoreName = HighScoreList.highScoreList[0].name;
        highScore = HighScoreList.highScoreList[0].score;

        string json = JsonUtility.ToJson(HighScoreList);

        File.WriteAllText(Application.persistentDataPath + "/saveList.json", json);
    }

    public void LoadHighScoreUser() {
        string path = Application.persistentDataPath + "/saveList.json";

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            HighScoreUserList data = JsonUtility.FromJson<HighScoreUserList>(json);

            HighScoreUserList sortedList = new HighScoreUserList();

            data.highScoreList.Sort((user1, user2) => user2.score.CompareTo(user1.score)); 

            sortedList.highScoreList = data.highScoreList;

            highScoreName = sortedList.highScoreList[0].name;
            highScore = sortedList.highScoreList[0].score;

            HighScoreList = sortedList;

        }
    }
}
