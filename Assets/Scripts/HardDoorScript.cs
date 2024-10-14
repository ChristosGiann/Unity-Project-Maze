using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public GameObject[] keys; 
    public float interactionDistance = 10f; 

    private bool isDoorOpen = false;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interact key pressed!");
        }

        if (CheckKeysCollected() && !isDoorOpen)
        {
           
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();

            if (playerMovement != null && Vector3.Distance(transform.position, playerMovement.transform.position) <= interactionDistance)
            {
               
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Interact key pressed!");
                    OpenDoor();
                }
            }
        }
    }


    bool CheckKeysCollected()
    {
        foreach (GameObject key in keys)
        {
            if (key.activeSelf)
            {
                return false; 
            }
        }
        return true; 
    }

    void OpenDoor()
    {
        
        Debug.Log("Door opened! You win!");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("Victory");

        
        isDoorOpen = true;
    }
}

