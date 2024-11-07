using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _showAdButton;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    string _adUnitId = null;
    public Summary Summary;
    public float _cooldownTime = 300f; 

    void Awake()
    {
#if UNITY_ANDROID
        _adUnitId = _androidAdUnitId; 
#endif
        _showAdButton.interactable = false; 
    }
    private void Start()
    {
        LoadAd();
    }
    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            _showAdButton.onClick.AddListener(ShowAd);
            _showAdButton.interactable = true;
        }
    }

    public void ShowAd()
    {
        _showAdButton.interactable = false; 
        Advertisement.Show(_adUnitId, this);
        LoadAd();
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            GrantReward();
        }
    }

    void GrantReward()
    {
        Summary.Summary_gameplay += Summary.Summary_gameplay;
        Summary.gameoverright();
        StartCoroutine(AdCooldownRoutine()); 
    }

    private IEnumerator AdCooldownRoutine()
    {
        yield return new WaitForSeconds(_cooldownTime);
        _showAdButton.interactable = true; 
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        _showAdButton.onClick.RemoveAllListeners(); 
    }
}
