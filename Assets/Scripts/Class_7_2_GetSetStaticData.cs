using UnityEngine;

/// <summary>
/// 練習取得與設定靜態資料
/// </summary>
public class Class_7_2_GetSetStaticData : MonoBehaviour
{
    // 取得非靜態資料 (成員)
    // 1. 先定義要獲得資料類別的變數
    // 2. 透過變數取得非靜態資料 (成員)
    public Class_7_2_Static class_7_2;

    private void Awake()
    {
        // 變數名稱.非靜態成員
        // 取得非靜態變數
        Debug.Log($"<color=#f3d>非靜態成員：{class_7_2.inventoryWater}</color>");
        //取得非靜態屬性
        Debug.Log($"<color=#f3d>非靜態屬性：{class_7_2.skillMain}</color>");
        // 呼叫非靜態方法
        class_7_2.Punch();

        // 類別名稱.靜態成員
        // 取得靜態變數
        Debug.Log($"<color=#f3d>靜態成員：{Class_7_2_Static.inventoryProp}</color>");
        // 取得靜態屬性
        Debug.Log($"<color=#f3d>靜態屬性：{Class_7_2_Static.skillSecond}</color>");
        // 呼叫靜態方法
        Class_7_2_Static.kick();
    }

    public Class_7_2_Slime slimeGreen, slimeBlue;

    private void Start()
    {
        // 非靜態成員
        slimeGreen.hp -= 10;
        Debug.Log($"<color=#3f3>綠史萊姆 HP：{slimeGreen.hp}</color>");
        slimeBlue.hp -= 10;
        Debug.Log($"<color=#3f3>藍史萊姆 HP：{slimeBlue.hp}</color>");

        // 靜態成員
        // 靜態成員沒辦法透過個體存取
        // slimeGreen.moveSpeed = 3.5f;
        Class_7_2_Slime.moveSpeed = 3.5f;
        Debug.Log($"<color=#3f3>史萊姆移動速度：{Class_7_2_Slime.moveSpeed}</color>");
    }
}
