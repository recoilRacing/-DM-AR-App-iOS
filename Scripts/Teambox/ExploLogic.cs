using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Video;
public class ExploLogic : MonoBehaviour
{

    private GameObject _exploButton;
    private GameObject _altButton;
    private GameObject _neuButton;
    private GameObject _stromButton;
    private GameObject _druckButton;

    void Start()
    {
        _exploButton = GameObject.Find("Explo-Button");
        _altButton = GameObject.Find("Alt-Button");
        _neuButton = GameObject.Find("Neu-Button");
        _stromButton = GameObject.Find("Strom-Button");
        _druckButton = GameObject.Find("Druck-Button");

        // if ((new GameObject[] { _exploButton, _altButton, _neuButton, _stromButton, _druckButton }).Any() != true)
        // {
        //     Debug.Log("Failed to get all GameObjects");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // if (Physics.Raycast(ray, out hit))
            // {
            //     Debug.Log(hit.transform.name);


            //     if (hit.transform.name.Contains("Target Representation"))
            //     {

            //     }
            //     else if (hit.transform.name == "Video Collider")
            //     {

            //     }
            // }
            // else
            // {

            // }
        }
    }

    void handleRotateOnMouseDrag()
    {

    }
}
