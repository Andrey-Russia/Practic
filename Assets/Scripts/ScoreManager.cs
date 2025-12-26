using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text FinalScore;
    public int MaxScore = 10000;

    public int _currentScore;
    private int _initialHp;
    private bool _isGameOver;

    public CharacterController CharacterController;
    public Timer TimerScript;

    private void Start()
    {
        _currentScore = 0;
        _isGameOver = false;
        _initialHp = CharacterController.MaxHealth;
    }

    private void Update()
    {
        if (!CharacterController.enabled || !_isGameOver)
        {
            CheckGameState();
        }
    }

    void CheckGameState()
    {
        if ((CharacterController._currentHealth <= 0) ||
           (CharacterController.FinishReached)) 
            SetGameOver(true);

    }

    void CalculateScore()
    {
        int remainingHealth = CharacterController._currentHealth;
        float elapsedTime = TimerScript._timer;
        float healthWeight = (float)(remainingHealth) / (_initialHp * 2);
        float timeWeight = 1f / (elapsedTime + 5);
        _currentScore = Mathf.RoundToInt(MaxScore * timeWeight * healthWeight);
        _currentScore = Mathf.Clamp(_currentScore, 0, MaxScore);
    }

    public void SetGameOver(bool gameOver)
    {
        _isGameOver = gameOver;
        if (gameOver)
        {
            CalculateScore();
            FinalScore.text = $"Final timer: {_currentScore}";

            PlayerPrefs.SetInt("last score", _currentScore);
            PlayerPrefs.Save();
        }
    }
}