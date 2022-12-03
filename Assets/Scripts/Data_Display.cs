using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.TextCore.Text;

public class Data_Display : MonoBehaviour
{

    //how often the display updates
    public float updateTime = 0.5f;

    //handles showing FPS
    float accum = 0.0f;
    int frames = 0;
    float timeleft;
    float fps;
    
    //handles displaying data on screen
    private bool drawingGUI = true;
    StringBuilder tx;
    GUIStyle textStyle = new GUIStyle();

    void Start()
    {
        timeleft = updateTime;

        //gui text initialization
        textStyle.fontStyle = FontStyle.Bold;
        textStyle.normal.textColor = Color.yellow;
        tx = new StringBuilder();
        tx.Capacity = 200;
    }

    //runs once per frame
    void Update()
    {
        //calculate the remaining time to the next update, how much time has passed, and increments frame count
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        //when time to update, calculates the frames per second by dividing time passed by frame count in that time.
        //then, resets and begins the process again.
        if (timeleft <= 0.0)
        {
            fps = (accum / frames);
            timeleft = updateTime;
            accum = 0.0f;
            frames = 0;
        }

        //Resets data display string to show new information.
        //the total allocated memory (memory usage) is divided by 1048576 to get from bytes to megabytes (1 mb is 1048576 bytes)
        tx.Length = 0;
        tx.AppendFormat("FPS: {0}\nMemory Usage: {1} mb", fps, Profiler.GetTotalAllocatedMemoryLong() / 1048576);

        //disable and enable display on keypress
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            drawingGUI = !drawingGUI;
        }
    }

    //displays data on screen.
    void OnGUI()
    {
        if (drawingGUI)
        {
            GUI.Label(new Rect(5, 5, 100, 25), tx.ToString(), textStyle);
        }
    }
}
