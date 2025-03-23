using BAG.Tools;
using UnityEngine;

public class 練習_10_多型 : MonoBehaviour
{
    private void Awake()
    {
        var redPotion = new Potion("紅水");
        var bluePotion = new Potion("藍水");
        Equipment helmet = new Equipment("頭盔");
        redPotion.Use();
        bluePotion.Use(100);
        helmet.Use();
    }
}

public class Item
{
    public string name;

    public Item(string _name)
    {
        _name = name;
    }

    public virtual void Use()
    {
        LogSystem.LogWithColor($"{name} 道具，使用 Item 方法", "#f33");
    }
}

public class Potion : Item
{
    public Potion(string _name) : base(_name)
    {
    }

    public void Use(int increase)
    {
        LogSystem.LogWithColor($"{name} 藥水，使用 Potion 方法，恢復量：{increase}", "#3f3");
    }
}

public class Equipment : Item
{
    public Equipment(string _name) : base(_name)
    {
    }

    public override void Use()
    {
        LogSystem.LogWithColor($"{name} 裝備，使用 Equipment 方法", "#77f");
    }
}