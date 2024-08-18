using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FileReader
{
    // Function to read song chart from file
    public static Note[] ReadChart(TextAsset chart, TextAsset notesPos)
    {
        // Get all lines of file (1st line is a header)
        string[] lines = chart.text.Split('\n');

        // Array of notes
        Note[] notes = new Note[lines.Length - 1];

        // Get notes positions
        float[] positions = ReadNotesPositions(notesPos);

        // Get all the data of notes, skipping the header
        for (int i = 1; i < lines.Length; i++)
        {
            //Debug.Log(lines[i]);

            string[] beatPos = lines[i].Split(",");

            float beat = float.Parse(beatPos[0], System.Globalization.CultureInfo.InvariantCulture);
            int position = int.Parse(beatPos[1], System.Globalization.CultureInfo.InvariantCulture);

            notes[i-1] = new Note();
            notes[i-1].beat = beat;
            notes[i-1].position = positions[position];
        }
        return notes;
    }

    public static float[] ReadNotesPositions(TextAsset file)
    {
        // Get all lines of file (1st line is a header)
        string[] lines = file.text.Split('\n');

        // Array of positions
        float[] positions = new float[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            positions[i] = float.Parse(lines[i], System.Globalization.CultureInfo.InvariantCulture);
        }

        return positions;
    }
}
