using UnityEngine;
using TMPro;  

public class GameBehaviour : MonoBehaviour
{
    public static GameBehaviour Instance;

    public float InitBallSpeed = 5.0f;
    public float BallSpeedIncrement = 1.1f;
    
    void Start()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
    }

    void Update()
    {
     
    }
}   
   