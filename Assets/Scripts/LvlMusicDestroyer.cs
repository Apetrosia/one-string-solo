using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlMusicDestroyer : MonoBehaviour
{
    private void Awake()
    {
        var musicObj = FindObjectOfType<SongLoader>();
        if (musicObj != null)
        {
            Destroy(musicObj.gameObject);
            Debug.Log("lvlm destroyed");
        }
    }
}
