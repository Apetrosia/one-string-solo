using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongLoader : MonoBehaviour
{
    public SongData song;

    public void SetSong(SongData song) => this.song = song;

    public SongData GetSong() => song;
}
