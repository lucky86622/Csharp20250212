using UnityEngine;

/// <summary>
/// 結構：通常用來保存資料，不能繼承 MonoBehaviour
/// </summary>
public struct Class_8_2_PlayerData
{
    public int lv;
    public float hp;

    public Class_8_2_PlayerData(int _lv, float _hp)
    {
        lv = _lv;
        hp = _hp;
    }
}
