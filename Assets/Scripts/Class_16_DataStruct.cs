using BAG.Tools;
using NUnit.Framework;
using System.Collections.Generic;      // 有許多資料結構的命名空間
using UnityEngine;

/// <summary>
/// 資料結構
/// </summary>
public class Class_16_DataStruct : MonoBehaviour
{
    #region 清單
    // 陣列
    public int[] attacks = { 10, 15, 7 };
    public float[] defens = { 1.5f, 7.5f, 0.3f };

    // 清單：泛型集合
    public List<int> speeds = new List<int>() { 3, 9, 7 };
    public List<string> props = new List<string>() { "藥水", "地圖" };
    public List<float> playerDefens; 
    #endregion

    private void Awake()
    {
        #region 清單
        // 清單存取：與陣列相同
        LogSystem.LogWithColor($"第三筆速度：{speeds[2]}", "#3f3");
        speeds[0] = 10;
        LogSystem.LogWithColor($"第一筆速度：{speeds[0]}", "#3f3");
        // 陣列初始化後就無法增減長度
        // 增加一筆道具
        props.Add("寶劍");
        // 刪除第一筆道具
        props.RemoveAt(0);
        // 添加頭盔到編號 1 上
        props.Insert(1, "頭盔");

        foreach (var prop in props)
        {
            LogSystem.LogWithColor($"道具：{prop}", "#f93");
        }

        // 使用結構子帶入陣列
        playerDefens = new List<float>(defens);
        // 順序：由小到大
        playerDefens.Sort();
        // 反順序：由大到小
        playerDefens.Reverse();

        foreach (var item in playerDefens)
        {
            LogSystem.LogWithColor($"資料：{item}", "#f93");
        }

        // Count 指清單內的資料，根據 Add 或 Remove 改變
        LogSystem.LogWithColor($"數量：{props.Count}", "#77f");
        // Capacity 指清單內的容量，系統自動分配，預設為 4 並且以倍數成長 (C# 各版本不同)
        LogSystem.LogWithColor($"容量：{props.Capacity}", "#77f");

        List<int> numbers = new List<int>();

        for (int i = 0; i < 20; i++)
        {
            numbers.Add(i);
            LogSystem.LogWithColor($"數量：{numbers.Count}", "#3a3");
            LogSystem.LogWithColor($"容量：{numbers.Capacity}", "#f39");
        }
        #endregion

        #region 堆疊
        // 堆疊：先進先出，類似椅子堆在一起 (卡牌遊戲的抽卡)
        Stack<string> enemys = new Stack<string>();
        // 放資料進入堆疊
        enemys.Push("史萊姆");
        enemys.Push("哥布林");
        LogStack<string>(enemys);
        // 拿資料並且不移除
        enemys.Peek();
        LogStack<string>(enemys);
        // 拿資料並移除
        enemys.Pop();
        LogStack<string>(enemys);
        // 判斷是否包含某筆資料
        LogSystem.LogWithColor($"{enemys.Contains("哥布林")}", "#3f6");
        // 清除所有資料
        enemys.Clear();
        LogStack<string>(enemys); 
        #endregion

        // Queue 佇列：先進先出，先放進來的資料先被拿出來 (回合遊戲的攻擊順序)
        Queue<string> player = new Queue<string>();
        player.Enqueue("盜賊");
        player.Enqueue("法師");
        player.Enqueue("戰士");
        LogQueue<string>(player);
        // 拿東西不刪除，與堆疊的 Peek 相同
        LogSystem.LogWithColor(player.Peek(), "#f33");
        LogQueue<string>(player);
        // 拿東西並刪除，與堆疊的 Pop 相同
        LogSystem.LogWithColor(player.Dequeue(), "#f33");
        LogQueue<string>(player);
    }

    private void LogStack<T>(Stack<T> stack)
    {
        LogSystem.LogWithColor("----------", "#fff");
        foreach (var item in stack)
        {
            LogSystem.LogWithColor($"堆疊資料：{item}", "#f77");
        }
    }

    private void LogQueue<T>(Queue<T> queue)
    {
        LogSystem.LogWithColor("----------", "#fff");
        foreach (var item in queue)
        {
            LogSystem.LogWithColor($"佇列資料：{item}", "#7f7");
        }
    }
}
