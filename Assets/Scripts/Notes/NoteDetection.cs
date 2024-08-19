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

    private Stack<GameObject> notes;

    private GameObject canvas;
    [SerializeField] TMP_Text[] grades;

    private float maxTime = 3f;

    void Start()
    {
        soloString = GameObject.FindAnyObjectByType<String>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        canvas = GameObject.Find("UI");
        notes = new Stack<GameObject>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (notes.Count > 0)
            {
                noteDetected = true;
                multiplier = notes.Peek().GetComponent<CircleCollider2D>().radius;
                float points = multiplier * (int)(3.3f - Mathf.Abs(notes.Peek().transform.position.x - transform.position.x) +
                    3.3 - Mathf.Abs(notes.Peek().transform.position.y - soloString.GetYPos())) * point * 100;
                gameManager.AddScore((int)points);
                StartCoroutine(GradeFly(points));
                GameObject.Destroy(notes.Pop().gameObject);
            }
            else
            {
                gameManager.AddScore(-500);
                StartCoroutine(GradeFly(-500));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        notes.Push(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (notes.Count > 0)
            notes.Pop();
        if (!noteDetected)
        {
            gameManager.AddScore(-1000);
            StartCoroutine(GradeFly(-1000f));
        }
        noteDetected = false;
    }

    private IEnumerator GradeFly(float points)
    {
        System.Random r = new System.Random();
        float time = maxTime;

        TMP_Text text = grades[0];

        switch ((int)points)
        {
            case -1000:
                text = grades[0];
                break;
            case -500:
                text = grades[1];
                break;
            case 1000:
                text = grades[2];
                break;
            case 1250:
                text = grades[3];
                break;
            case 1500:
                text = grades[4];
                break;
        }

        TMP_Text obj = Instantiate(text, new Vector3(r.Next(-200, 200) + Display.main.systemWidth / 2, 100, 0),
            Quaternion.Euler(new Vector3(0, 0, r.Next(-30, 30))));
        obj.transform.SetParent(canvas.transform);

        while (time > 0)
        {
            obj.transform.position = obj.transform.position + new Vector3(0, Time.deltaTime * 200f, 0);
            obj.color = new Color(obj.color.r, obj.color.g, obj.color.b, obj.color.a - Time.deltaTime * 0.4f);
            yield return new WaitForSeconds(Time.deltaTime);
            time -= Time.deltaTime;
        }
        GameObject.Destroy(obj.gameObject);
        yield return new WaitForSeconds(Time.deltaTime);
    }
}
