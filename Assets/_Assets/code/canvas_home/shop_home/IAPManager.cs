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
        // G?i hàm hi?n th? thông báo l?i và truy?n thêm tên s?n ph?m
        ShowPurchaseFailureMessage(product, reason);
    }

    private void ShowPurchaseFailureMessage(Product product, PurchaseFailureReason reason)
    {
        string productName = product.definition.storeSpecificId; // Tên s?n ph?m c? th?
        string message = $"Thanh toán cho s?n ph?m '{productName}' th?t b?i. Vui lòng th? l?i.";

        // ??t thông báo d?a trên lý do th?t b?i
        switch (reason)
        {
            case PurchaseFailureReason.PaymentDeclined:
                message = $"Thanh toán cho s?n ph?m '{productName}' b? t? ch?i. Vui lòng ki?m tra ph??ng th?c thanh toán.";
                break;
            case PurchaseFailureReason.PurchasingUnavailable:
                message = $"Ch?c n?ng mua hàng cho s?n ph?m '{productName}' hi?n không kh? d?ng. Vui lòng th? l?i sau.";
                break;
            case PurchaseFailureReason.ExistingPurchasePending:
                message = $"?ang có giao d?ch ch?a hoàn thành cho s?n ph?m '{productName}'. Vui lòng ch? và th? l?i.";
                break;
            case PurchaseFailureReason.UserCancelled:
                message = $"Giao d?ch cho s?n ph?m '{productName}' ?ã b? h?y.";
                break;
            default:
                message = $"?ã x?y ra l?i khi mua s?n ph?m '{productName}'. Vui lòng th? l?i.";
                break;
        }

        // Hi?n th? thông báo l?i lên màn hình
        errorText.text = message;
        errorText.enabled = true;

        // T?t thông báo sau 3 giây
        StartCoroutine(HideErrorTextAfterDelay(3f));
    }

    private IEnumerator HideErrorTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        errorText.enabled = false; // ?n thông báo sau kho?ng th?i gian ?ã ??t
    }
}
