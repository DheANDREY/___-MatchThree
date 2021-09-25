using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int tileRatio;
    public int comboRatio;
    public bool kondisi1 { get; private set; }
    public int HighScore { get { return highScore; } }
    public int CurrentScore { get { return currentScore; } }
    [SerializeField] public GameObject achievementM1;
    [SerializeField] public GameObject achievementM2;
    [SerializeField] public GameObject achievementM3;
    private int currentScore;
    private static int highScore;
    // Start is called before the first frame update
    void Start()
    {
        ResetCurrentScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Singleton

    private static ScoreManager _instance = null;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instance;
        }
    }
    #endregion
    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public void IncrementCurrentScore(int tileCount, int comboCount)
    {
        currentScore += (tileCount * tileRatio) * (comboCount * comboRatio);
        SoundManager.Instance.PlayScore(comboCount > 1);

        if (currentScore >= 100 && currentScore < 200)
            {
                achievementM1.gameObject.SetActive(true);           
        }        
        else if (currentScore > 200 && currentScore < 300) {
                achievementM1.gameObject.SetActive(false);
            }
        else if (currentScore >= 500 && currentScore < 600)
            {
                achievementM2.gameObject.SetActive(true);
        }
        else if (currentScore > 600 && currentScore < 700)
            {
                achievementM2.gameObject.SetActive(false);
            }
        else if (currentScore >= 1000)
            {
                achievementM3.gameObject.SetActive(true);
        }

    }

    public void SetHighScore()
    {
        highScore = currentScore;
        // Set high score
        if (currentScore > ScoreDatas.highScore)
        {
            ScoreDatas.highScore = currentScore;
        }
    }
        
    
}
