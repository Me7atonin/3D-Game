using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);//Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);
            if (Physics.Raycast(ray, out hit))
                if (hit.collider != null)
                    Debug.Log(hit.collider.gameObject.name);
        }
    }
}