using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMovement : MonoBehaviour
{

    //Determines which method of movement the orb will use. Set in editor.
    //1 = up and down (parent)
    //2 and 3 orbit around parent.
    public int moveType = 0;

    //used for up and down movement
    private Vector3 endTarget;
    private Vector3 origin;
    private Vector3 currentTarget;
    public float speed = 1.0f;
    //used for orbiting movement
    private GameObject orbitTarget;


    // Start is called before the first frame update
    void Start()
    {
        origin = gameObject.transform.position;
        endTarget = origin + new Vector3(0, 10, 0);
        currentTarget = endTarget;
        if (moveType == (2) || moveType == (3))
        {
            orbitTarget = gameObject.transform.parent.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(moveType)
        {
            //up and down
            case 1:

                //if at the origin, go to destination. if at destination, return to origin.
                if (transform.position == origin)
                {
                    currentTarget = endTarget;
                }
                else if (transform.position == endTarget)
                {
                    currentTarget = origin;
                }

                //calculate how far to move and then move towards target.
                var step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
                break;
            //orbit horizontal
            case 2:
                transform.RotateAround(orbitTarget.transform.position, Vector3.up, 30 * Time.deltaTime);
                break;
            //orbit on a diagonal
            case 3:
                transform.RotateAround(orbitTarget.transform.position, new Vector3(0,1,1), 50 * Time.deltaTime);
                break;
        }
    }
}
