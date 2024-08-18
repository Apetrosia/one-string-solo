using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayButton : MonoBehaviour
{
    private bool songPlaying = false;
    private bool mouseOver = false;

    private void FixedUpdate()
    {
        songPlaying = Conductor.instance.musicSource.isPlaying;
    }

    private void OnMouseOver()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }

    private void OnMouseDown()
    {
        if (mouseOver && !songPlaying)
        {
            Conductor.instance.StartSong();
        }
    }
}
