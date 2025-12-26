using UnityEngine;
using YG;

public class ScoreTadle : MonoBehaviour
{
    private void Start()
    {
        YG2.SetLeaderboard("LeaderBoard", 10000);
    }
}
