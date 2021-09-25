using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public bool IsGameOver { get { return isGameOver; } }

    [Header("UI")]
    public UIGameOver GameOverUI;

    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Singleton

    private static GameFlowManager _instance = null;

    public static GameFlowManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameFlowManager>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: GameFlowManager not Found");
                }
            }

            return _instance;
        }
    }
    #endregion
    public void GameOver()
    {
        isGameOver = true;
        SoundManager.Instance.GameOvers();
        ScoreManager.Instance.SetHighScore();
        GameOverUI.Show();
    }
}
