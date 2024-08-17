using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Song", menuName = "Song")]
public class SongData : ScriptableObject
{
    // Beats per minute
    public float bpm;
    // Music source file
    public AudioClip music;
}
