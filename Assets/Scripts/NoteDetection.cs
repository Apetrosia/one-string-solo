using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteDetection : MonoBehaviour
{
    private bool noteDetected;

    private String soloString;
    private float point = 5;
    private float multiplier;
    private GameManager gameManager;

    private float maxTime = 3f;

    void Start()
    {
        soloString = GameObject.FindAnyObjectByType<String>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        noteDetected = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !noteDetected)
        {
            gameManager.AddScore(-500);
            GradeFly(-500f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        noteDetected = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            multiplier = collision.GetComponent<CircleCollider2D>().radius;
            float points = multiplier * (int)(3.3f - Mathf.Abs(collision.transform.position.x - transform.position.x) +
                3.3 - Mathf.Abs(collision.transform.position.y - soloString.GetYPos())) * point * 100;
            gameManager.AddScore((int)points);
            GradeFly(points);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        noteDetected = false;
        //Debug.Log("Note, goodbye~");
    }

    private IEnumerator GradeFly(float points)
    {
        System.Random r = new System.Random();
        float time = maxTime; //1000 1250 1500 -500
        /*text.text = formulas[f];

        TMP_Text obj = Instantiate(text, new Vector3(r.Next(xrange.Item1, xrange.Item2), r.Next(yrange.Item1, yrange.Item2), 0),
            Quaternion.Euler(new Vector3(0, 0, r.Next(-30, 30))));
        obj.transform.SetParent(canvas.transform);

        while (time > 0)
        {
            obj.transform.position = obj.transform.position + new Vector3(0, Time.deltaTime * 200f, 0);
            obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, obj.color.a - Time.deltaTime * 0.4f);
            yield return new WaitForSeconds(Time.deltaTime);
            time -= Time.deltaTime;
        }
        GameObject.Destroy(obj.gameObject);*/
        yield return new WaitForSeconds(Time.deltaTime);
    }
}
