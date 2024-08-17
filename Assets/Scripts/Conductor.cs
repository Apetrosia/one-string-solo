using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    // Song data including bpm and audio
    public SongData songData;

    // The offset to the first beat of the song in seconds
    public float firstBeatOffset;

    [Header("Should be private later")]
    // TODO: make all of the variables below private after the game works

    // The number of seconds for each song beat
    public float secPerBeat;

    // Current song position, in seconds
    public float songPosition;

    // Current song position, in beats
    public float songPositionInBeats;

    // How many seconds have passed since the song started
    public float dspSongTime;

    // An AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    // Conductor instance
    public static Conductor instance;

    public Note[] chart;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the chart of the song
        chart = ChartReader.ReadChart(songData.chart);

        // Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        // Assing the song to the AudioSource
        musicSource.clip = songData.music;

        // Calculate the number of seconds in each beat
        secPerBeat = 60f / songData.bpm;

        // Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        // Start the music
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the position in seconds
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        // Calculate the position in beats
        songPositionInBeats = songPosition / secPerBeat;
    }
}
