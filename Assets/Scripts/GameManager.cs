using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] string currentScene;

    private AudioSource stringObj;

    [SerializeField] TMP_Text scoreText;
    private int score;

    void Start()
    {
        stringObj = GameObject.Find("String").GetComponent<AudioSource>();
        pausePanel.SetActive(false);

        score = 0;
        scoreText.text = "Score: 0";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pausePanel.activeSelf)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1.0f;
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
        Debug.Log("ponts += " + points);
    }

    public bool IsPaused() => pausePanel.activeSelf;
}
