using UnityEngine;
using TMPro;

public class ScoreTadle : MonoBehaviour
{
    public TMP_Text Score;

    public void Start()
    {
        LoadScore();
    }

    void LoadScore()
    {
        int lastScore = PlayerPrefs.GetInt("last score");

        Score.text = $"Последний рекорд: {lastScore}";
    }
}
