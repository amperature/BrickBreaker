using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;   
    public Utilities.GameplayState State;
    [SerializeField] private TextMeshProUGUI pauseMessage;


    private int _score;
    public int Score

        {
        // Getter property
        get => _score;
        
        // Setter property
        set
        {
            _score = value;
            _scoreUI.text = Score.ToString();
        }
    }
    [SerializeField] private TextMeshProUGUI _scoreUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Singleton pattern (took this from the Game Behavior script in pong)
        
        // When creating an instance, check if one already exists,
        // and if the existing is the one that is trying to be created.
        if (Instance != null && Instance != this)
        {
            // If a different instance already exists,
            // please destroy the instance that is currently being created.
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }        
    }

    void Start() {

        State = Utilities.GameplayState.Play;
        pauseMessage.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            State = State == Utilities.GameplayState.Play
                ? Utilities.GameplayState.Pause
                : Utilities.GameplayState.Play;

            pauseMessage.enabled = !pauseMessage.enabled;
        }
    }

    public void ScorePoint()
    {
        Score++;
    }
    
    public void LosePoint() 
    {
        Score--;
    }
}
