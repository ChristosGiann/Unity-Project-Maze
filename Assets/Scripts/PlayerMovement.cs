using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float sensitivity = 3f;
    public float boostedSpeed = 20f;
    private float currentSpeed;
    public float currentStamina;
    public float maxStamina = 100f;
    public float staminaLossRate = 10f;
    public float speedDecreaseFactor = 0.5f;

    private CharacterController characterController;
    private float rotationX = 0f;
    private bool isSprinting = false;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentStamina = maxStamina;
        currentSpeed = speed;

    }

    void Update()
    {
        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.TransformDirection(new Vector3(horizontal, 0, vertical));

        // Toggle sprinting based on left shift key
        if (Input.GetKeyDown(KeyCode.LeftShift) && currentStamina > 0)
        {
            isSprinting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || currentStamina == 0)
        {
            isSprinting = false;
        }

        // Apply movement speed based on sprinting state
        currentSpeed = isSprinting ? boostedSpeed : speed;
        characterController.SimpleMove(movement * currentSpeed);

        // Stamina
        if (isSprinting)
        {
            LoseStamina();
        }
        else
        {
            RegenStamina();
        }

        // Player rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }

    void LoseStamina()
    {
        // Stamina depletes when running
        currentStamina -= staminaLossRate * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }

    void RegenStamina()
    {
        // Stamina regeneration
        currentStamina += staminaLossRate * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }

   void OnTriggerEnter(Collider other)
    {
    Debug.Log("Player OnTriggerEnter called.");

    // Check if the collided object has the KeyPickup component
    KeyPickup keyScript = other.gameObject.GetComponent<KeyPickup>();

    if (keyScript != null)
    {
        Debug.Log("Player collided with a key!");

        // Call PickupKey method directly
        keyScript.PickupKey();
    }
}


}