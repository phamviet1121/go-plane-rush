using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public void SubmitScoreToLeaderboard(int score)
    {


        Social.ReportScore(score, "CgkIgIev5pEGEAIQAQ", (bool success) =>
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
        Social.ReportScore(score, "CgkIgIev5pEGEAIQAw", (bool success) =>
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
        Social.ReportScore(score, "CgkIgIev5pEGEAIQAg", (bool success) =>
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

        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIgIev5pEGEAIQAQ");
        Debug.Log("Showing leaderboard");

    }
    public void ShowLeaderboard_use()
    {

        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIgIev5pEGEAIQAw");
        Debug.Log("Showing leaderboard");

    }
    public void ShowLeaderboard_int()
    {

        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIgIev5pEGEAIQAg");
        Debug.Log("Showing leaderboard");

    }
}
