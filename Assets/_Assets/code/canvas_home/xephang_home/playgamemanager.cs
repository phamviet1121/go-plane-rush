using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SocialPlatforms.Impl;
[Serializable]
public class playgamemanager : MonoBehaviour
{
    //public PlayerManager playerManager;
    public database_save_play_thanhtich database_save_play_thanhtich;
    public Leaderboard leaderBoard;

    public TextMeshProUGUI runplaytimeText;
    // public TextMeshProUGUI coinProgressText;

    public int runplaytime;
    // public int  coinProgress;

    // Start is called before the first frame update
    void Start()
    {
        LoadGameProgress();
        UpdateUI();
    }

    // Update is called once per frame

    public void AddScore()
    {
        Debug.Log($"database_save_play_thanhtich.savefloat_minutes: {database_save_play_thanhtich.savefloat_minutes}");
        Debug.Log($"runplaytime: {runplaytime}");

        if (/*playerManager.score*/ database_save_play_thanhtich.savefloat_minutes > runplaytime)
        {
            runplaytime = /*playerManager.score*/ database_save_play_thanhtich.savefloat_minutes;
            SaveGameProgress();
            leaderBoard.SubmitScoreToLeaderboard(runplaytime);
            Debug.Log($"chay leaderboard ko {runplaytime}");
        }
        UpdateUI();
    }

    //public void CoinCollect()
    //{
    //    if (playerManager.coin > 0)
    //    {
    //        coinProgress += 1;
    //        SaveGameProgress();
    //    }
    //    UpdateUI();
    //}

    public void UpdateUI()
    {
        runplaytimeText.text = runplaytime.ToString();
        // coinProgressText.text = coinProgress.ToString();
    }

    public void SaveGameProgress()
    {
        PlayerPrefs.SetFloat("runplaytime", runplaytime);
        //PlayerPrefs.SetInt("CoinPlayer", coinProgress);
        PlayerPrefs.Save();
    }

    public void LoadGameProgress()
    {
        runplaytime = PlayerPrefs.GetInt("runplaytime", runplaytime);
        //coinProgress = PlayerPrefs.GetInt("CoinPlayer", coinProgress);
    }

    private void OnApplicationQuit()
    {
        SaveGameProgress();
    }


}