using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    public Slider staminaSlider;
    public PlayerMovement playerMovement;

    void Start()
    {
        // Find the PlayerMovement script
        playerMovement = GetComponent<PlayerMovement>();
        
        // Ensure you have a reference to the StaminaSlider
        if (staminaSlider == null)
        {
            Debug.LogError("StaminaSlider is not assigned!");
            return;
        }

        staminaSlider.maxValue = playerMovement.maxStamina;
        staminaSlider.value = playerMovement.maxStamina;
    }

    void Update()
    {
        
        if (staminaSlider != null && playerMovement != null)
        {
            staminaSlider.value = playerMovement.currentStamina;
        }
    }
}
