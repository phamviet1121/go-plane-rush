using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using TMPro;

public class logingoogle : MonoBehaviour
{
    public string Token;
    public string Error;
    public TextMeshProUGUI trangthaidangnhap;
    public TextMeshProUGUI dex_text;
    // Start is called before the first frame update
    private void Start()
    {
        singinn();
    }
    public void singinn()
    {
        PlayGamesPlatform.Instance.Authenticate(PA);
    }
    internal void PA(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            string name = PlayGamesPlatform.Instance.GetUserDisplayName();
            dex_text.text = "tendangnhap:" + name;
        }
        else
        {
            dex_text.text = "loidangnhap";
        }

    }

    async void Awake()
    {
        try
        {
           
            await UnityServices.InitializeAsync();
         


            PlayGamesPlatform.Activate();
         


            if (Social.localUser.authenticated)
            {
                trangthaidangnhap.text = "da dang nhap ";
                  Token = "User is already signed in.";
                return;
            }

           
            await LoginGooglePlayGamesAsync();
        }
        catch (Exception e)
        {
           // Debug.LogError("Failed to initialize Unity Services: " + e.Message);
            trangthaidangnhap.text = "chua dang nhap  " + e.Message;
        }
    }
    public async void singin()
    {
        await LoginGooglePlayGamesAsync();
        trangthaidangnhap.text = "da goi ham   LoginGooglePlayGamesAsync() ";
    }
   


    public async Task LoginGooglePlayGamesAsync() // Sử dụng async
    {
       // Debug.Log("Starting Google Play Games login...");

        // Gọi Authenticate
        var authenticationTask = new TaskCompletionSource<SignInStatus>();

        PlayGamesPlatform.Instance.Authenticate((success) =>
        {
            authenticationTask.SetResult(success);
        });

        SignInStatus status = await authenticationTask.Task; // Sử dụng await

        if (status == SignInStatus.Success) // Nếu thành công
        {
           // Debug.Log("Login with Google Play Games successful.");
            await RequestServerSideAccess(); // Sử dụng await

        }
        else
        {
            Error = "Failed to retrieve Google Play Games authorization code.";
         
            trangthaidangnhap.text = "da dang nhap  loi o day   LoginGooglePlayGamesAsync() ";
        }
    }

    private async Task RequestServerSideAccess()
    {
        var codeTask = new TaskCompletionSource<string>();

        PlayGamesPlatform.Instance.RequestServerSideAccess(true, (code) =>
        {
            codeTask.SetResult(code);
        });

        string authCode = await codeTask.Task;

        if (!string.IsNullOrEmpty(authCode))
        {
           // Debug.Log("Authorization code received: " + authCode);
            Token = authCode;
            await SignInWithGooglePlayGamesAsync(authCode);
        }
        else
        {
            Error = "Failed to receive authorization code.";
          //  Debug.LogError("Failed to receive authorization code: " + authCode);
            trangthaidangnhap.text = "da dang nhap  loi o day  RequestServerSideAccess() " + authCode;
        }
    }

    async Task SignInWithGooglePlayGamesAsync(string authCode)
    {
        //Debug.Log("Starting SignInWithGooglePlayGamesAsync with authCode: " + authCode);

        try
        {
            trangthaidangnhap.text = "dang nhap thành công ko co loi gì ";
            await AuthenticationService.Instance.SignInWithGooglePlayGamesAsync(authCode);
          //  Debug.Log("SignIn is successful.");
        }
        catch (AuthenticationException ex)
        {
            trangthaidangnhap.text = "dang nhap  co loi o dayAuthenticationException__ SignInWithGooglePlayGamesAsync " + ex.Message;
            // Debug.LogError("AuthenticationException occurred: " + ex.Message);
        }
        catch (RequestFailedException ex)
        {
            trangthaidangnhap.text = "dang nhap  co loi o day RequestFailedException__ SignInWithGooglePlayGamesAsync " + ex.Message;
            //  Debug.LogError("RequestFailedException occurred: " + ex.Message);
        }
    }
}
