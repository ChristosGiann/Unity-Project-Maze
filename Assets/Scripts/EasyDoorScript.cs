using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleKeyDoorController : MonoBehaviour
{
    public GameObject key; 
    public float interactionDistance = 10f; 
    private bool isDoorOpen = false;

    void Update()
    {
        InteractWithDoor();
    }

    void InteractWithDoor()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interact key pressed!");

            
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            if (playerMovement != null && Vector3.Distance(transform.position, playerMovement.transform.position) <= interactionDistance)
            {
                
                if (key != null && !key.activeSelf)
                {
                    OpenDoor();
                }
            }
        }
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
