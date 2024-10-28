using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
public class playgamemanager : MonoBehaviour
{
    public TextMeshProUGUI detailsTxt;
    public Button leaderboardButton; // Nút xếp hạng

    void Start()
    {
        // Khởi tạo và kích hoạt Google Play Games
        PlayGamesPlatform.Activate();

        // Đăng nhập vào Google Play Games khi khởi động game
        SignIn();

        // Gắn sự kiện cho nút leaderboard khi người dùng nhấn
        leaderboardButton.onClick.AddListener(OpenLeaderboard);
    }

    // Hàm đăng nhập Google Play Games
    public void SignIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Đăng nhập thành công vào Google Play Games");

                // Lấy thông tin người dùng sau khi đăng nhập thành công
                string name = PlayGamesPlatform.Instance.GetUserDisplayName();
                string id = PlayGamesPlatform.Instance.GetUserId();
                string imgUrl = PlayGamesPlatform.Instance.GetUserImageUrl();

                // Hiển thị thông tin người dùng
                detailsTxt.text = "Đăng nhập thành công\n" + name;
            }
            else
            {
                Debug.Log("Đăng nhập thất bại vào Google Play Games. Yêu cầu đăng nhập thủ công.");
                detailsTxt.text = "Đăng nhập thất bại. Vui lòng đăng nhập lại!";
                PromptSignIn(); // Yêu cầu đăng nhập lại nếu thất bại
            }
        });
    }

    // Hàm nhắc nhở người dùng đăng nhập lại nếu trước đó thất bại
    void PromptSignIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Đăng nhập thành công sau khi nhắc nhở");
                detailsTxt.text = "Đăng nhập thành công";
            }
            else
            {
                Debug.Log("Người dùng từ chối đăng nhập.");
                detailsTxt.text = "Đăng nhập thất bại!";
            }
        });
    }

    // Hàm hiển thị bảng xếp hạng
    public void OpenLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            // Nếu người dùng đã đăng nhập, hiển thị bảng xếp hạng
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Debug.Log("Người chơi chưa đăng nhập! Thử đăng nhập lại.");
            SignIn(); // Thử đăng nhập lại nếu chưa đăng nhập
        }
    }
}