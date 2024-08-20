using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class String : MonoBehaviour
{
    private Vector3 myPos;
    private float posOffset;
    private float mousePosY;
    [SerializeField] private float minScaleY;
    [SerializeField] private float maxScaleY;
    [SerializeField] private GameObject[] notesLabels;
    [SerializeField] private float[] Ycoords;
    [SerializeField] private float[] pitches;
    private float displayHeight;
    private GameManager gameManager;

    private AudioSource source;

    [SerializeField] private bool showLog;

    void Start()
    {
        posOffset = 5f;
        displayHeight = Display.main.systemHeight;
        source = GetComponent<AudioSource>();
        gameManager = GameObject.FindAnyObjectByType<GameManager>();

        //for (int i = 0; i < notesLabels.Length; i++)
            //notesLabels[i].transform.position = new Vector3(notesLabels[i].transform.position.x, Ycoords[i] * (displayHeight / 10f) + displayHeight / 2f, 0f);

        //showLog = true;
    }

    void Update()
    {
        if (!gameManager.IsPaused())
        {
            mousePosY = ToUnityCoordinates(Input.mousePosition.y) + posOffset;
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Max(minScaleY, 0.5f * Mathf.Min(mousePosY, 9f) / 9f), 1f);
            if (Input.GetKeyDown(KeyCode.Space))
                PluckString();
            if (showLog)
                Debug.Log(Input.mousePosition.y + " " + mousePosY + " " + Display.main.systemHeight + " " + transform.position.y);
        }
    }

    private void PluckString()
    {
        float pitch = 1 + (transform.localScale.y - 0.1f) * 5 / 2;

        if (pitch >= 0.95 && pitch <= 1.02)
            pitch = pitches[0];
        else if (pitch >= 1.05 && pitch <= 1.08)
            pitch = pitches[1];
        else if (pitch >= 1.12 && pitch <= 1.14)
            pitch = pitches[2];
        else if (pitch >= 1.187 && pitch <= 1.193)
            pitch = pitches[3];
        else if (pitch >= 1.22 && pitch <= 1.28)
            pitch = pitches[4];
        else if (pitch >= 1.32 && pitch <= 1.36)
            pitch = pitches[5];
        else if (pitch >= 1.39 && pitch <= 1.43)
            pitch = pitches[6];
        else if (pitch >= 1.48 && pitch <= 1.52)
            pitch = pitches[7];
        else if (pitch >= 1.56 && pitch <= 1.62)
            pitch = pitches[8];
        else if (pitch >= 1.66 && pitch <= 1.7)
            pitch = pitches[9];
        else if (pitch >= 1.76 && pitch <= 1.8)
            pitch = pitches[10];
        else if (pitch >= 1.87 && pitch <= 1.93)
            pitch = pitches[11];
        else if (pitch >= 1.98 && pitch <= 2.02)
            pitch = pitches[12];

        source.pitch = pitch;
        source.Play();
    }

    public float GetYPos() => transform.localScale.y  * 8.5f / 0.5f - 4.5f;

    private float ToUnityCoordinates(float displayPos) => displayPos / displayHeight * 10f - 5f;
}
