using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Scene Elements")]
    [SerializeField] private GameObject pausePanel;    // Solo en Game
    [SerializeField] private Button startButton;       // Solo en MainMenu
    [SerializeField] private Button continueButton;    // Solo en Game
    [SerializeField] private Button menuButton;        // En Game o Menu
    [SerializeField] private Button exitButton;        // En MainMenu (opcional)

    private bool isPaused = false;

    private void Awake()
    {
        // Nada persistente, cada escena tiene su propio UIManager
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
        // Solo en la escena Game
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
