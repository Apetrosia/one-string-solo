using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    private GameManager gameManager;
    // Beat this note should be played on
    public float beat;
    // y coordinate
    public float posY;

    void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        if (!gameManager.IsPaused())
            transform.position = Vector2.Lerp(
                new Vector2(Conductor.instance.spawnPos.position.x, posY),
                new Vector2(Conductor.instance.removePos.position.x, posY),
                (Conductor.instance.beatsShownInAdvance - (beat - Conductor.instance.songPositionInBeats)) / Conductor.instance.beatsShownInAdvance);

        // Remove itself when out of the screen (remove line).
        if (transform.position.x > Conductor.instance.removePos.position.x - 0.001f)
        {
            Destroy(gameObject);
        }
    }
}
