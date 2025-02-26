using UnityEngine;

public class 練習_4_方法 : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log($"布林值：{ReturnTrue()}");
        Debug.Log($"布林值：{ReturnFalse()}");
    }
    private bool ReturnTrue()
    {
        return true;
    }
    private bool ReturnFalse()
    {
        return false;
    }
}
