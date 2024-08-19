using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private SongData song;

    private void Start()
    {
        var sil = GetComponent<SongInfoLoader>();
        if (sil)
        {
            song = sil.GetSong();
        }
        //Debug.Log(song);
    }

    public void LoadLevel(string sceneName)
    {
        if (song)
            SelectSong();
        SceneManager.LoadScene(sceneName);
    }

    public void SelectSong()
    {
        GameObject t = new GameObject();
        SongLoader sl = t.AddComponent<SongLoader>();
        sl.SetSong(song);
        Instantiate(t);
        t.name = "LevelMusic";
        DontDestroyOnLoad(t);
    }
}
