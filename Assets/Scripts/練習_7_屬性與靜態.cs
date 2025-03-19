using UnityEngine;

public class 練習_7_屬性與靜態 : MonoBehaviour
{
    [SerializeField]
    private float _hp = 100;

    public float hp
    {
        get
        {
            if (_hp <= 0) Debug.Log("<color=#f33>玩家角色已死亡</color>");
            return _hp;
        }
    }

    private void Update()
    {
        Debug.Log(hp);
    }
}