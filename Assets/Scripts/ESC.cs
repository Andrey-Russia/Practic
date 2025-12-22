using UnityEngine;

public class ESC : MonoBehaviour
{
    public GameObject PausePanel;

    void Start()
    {
        PausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isPaused = PausePanel.activeSelf;

            Time.timeScale = isPaused ? 1f : 0f;
            PausePanel.SetActive(!isPaused);
        }
    }
}
