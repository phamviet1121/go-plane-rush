using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
public class playgamemanager : MonoBehaviour
{
    public TextMeshProUGUI Details_txt;
    public Button leaderboardButton; // Thêm biến để lưu trữ nút xếp hạng
    private bool isSignedIn = false;
    // Start is called before the first frame update
    void Start()
    {
        SignIn();
    }
    public void SignIn()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
        leaderboardButton.onClick.AddListener(OpenLeaderboard); // Gắn sự kiện cho nút
    }
    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            isSignedIn = true;
            // Continue with Play Games Services
            string name = PlayGamesPlatform.Instance.GetUserDisplayName();
            string id = PlayGamesPlatform.Instance.GetUserId();
            string ImgUrl = PlayGamesPlatform.Instance.GetUserImageUrl();
            Details_txt.text = "Success\n" + name;
        }
        else
        {
            isSignedIn = false;
            Details_txt.text = "Sign in Failed!";
            // Disable your integration with Play Games Services or show a login button
            // to ask users to sign-in. Clicking it should call
            // PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication).
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenLeaderboard()
    {
        if (isSignedIn)
        {
            // Mở trang xếp hạng nếu đã đăng nhập
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Details_txt.text = "Bạn cần đăng nhập trước!";
        }


    }
    public bool IsUserSignedIn()
    {
        return isSignedIn;
    }
}