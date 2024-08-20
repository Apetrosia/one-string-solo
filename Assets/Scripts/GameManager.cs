using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Conductor conductor;

    [SerializeField] GameObject winPanel;
    [SerializeField] TMP_Text totalScore;
    [SerializeField] TMP_Text gradeText;

    [SerializeField] GameObject pausePanel;
    [SerializeField] string currentScene;

    private AudioSource stringObj;

    [SerializeField] TMP_Text scoreText;
    private int score;

    private bool gameWon;

    //private int count;

    void Start()
    {
        conductor = GameObject.FindObjectOfType<Conductor>();

        stringObj = GameObject.Find("String").GetComponent<AudioSource>();
        pausePanel.SetActive(false);
        winPanel.SetActive(false);

        score = 0;
        scoreText.text = "Score: 0";

        gameWon = false;

        //count = 0;
    }

    void Update()
    {
        if (!gameWon)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (!pausePanel.activeSelf)
                {
                    conductor.PauseMusic();
                    pausePanel.SetActive(true);
                    Time.timeScale = 0.0f;
                }
                else
                {
                    conductor.ResumeMusic();
                    pausePanel.SetActive(false);
                    Time.timeScale = 1.0f;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(currentScene);

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
        //Debug.Log("ponts += " + points + " " + ++count);
    }

    public void SetWin(int grade)
    {
        gameWon = true;
        scoreText.gameObject.SetActive(false);
        winPanel.SetActive(true);
        totalScore.text = score.ToString();
        switch (grade)
        {
            case 0:
                gradeText.text = "CRINGE";
                gradeText.fontSize = 260;
                gradeText.faceColor = new Color(0, 0, 0);
                break;
            case 1:
                gradeText.text = "OK";
                gradeText.fontSize = 500;
                gradeText.faceColor = new Color(255, 233, 160);
                break;
            case 2:
                gradeText.text = "COOL";
                gradeText.fontSize = 300;
                gradeText.faceColor = new Color(212, 255, 110);
                break;
            case 3:
                gradeText.text = "PERFECT";
                gradeText.fontSize = 300;
                gradeText.faceColor = new Color(142, 255, 75);
                gradeText.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 20));
                break;
        }
    }

    public int GetScore() => score;

    public bool IsPaused() => pausePanel.activeSelf;
}
