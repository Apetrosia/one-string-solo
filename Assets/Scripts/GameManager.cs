using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] string currentScene;
    private AudioSource stringObj;

    void Start()
    {
        stringObj = GameObject.Find("String").GetComponent<AudioSource>();
        pausePanel.SetActive(false);
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

    public bool IsPaused() => pausePanel.activeSelf;
}
