using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongInfoLoader : MonoBehaviour
{
    [SerializeField] public SongData songData;
    private TMP_Text text;

    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        text.text = songData.name.ToUpper() + " (" + songData.bpm + " BPM)";
    }

    public SongData GetSong() => songData;
}
