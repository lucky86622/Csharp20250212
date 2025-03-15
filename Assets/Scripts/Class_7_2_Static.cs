using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 靜態 Static
/// </summary>
public class Class_7_2_Static : MonoBehaviour
{
    #region 變數與屬性
    // 成員：
    // 變數、屬性、方法

    // 非靜態變數
    public int inventoryWater = 10;
    // 靜態變數：修飾詞後面添加關鍵字 static
    // 靜態變數不顯示在屬性面板上
    public static int inventoryProp = 20;

    // 非靜態屬性
    public string skillMain => "火球術";
    // 靜態屬性
    public static string skillSecond => "治癒術";
    #endregion

    private float attack = 10;
    private static float mp = 100;

    private void Awake()
    {
        // inventoryWater = 7;
        // inventoryProp = 15;
        Debug.Log($"<color=#f31>藥水：{inventoryWater}</color>");
        Debug.Log($"<color=#f31>道具：{inventoryProp}</color>");
    }

    public void Punch()
    {
        Debug.Log("<color=#3f3>使用拳擊</color>");
        // 非靜態方法內可以存取所有成員
        Debug.Log($"<color=#f9e>非靜態攻擊力：{attack}</color>");
        Debug.Log($"<color=#f9e>靜態魔力：{mp}</color>");
    }

    public static void kick()
    {
        Debug.Log("<color=#3f3>使用踢擊</color>");
        // 靜態方法內只能存取靜態成員
        // 由於 attack 是非靜態所以無法存取 (導致錯誤)
        // Debug.Log($"<color=#f9e>非靜態攻擊力：{attack}</color>");
        Debug.Log($"<color=#f9e>靜態魔力：{mp}</color>");
    }

    private void Start()
    {
        // 在 Unity 內的差異
        // 場景切換時
        // 非靜態成員會被釋放 (還原為預設值)
        inventoryWater++;   // 藥水加一
        Debug.Log($"<color=#78f>藥水：{inventoryWater}</color>");
        // 靜態成員不會被釋放 (不會還原為預設值)
        inventoryProp ++;   // 道具加一
        Debug.Log($"<color=#78f>道具：{inventoryProp}</color>");
    }

    private void Update()
    {
        // 在 Game 畫面按下數字 1 會重新載入場景 (切換英文輸入法)
        // 如果按下數字 1 (左邊鍵盤ㄅ)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("課程_7_屬性與靜態");
        }
    }
}
