using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class ChartReader
{
    // Function to read song chart from file
    public static Note[] ReadChart(TextAsset chart)
    {
        // Get all lines of file (1st line is a header)
        string[] lines = chart.text.Split('\n');

        // Array of notes
        Note[] notes = new Note[lines.Length - 1];

        // Get all the data of notes, skipping the header
        for (int i = 1; i < lines.Length; i++)
        {
            //Debug.Log(lines[i]);

            string[] beatPos = lines[i].Split(",");

            float beat = float.Parse(beatPos[0], System.Globalization.CultureInfo.InvariantCulture);
            float position = float.Parse(beatPos[1], System.Globalization.CultureInfo.InvariantCulture);

            notes[i-1] = new Note();
            notes[i-1].beat = beat;
            notes[i-1].position = position;
        }
        return notes;
    }
}
