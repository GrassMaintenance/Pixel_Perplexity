using System;
using PixelPerplexity.Player;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public GameState gameState;
    public static event Action<GameState> OnGameStateChanged;
    private bool isPaused;
    [SerializeField] private GameObject pauseMenu;
    private MazeRunner player;
    
    void Awake() {
        Instance = this;
        player = FindObjectOfType<MazeRunner>().GetComponent<MazeRunner>();
    }

    void OnDestroy() => player.OnPlayerPaused -= SetPauseState;

    void Start() {
        player.OnPlayerPaused += SetPauseState;
        UpdateGameState(GameState.Start);
    }

    public void UpdateGameState(GameState newState) {
        gameState = newState;

        switch (newState) {
            case GameState.Start:
                break;
            case GameState.Resume:
                ResumeGame();
                break;
            case GameState.Paused:
                PauseGame();
                break;
            case GameState.LevelComplete:
                break;
            case GameState.GameOver:
                break;
        }
        
        OnGameStateChanged?.Invoke(newState);
    }

    private void SetPauseState() {
        isPaused = !isPaused;
        gameState = isPaused ? GameState.Paused : GameState.Resume;
        UpdateGameState(gameState);
    }

    private void StartGame() => Cursor.lockState = CursorLockMode.Locked;

    private void ResumeGame() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    private void PauseGame() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
}

public enum GameState {
    Start,
    Resume,
    Paused,
    LevelComplete,
    GameOver
}
