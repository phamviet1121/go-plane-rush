using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using TMPro;

public class IAPManager : MonoBehaviour
{
    public TextMeshProUGUI errorText;

    public list_sao list_sao;
    private string buy13k = "com.googleplayrun.goplanerush.buy13k";
    private string buy23k = "com.googleplayrun.goplanerush.buy23k";
    private string buy108k = "com.googleplayrun.goplanerush.buy108k";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == buy13k)
        {
            list_sao.save_int_sao += 500;
            list_sao.save_sao();
            list_sao.load_sao();
        }
        if (product.definition.id == buy23k)
        {
            list_sao.save_int_sao += 1000;
            list_sao.save_sao();
            list_sao.load_sao();
        }
        if (product.definition.id == buy108k)
        {
            list_sao.save_int_sao += 5000;
            list_sao.save_sao();
            list_sao.load_sao();
        }

    }


    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        // G?i h�m hi?n th? th�ng b�o l?i v� truy?n th�m t�n s?n ph?m
        ShowPurchaseFailureMessage(product, reason);
    }

    private void ShowPurchaseFailureMessage(Product product, PurchaseFailureReason reason)
    {
        string productName = product.definition.storeSpecificId; // T�n s?n ph?m c? th?
        string message = $"Thanh to�n cho s?n ph?m '{productName}' th?t b?i. Vui l�ng th? l?i.";

        // ??t th�ng b�o d?a tr�n l� do th?t b?i
        switch (reason)
        {
            case PurchaseFailureReason.PaymentDeclined:
                message = $"Thanh to�n cho s?n ph?m '{productName}' b? t? ch?i. Vui l�ng ki?m tra ph??ng th?c thanh to�n.";
                break;
            case PurchaseFailureReason.PurchasingUnavailable:
                message = $"Ch?c n?ng mua h�ng cho s?n ph?m '{productName}' hi?n kh�ng kh? d?ng. Vui l�ng th? l?i sau.";
                break;
            case PurchaseFailureReason.ExistingPurchasePending:
                message = $"?ang c� giao d?ch ch?a ho�n th�nh cho s?n ph?m '{productName}'. Vui l�ng ch? v� th? l?i.";
                break;
            case PurchaseFailureReason.UserCancelled:
                message = $"Giao d?ch cho s?n ph?m '{productName}' ?� b? h?y.";
                break;
            default:
                message = $"?� x?y ra l?i khi mua s?n ph?m '{productName}'. Vui l�ng th? l?i.";
                break;
        }

        // Hi?n th? th�ng b�o l?i l�n m�n h�nh
        errorText.text = message;
        errorText.enabled = true;

        // T?t th�ng b�o sau 3 gi�y
        StartCoroutine(HideErrorTextAfterDelay(3f));
    }

    private IEnumerator HideErrorTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        errorText.enabled = false; // ?n th�ng b�o sau kho?ng th?i gian ?� ??t
    }
}
