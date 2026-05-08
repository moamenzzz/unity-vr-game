using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Manages VR controller input and interactions.
/// </summary>
public class VRController : MonoBehaviour
{
    [Header("Input Configuration")]
    [SerializeField] private XRController controller;
    [SerializeField] private float inputThreshold = 0.1f;
    
    private XRGrabInteractable heldObject;
    private BoxInteraction currentBoxInteraction;
    
    private void OnEnable()
    {
        if (controller != null)
        {
            controller.selectAction.action.performed += OnSelectPerformed;
            controller.selectAction.action.canceled += OnSelectCanceled;
        }
    }
    
    private void OnDisable()
    {
        if (controller != null)
        {
            controller.selectAction.action.performed -= OnSelectPerformed;
            controller.selectAction.action.canceled -= OnSelectCanceled;
        }
    }
    
    private void OnSelectPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // Handle grab logic
        Debug.Log("Controller grab initiated");
    }
    
    private void OnSelectCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // Handle release logic
        Debug.Log("Controller grab released");
    }
    
    /// <summary>
    /// Tries to interact with a box if currently holding one.
    /// </summary>
    public void TryOpenBox(BoxInteraction boxInteraction)
    {
        if (boxInteraction != null)
        {
            boxInteraction.ToggleBox();
        }
    }
}
