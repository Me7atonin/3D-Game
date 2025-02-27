using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSecretWinScreen : MonoBehaviour
{
    public float interactDistance = 1f;

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Plane"))
            {
                SceneManager.LoadSceneAsync(5);
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }
}