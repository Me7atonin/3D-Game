using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                SceneManager.LoadSceneAsync(4);
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }
}