using UnityEngine;

/// <summary>
/// 反覆運算陳述式：迴圈
/// for、foreach、do 與 while
/// </summary>
public class Class_6_1_Iteration : MonoBehaviour
{
    private void Awake()
    {
        // 迴圈請在一次性事件內使用 Awake、Start
        // while 迴圈：當布林值為 true 時會持續執行
        // while (布林值) { 程式區塊 }
        // 無限迴圈：布林值一直是 true
        // 宣告區域變數 i 為 0
        int i = 0;
        i = 5;                     // 測試 while 與 do 的差異
        // 當 i < 5 就執行 {}
        while (i < 5)
        {
            Debug.Log($"<color=#f33>while 迴圈，i：{i}</color>");
            // i 遞增 (i + 1)
            i++;
        }

        // do 迴圈：
        // do { 程式區塊 } while {布林值}
        int j = 0;
        j = 5;                     // 測試 while 與 do 的差異
        do
        {
            Debug.Log($"<color=#f79>do 迴圈，j：{j}</color>");
            j++;
        } 
        while (j < 5);

        // for 迴圈：
        // for (初始值；布林值；迭代器) { 程式區塊 }
        for (int k = 0; k < 5; k++)
        {
            Debug.Log($"<color=#78f>for 迴圈：k：{k}</color>");
        }
    }
}
