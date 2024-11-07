using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAdsFullButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _showAdsFullButton;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    string _adUnitId = null;
    public list_sao List_sao;

    void Awake()
    {
#if UNITY_ANDROID
        _adUnitId = _androidAdUnitId; 
#endif
        _showAdsFullButton.interactable = false; 
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
            _showAdsFullButton.onClick.AddListener(ShowAd);
            _showAdsFullButton.interactable = true; 
        }
    }

    public void ShowAd()
    {
        _showAdsFullButton.interactable = false; 
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
        List_sao.save_int_sao += 44;
        List_sao.save_sao();         
        List_sao.load_sao();        
        _showAdsFullButton.interactable = true; 
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
        _showAdsFullButton.onClick.RemoveAllListeners(); 
    }
}
