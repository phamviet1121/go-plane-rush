using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public void SubmitScoreToLeaderboard(int  score)
    {

        Social.ReportScore(score, "CgkIka2Vp-MQEAIQAQ", (bool success) =>
        {
            if (success)
            {
                Debug.Log("Score successfully submitted to leaderboard");
            }
            else
            {
                Debug.Log("Failed to submit score to leaderboard");
            }
        });

    }

    public void ShowLeaderboard()
    {

        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIka2Vp-MQEAIQAQ");
        Debug.Log("Showing leaderboard");

    }
}
