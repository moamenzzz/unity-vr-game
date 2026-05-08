using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Handles the interaction logic for boxes that can be opened from the top.
/// </summary>
public class BoxInteraction : MonoBehaviour
{
    [Header("Box Configuration")]
    [SerializeField] private Transform boxLid;
    [SerializeField] private float openAngle = 90f; // Degrees to rotate when opening
    [SerializeField] private float openSpeed = 2f; // Speed of opening animation
    [SerializeField] private Vector3 rotationAxis = Vector3.right; // Axis for lid rotation
    
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private XRGrabInteractable grabInteractable;
    
    private void Start()
    {
        if (boxLid == null)
        {
            Debug.LogError("Box Lid is not assigned!");
            return;
        }
        
        grabInteractable = GetComponent<XRGrabInteractable>();
        closedRotation = boxLid.localRotation;
        openRotation = closedRotation * Quaternion.AngleAxis(openAngle, rotationAxis);
    }
    
    /// <summary>
    /// Opens or closes the box lid with smooth animation.
    /// </summary>
    public void ToggleBox()
    {
        isOpen = !isOpen;
        StartCoroutine(AnimateLid(isOpen ? openRotation : closedRotation));
    }
    
    /// <summary>
    /// Animates the lid opening/closing.
    /// </summary>
    private System.Collections.IEnumerator AnimateLid(Quaternion targetRotation)
    {
        float elapsed = 0f;
        Quaternion startRotation = boxLid.localRotation;
        float duration = 1f / openSpeed;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            boxLid.localRotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }
        
        boxLid.localRotation = targetRotation;
    }
    
    /// <summary>
    /// Gets the current state of the box (open/closed).
    /// </summary>
    public bool IsOpen => isOpen;
}
