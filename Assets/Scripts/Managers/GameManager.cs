using UnityEngine;

/// <summary>
/// Main game manager for the VR room experience.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Game Configuration")]
    [SerializeField] private int boxCount = 3;
    [SerializeField] private bool debugMode = true;
    
    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        Initialize();
    }
    
    private void Initialize()
    {
        if (debugMode)
        {
            Debug.Log($"Game initialized with {boxCount} boxes");
        }
        
        // Additional initialization logic can be added here
    }
    
    /// <summary>
    /// Get the total number of boxes in the scene.
    /// </summary>
    public int GetBoxCount() => boxCount;
    
    /// <summary>
    /// Check if debug mode is enabled.
    /// </summary>
    public bool IsDebugMode() => debugMode;
}
