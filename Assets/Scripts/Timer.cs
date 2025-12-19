using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text TimerText;
    public TMP_Text FinalTimeText;
    public GameObject DiePanel;

    private float _timer;
    private bool _isGameOver;

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
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
        TimerText.text = "Final Time: " + TimerText.text;
        DiePanel.SetActive(true);
        FinalTimeText.text = TimerText.text;
        Time.timeScale = 0f;
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}