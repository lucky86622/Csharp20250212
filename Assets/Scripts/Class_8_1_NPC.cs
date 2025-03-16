using UnityEngine;

/// <summary>
/// NPC 類別：NPC 名稱與對話內容資料，有輸出 NPC 名稱與說話的功能
/// </summary>
public class Class_8_1_NPC
{
    private string name;
    private string dialogue;

    // 建構子：沒有傳回類型，名稱與類別相同的公開方法
    // 預設建構子：沒有參數
    public Class_8_1_NPC()
    {
        Debug.Log("<color=#f3d>預設建構子</color>");
    }
    // 建構子的簡寫
    public Class_8_1_NPC(string _name) => name = _name;

    public Class_8_1_NPC(string _name, string _dialogue)
    {
        name = _name;
        dialogue = _dialogue;
        Debug.Log("<color=#f3d>有參數的建構子</color>");
    }

    public void Logname()
    {
        Debug.Log($"<color=#3f3>NPC 的名稱：{name}</color>");
    }

    public void Talk()
    {
        Debug.Log($"<color=#3f3>{dialogue}</color>");
    }
}
