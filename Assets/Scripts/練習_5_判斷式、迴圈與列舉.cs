using UnityEngine;

public class 練習_5_判斷式 : MonoBehaviour
{
    [SerializeField, Header("血量"), Range(0, 100)]   
    private int Hp = 100;

    private void Update()
    {
        switch (Hp)
        {
            default:
                break;
        }
    }
}
