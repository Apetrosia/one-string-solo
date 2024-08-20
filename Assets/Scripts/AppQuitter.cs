using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppQuitter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Closed the app");
            Application.Quit();
        }
    }
}
