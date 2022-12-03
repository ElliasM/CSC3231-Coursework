using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraterRise : MonoBehaviour
{

    //used to make the crater w/ worm rise out of the ground on spawn.

    public float speed = 1.0f;

    //this is the same code as used in OrbMovement.
    private Vector3 endTarget;
    private Vector3 origin;
    void Start()
    {
        origin = gameObject.transform.position;
        endTarget = (origin + new Vector3(0,15.4f,0));

    }

    private void Update()
    {
        //once the crater reaches its position, disables this script
        //this is to save memory on unnecessary update calls.
        if (gameObject.transform.position == endTarget)
        {
            gameObject.GetComponent<CraterRise>().enabled = false;
        }

        //calculates how far to move and then moves towards position.
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endTarget, step);


    }

}
