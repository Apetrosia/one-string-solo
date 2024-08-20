using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        image.color = Color.black;
    }

    void Update()
    {
        image.color = new Color(0, 0, 0, image.color.a - Time.deltaTime * 0.7f);
        if (image.color.a <= 0)
            GameObject.Destroy(gameObject);
    }
}
