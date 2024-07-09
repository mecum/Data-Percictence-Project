using System.Collections;
using System.Collections.Generic;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public TMP_InputField nameText;
    public string playerName;

    public TMP_Text bestScoreText;

    public string bestPlayerName;
    public int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        bestPlayerName = DataManager.Instance.Name;
        bestScore = DataManager.Instance.BestScore;

        if (bestPlayerName != null)
        {
            bestScoreText.text = "Best Score: " + bestPlayerName + ": " + bestScore;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return)) 
        {
            playerName = nameText.text;

            if (playerName != null)
            {
                if (DataManager.Instance.Name == null)
                {
                    DataManager.Instance.Name = playerName;
                }
                else
                {
                    DataManager.Instance.newName = playerName;
                }
                
            }
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        DataManager.Instance.SaveInfo();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Exit();
#endif
    }
}
