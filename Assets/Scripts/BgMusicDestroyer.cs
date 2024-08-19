using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusicDestroyer : MonoBehaviour
{
    private void Awake()
    {
        var musicObj = FindObjectOfType<DontDestroy>();
        if (musicObj != null)
        {
            Destroy(musicObj.gameObject);
            Debug.Log("bgm destroyed");
        }
    }
}
