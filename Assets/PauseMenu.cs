using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    
    public void ResumeGame() => GameManager.Instance.UpdateGameState(GameState.Resume);
    public void LoadOptionsMenu() => Debug.Log("Loading Options menu...");

    public void LoadMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scenes/Menu");
    }
}
