using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text TimerText;
    public TMP_Text FinalTimeText;
    public GameObject DiePanel;

    public float _timer;
    private bool _isGameOver;

    public CharacterController characterController;

    void Start()
    {
        _timer = 0f;
        _isGameOver = false;
    }

    void Update()
    {
        if (!_isGameOver)
        {
            _timer += Time.deltaTime;
            TimerText.text = FormatTime(_timer);

            if ((characterController._currentHealth <= 0) ||
               (characterController.FinishReached))
                GameOver();
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
        FinalTimeText.text = $"Final Time: {FormatTime(_timer)}";
        DiePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}