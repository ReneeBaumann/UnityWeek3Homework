using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class GameBehaviour : MonoBehaviour
{
    // Singleton pattern
    public static GameBehaviour Instance;

    public Utilities.GamePlayState State;
    [SerializeField] private TextMeshProUGUI _pauseMessage;

    public float InitBallSpeed = 5.0f;
    public float BallSpeedIncrement = 1.1f;

    [SerializeField] private TextMeshProUGUI _scoreUI;
    private int _score;
    
    public int Score
    {
         get {return _score; }

         set
        {
            _score = value;
            UpdateScoreUI();
        }
    }
    
    void Awake()
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

    private void UpdateScoreUI()
    {
        if (_scoreUI != null)
        {
            _scoreUI.text = "Score: " + _score.ToString(); 
        }
    }
        
        
    private void Start()
    {
        State = Utilities.GamePlayState.Play;
        _pauseMessage.enabled = false;
    }

    private void Update()
    {  
        if (Input.GetKeyDown(KeyCode.P))
        {  
            State = State == Utilities.GamePlayState.Play
                ? Utilities.GamePlayState.Pause
                : Utilities.GamePlayState.Play;

            _pauseMessage.enabled = !_pauseMessage.enabled;
        } 
    } 
}