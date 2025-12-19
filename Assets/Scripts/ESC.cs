using UnityEngine;

public class ESC : MonoBehaviour
{
    public GameObject pausePanel;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isPaused = pausePanel.activeSelf;

            Time.timeScale = isPaused ? 1f : 0f;
            pausePanel.SetActive(!isPaused);
        }
    }
}
