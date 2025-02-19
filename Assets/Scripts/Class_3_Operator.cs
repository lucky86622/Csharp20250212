using UnityEngine;
/// <summary>
/// 課程 3 : 運算子
/// 補充 : Unity 欄位屬性，Unity 事件
/// </summary>
public class Class_3_Operator : MonoBehaviour
{
    #region 基本的欄位屬性
    // C# 變數 = 欄位 Field
    // 欄位屬性 Field Attritube
    // [標題(標題文字)]：在屬性面板上顯示標題文字
    [Header("等級")]
    public int lv = 1;
    // [提示(提示文字)]：在屬性面板滑鼠停留變數上時顯示
    [Tooltip("這是角色的移動速度，不建議超過 100。")]
    public float moveSpeed = 2.5f;
    //[範圍(最小,最大)]：幫數值範圍添加範圍 (面板上改為滑桿)
    [Range(1, 100)]
    public byte count = 10;
    // 範圍不能使用在非數值類型上，會顯示 "Use Range With..."
    [Range(0, 10)]
    public string weapon = "匕首";
    // [文字範圍(最小行,最大行)]：使用在字串上，設定面板上的文字框範圍
    [TextArea(2, 5)]
    public string itemDescription = "這裡是道具的描述，這裡是道具的描述，這裡是道具的描述。";
    #endregion

    // 多個欄位屬性
    [Header("血量")][Range(0, 999)]
    public int hp = 100;
    [Header("攻擊力"), Range(0, 100)]
    public float attack = 30.5f;
    // [在屬性面板隱藏]：將公開變數隱藏
    [HideInInspector]
    public string password = "我是密碼";
    // [序列化欄位]：將私人變數顯示
    [SerializeField]
    private float mp = 500;
}
