using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploRotatingLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        float XAxisRotation = Input.GetAxis("Mouse X");
        float YAxisRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.down, XAxisRotation);
        transform.Rotate(Vector3.right, XAxisRotation);
    }
}
