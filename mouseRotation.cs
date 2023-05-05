using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseRotation : MonoBehaviour
{

    public float factor;

    private Vector2 startPos;
    private int rotationAllowed;
    private Vector3 angles;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector2(0, 0);
        rotationAllowed = 0;
        angles = transform.localEulerAngles;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && rotationAllowed == 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Auto Container")
                {
                    startPos = Input.mousePosition;
                    rotationAllowed = 1;
                    angles = transform.localEulerAngles;
                    Debug.Log(startPos);
                } else
                {
                    rotationAllowed = 2;
                }
            }
            else
            {
                rotationAllowed = 2;
            }
        }

        if (Input.GetMouseButtonUp(0) && rotationAllowed == 1)
        {
            startPos = new Vector2(0, 0);
            rotationAllowed = 0;
            Debug.Log("ended");
        } else if (Input.GetMouseButtonUp(0))
        {
            rotationAllowed = 0;
        }

        if (rotationAllowed == 1)
        {
            transform.localEulerAngles = new Vector3(angles.x, angles.y, angles.z + (startPos.x - Input.mousePosition.x)* factor);
        }





       /* if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    startPos = touch.position;
                    rotationAllowed = true;
                    Debug.Log("begin");
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    //transform.rotation.SetEulerAngles(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + (startPos.y-Input.mousePosition.y), transform.rotation.eulerAngles.z + (startPos.x - Input.mousePosition.x)));
                    Debug.Log("moving");
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    startPos = new Vector2(0,0);
                    rotationAllowed = false;
                    Debug.Log("ended");
                    break;
            }
        }*/
    }
}