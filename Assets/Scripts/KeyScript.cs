using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    public Text keyPickupText; 
    public float messageDuration = 1f;

    private void Start()
    {
        // Ensure the key has a Collider component to detect collisions
        Collider collider = GetComponentInChildren<Collider>();

        if (collider == null)
        {
            Debug.LogError("KeyPickup script requires a Collider component on the key GameObject or its children.");
        }
        else
        {
            // Ensure the Collider is set to trigger mode
            collider.isTrigger = true;
        }
    }

    public void PickupKey()
    {
        
        Debug.Log("Key picked up!");

        // Display key pickup message in UI
        if (keyPickupText != null)
        {
            keyPickupText.text = "Key picked up!";
            Invoke("ClearKeyPickupMessage", messageDuration);
        }

        // Disable or remove the key GameObject
        gameObject.SetActive(false);
    }

    private void ClearKeyPickupMessage()
    {
        // Clear the key pickup message in UI
        if (keyPickupText != null)
        {
            keyPickupText.text = string.Empty;
        }
    }
}