using UnityEngine;

public class 練習_8_類別 : MonoBehaviour
{
    private void Awake()
    {
        Practice_8_Boss bossDragon = new Practice_8_Boss("烈咬陸鯊", "地震", 239);
        Practice_8_Boss bossGhost = new Practice_8_Boss("雪妖女", "暴風雪", 138);

        Debug.Log($"<color=#f93>{bossDragon.name}, 招式：{bossDragon.skill}</color>");
        Debug.Log($"<color=#f93>{bossGhost.name}, 招式：{bossGhost.skill}</color>");
    }
}

public class Practice_8_Boss
{
    public string name;
    public string skill;
    public float hp;

    public Practice_8_Boss(string _name, string _skill, float _hp)
    {
        name = _name;
        skill = _skill;
        hp = _hp;
    }
}