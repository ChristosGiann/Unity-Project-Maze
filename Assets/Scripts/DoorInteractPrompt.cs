using UnityEngine;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    public Transform player;
    public float interactionDistance = 10f; 
    public Text interactionText;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= interactionDistance)
        {
            interactionText.text = "Press 'E' to interact with the door";
        }
        else
        {
            interactionText.text = "";
        }
    }
}
