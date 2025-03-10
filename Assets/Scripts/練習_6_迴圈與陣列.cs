using UnityEngine;

public class 練習_6_迴圈與陣列 : MonoBehaviour
{
    public string[,,] pet =
    {
       { {"皮卡丘", "沙奈朵", "長耳兔" },{"烈咬陸鯊", "快龍", "三首惡龍" } },
       { {"史烏", "露希妲", "威爾" },{"菇菇寶貝", "頓凱爾", "戴斯克" } },
       {{"蓋倫", "拉克絲", "李星" },{"趙信", "歐拉夫", "提摩" } }
    };
    private void Start()
    {
        Debug.Log($"<color=#f93>{pet[0, 0, 0]}</color>");
        Debug.Log($"<color=#f93>{pet[1, 1, 0]}</color>");
        Debug.Log($"<color=#f93>{pet[2, 0, 0]}</color>");
        Debug.Log($"<color=#f93>{pet[1, 0, 2]}</color>");
    }
}
