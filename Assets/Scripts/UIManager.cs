using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Scene Elements")]
    [SerializeField] private GameObject pausePanel;    
    [SerializeField] private Button startButton;       
    [SerializeField] private Button continueButton;    
    [SerializeField] private Button menuButton;        
    [SerializeField] private Button exitButton;        

    private bool isPaused = false;

    private void Awake()
    {
    }

    private void OnEnable()
    {
        if (startButton)
            startButton.onClick.AddListener(StartGame);

        if (continueButton)
            continueButton.onClick.AddListener(ResumeGame);

        if (menuButton)
            menuButton.onClick.AddListener(ReturnToMenu);

        if (exitButton)
            exitButton.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        if (startButton)
            startButton.onClick.RemoveAllListeners();

        if (continueButton)
            continueButton.onClick.RemoveAllListeners();

        if (menuButton)
            menuButton.onClick.RemoveAllListeners();

        if (exitButton)
            exitButton.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game" && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        if (pausePanel) pausePanel.SetActive(false);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void TogglePause()
    {
        if (!pausePanel) return;

        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
