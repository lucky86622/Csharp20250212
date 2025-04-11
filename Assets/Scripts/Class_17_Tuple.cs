using BAG.Tools;
using UnityEngine;

/// <summary>
/// 元組
/// </summary>
public class Class_17_Tuple : MonoBehaviour 
{
    private void Awake()
    {
        // 元組：儲存多筆不同類型的資料
        // 宣告方式 1：指定類型與名稱
        (string name, int cost, int index) card1 = ("史萊姆", 1, 7);
        LogSystem.LogWithColor($"{card1.name} | 消耗：{card1.cost} | 編號：{card1.index}", "#f49");

        // 宣告方式 2：指定類型
        // 取得元組資料時使用 Item1 ~ ItemN
        (string, int, int) card2 = ("哥布林", 2, 23);
        LogSystem.LogWithColor($"{card2.Item1} | 消耗：{card2.Item2} | 編號：{card2.Item3}", "#f49");

        // 宣告方式 3：使用 var
        var card3 = ("樹精", 4, 50);
        LogSystem.LogWithColor($"{card3.Item1} | 消耗：{card3.Item2} | 編號：{card3.Item3}", "#f49");

        // 宣告方式 4：使用 var 以及指名
        var card4 = (name: "蝙蝠", cost: 2, index: 6);
        LogSystem.LogWithColor($"{card4.name} | 消耗：{card4.cost} | 編號：{card4.index}", "#f49");

        UseCard(card1);
        UseCard(card2);
        UseCard(("暴龍", 7, 199));

        var cardUpdate = UpdateCardCost(card1);
        LogSystem.LogWithColor($"{cardUpdate.name} | 消耗：{cardUpdate.cost} | 編號：{cardUpdate.index}", "#f49");

        LogSystem.LogWithColor($"{cardUpdate == card1}", "#79f");
        LogSystem.LogWithColor($"{cardUpdate != card1}", "#79f");
    }

    /// <summary>
    /// 使用卡牌
    /// </summary>
    /// <param name="card"></param>
    private void UseCard((string name, int cost, int index) card)
    {
        LogSystem.LogWithColor($"消耗 {card.cost} 使用卡牌：{card.name}", "#7f7");
    }
    
    /// <summary>
    /// 降低卡牌消耗
    /// </summary>
    /// <param name="card">卡牌</param>
    /// <returns>降低消耗的卡牌</returns>
    private (string name, int cost, int index) UpdateCardCost((string name, int cost, int index) card)
    {
        card.name = card.name + " 降低消耗版本";
        card.cost -= 1;
        return card;
    }
}
