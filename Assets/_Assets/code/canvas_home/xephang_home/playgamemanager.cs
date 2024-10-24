using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
public class playgamemanager : MonoBehaviour
{
    public TextMeshProUGUI Details_txt;
    // Start is called before the first frame update
    void Start()
    {
        SignIn();
    }
    public void SignIn()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }
    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            // Continue with Play Games Services
            string name = PlayGamesPlatform.Instance.GetUserDisplayName();
            string id= PlayGamesPlatform.Instance.GetUserId();
            string ImgUrl= PlayGamesPlatform.Instance.GetUserImageUrl();
            Details_txt.text = "Success\n"+name;
        }
        else
        {
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
}
