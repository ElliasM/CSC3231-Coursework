using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Event_Triggers : MonoBehaviour
{

    //This handles events and toggles.
    //It also handles showing the controls for these events for codebase simplicity.

    //handles controls display on gui.
    private bool drawingGUI = true;
    GUIStyle textStyle = new GUIStyle();
    StringBuilder tx;


    //holds the parent object for the sandworm, its terrain change, and particle effect.
    public GameObject wormTerrain;
    public GameObject sandEffect;


    // Start is called before the first frame update
    void Start()
    {
        //create gui text
        tx = new StringBuilder();
        tx.AppendFormat("Toggle GUI display: 1\nWorm event: 2");
    }

    // Update is called once per frame
    void Update()
    {
        //The various toggles.
        //1 = Toggle GUI
        //2 = trigger worm appearance.

        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
           drawingGUI = !drawingGUI;
        }

        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            if (wormTerrain.activeInHierarchy == false)
            {
                wormTerrain.SetActive(true);
                sandEffect.SetActive(true);
            }
        }
            

    }

    //displays control info on screen.
    private void OnGUI()
    {
        if (drawingGUI)
        {
            GUI.Label(new Rect(5, 50, 100, 25), tx.ToString(), textStyle);
        }
    }
}
