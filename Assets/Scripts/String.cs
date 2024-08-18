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
    private float displayHeight;

    private AudioSource source;

    [SerializeField] private bool showLog;

    void Start()
    {
        posOffset = 5f;
        displayHeight = Display.main.systemHeight;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        mousePosY = ToUnityCoordinates(Input.mousePosition.y) + posOffset;
        transform.localScale = new Vector3(0.1f, Mathf.Max(minScaleY, 0.5f * Mathf.Min(mousePosY, 9f) / 9f), 1f);
        if (Input.GetKeyDown(KeyCode.Space))
            PluckString();
        if (showLog)
            Debug.Log(Input.mousePosition.y + " " + mousePosY + " " + Display.main.systemHeight  + " " + transform.position.y);
    }

    private void PluckString()
    {
        source.pitch = 1 + (transform.localScale.y - 0.1f) * 5 / 2;
        source.Play();
    }

    private float ToUnityCoordinates(float displayPos) => displayPos / displayHeight * 10f - 5f;
}
