using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    [Header("Adjustable settings")]
    // Song data including bpm and audio
    [SerializeField] private SongData songData;

    // How many beats on the screen are showed
    public float beatsShownInAdvance;

    // The offset to the first beat of the song in seconds
    [SerializeField] private float firstBeatOffset;

    [Header("Change in prefab")]

    // Prefab of the note to spawn
    [SerializeField] private GameObject notePrefab;

    public Transform spawnPos;
    public Transform removePos;

    [SerializeField] private TextAsset notesPositionsFile;

    // The number of seconds for each song beat
    private float secPerBeat;

    // Current song position, in seconds
    private float songPosition;

    [Header("Don't touch pls")]
    // Current song position, in beats
    public float songPositionInBeats;

    // How many seconds have passed since the song started
    private float dspSongTime;

    // An AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    // Conductor instance
    public static Conductor instance;

    private Note[] chart;

    //the index of the next note to be spawned
    private int nextIndex = 0;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SongLoader sl = FindObjectOfType<SongLoader>();
        if (sl)
        {
            SelectSong(sl.GetSong());
            //Destroy(sl.gameObject);
            //Debug.LogWarning("No");
        }
        else
        {
            Debug.LogWarning("No song selected, enjoy kuznechik");
        }

        // Get the chart of the song
        chart = FileReader.ReadChart(songData.chart, notesPositionsFile);

        // Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        // Assing the song to the AudioSource
        musicSource.clip = songData.music;

        // Calculate the number of seconds in each beat
        secPerBeat = 60f / songData.bpm;

        StartSong();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the position in seconds
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        // Calculate the position in beats
        songPositionInBeats = songPosition / secPerBeat;

        float currentBeat = songPositionInBeats + beatsShownInAdvance;

        if (nextIndex < chart.Length && chart[nextIndex].beat < currentBeat)
        {
            //Debug.Log(chart[nextIndex].beat + " " + currentBeat);
            NoteMovement note = Instantiate(notePrefab, 
                new Vector2(spawnPos.position.x, chart[nextIndex].position), 
                Quaternion.identity).GetComponent<NoteMovement>();

            //initialize the fields of the music note
            note.beat = chart[nextIndex].beat;
            note.posY = chart[nextIndex].position;

            nextIndex++;
        }
    }

    // Reset conductor state and start playing music
    public void StartSong()
    {
        nextIndex = 0;

        // Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        // Start the music
        musicSource.Play();
    }

    public void SelectSong(SongData song)
    {
        this.songData = song;
        //songSelected = true;
    }
}
