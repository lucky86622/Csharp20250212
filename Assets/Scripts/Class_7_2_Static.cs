using UnityEngine;

/// <summary>
/// 靜態 Static
/// </summary>
public class Class_7_2_Static : MonoBehaviour
{
    // 非靜態變數
    public int inventoryWater = 10;
    // 靜態變數：修飾詞後面添加關鍵字 static
    // 靜態變數不顯示在屬性面板上
    public static int inventoryProp = 20;

    private void Awake()
    {
        inventoryWater = 7;
        inventoryProp = 15;
        Debug.Log($"<color=#f31>藥水：{inventoryWater}</color>");
        Debug.Log($"<color=#f31>道具：{inventoryProp}</color>");
    }
}
