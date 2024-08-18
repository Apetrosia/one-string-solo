using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusicDestroyer : MonoBehaviour
{
    private void Awake()
    {
        var musicObj = DontDestroy.instance;
        if (musicObj != null)
            Destroy(musicObj.gameObject);
    }
}
