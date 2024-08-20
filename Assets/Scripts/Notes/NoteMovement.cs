using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    private bool isDestroying;
    [SerializeField] Color[] colors;
    private GameManager gameManager;
    // Beat this note should be played on
    public float beat;
    // y coordinate
    public float posY;

    void Start()
    {
        System.Random r = new System.Random();
        GetComponent<SpriteRenderer>().color = colors[r.Next(colors.Length)];
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        isDestroying = false;
    }

    void Update()
    {
        if (!gameManager.IsPaused())
            transform.position = Vector2.Lerp(
                new Vector2(Conductor.instance.spawnPos.position.x, posY),
                new Vector2(Conductor.instance.removePos.position.x, posY),
                (Conductor.instance.beatsShownInAdvance - (beat - Conductor.instance.songPositionInBeats)) / Conductor.instance.beatsShownInAdvance);

        // Remove itself when out of the screen (remove line).
        if (transform.position.x > Conductor.instance.removePos.position.x - 0.00001f && !isDestroying)
        {
            StartCoroutine(DestroyNote());
            //Destroy(gameObject);
        }
    }

    public IEnumerator DestroyNote()
    {
        isDestroying = true;
        while (transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime, transform.localScale.y - Time.deltaTime, transform.localScale.z);
            yield return null;
        }
        GameObject.Destroy(gameObject);
    }
}
