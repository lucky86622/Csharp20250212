using UnityEngine;

/// <summary>
/// 類別 Class
/// </summary>
public class Class_8_1_Class : MonoBehaviour
{
    // 類別：
    // 用來定義一個物件以及他所擁有的資料與功能 (成員)

    private void Awake()
    {
        Class_8_1_NPC npcJack = new Class_8_1_NPC();
        Class_8_1_NPC npcKID = new Class_8_1_NPC("KID");

        npcJack.Logname();
        npcKID.Logname();
    }
}
