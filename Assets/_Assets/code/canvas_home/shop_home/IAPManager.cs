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
        // Gọi hàm hiển thị thông báo lỗi và truyền thêm tên sản phẩm
        ShowPurchaseFailureMessage(product, reason);
    }

    private void ShowPurchaseFailureMessage(Product product, PurchaseFailureReason reason)
    {
        string productName = product.definition.storeSpecificId; // Tên sản phẩm cụ thể
        string message = $"Thanh toán cho sản phẩm '{productName}' thất bại. Vui lòng thử lại.";

        // Đặt thông báo dựa trên lý do thất bại
        switch (reason)
        {
            case PurchaseFailureReason.PaymentDeclined:
                message = $"Thanh toán cho sản phẩm '{productName}' bị từ chối. Vui lòng kiểm tra phương thức thanh toán.";
                break;
            case PurchaseFailureReason.PurchasingUnavailable:
                message = $"Chức năng mua hàng cho sản phẩm '{productName}' hiện không khả dụng. Vui lòng thử lại sau.";
                break;
            case PurchaseFailureReason.ExistingPurchasePending:
                message = $"Đang có giao dịch chưa hoàn thành cho sản phẩm '{productName}'. Vui lòng chờ và thử lại.";
                break;
            case PurchaseFailureReason.UserCancelled:
                message = $"Giao dịch cho sản phẩm '{productName}' đã bị hủy.";
                break;
            default:
                message = $"Đã xảy ra lỗi khi mua sản phẩm '{productName}'. Vui lòng thử lại.";
                break;
        }

        // Hiển thị thông báo lỗi lên màn hình
        errorText.text = message;
        errorText.enabled = true;

        // Tắt thông báo sau 3 giây
        StartCoroutine(HideErrorTextAfterDelay(3f));
    }

    private IEnumerator HideErrorTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        errorText.enabled = false; // Ẩn thông báo sau khoảng thời gian đã đặt
    }
}
