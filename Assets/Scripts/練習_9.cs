using BAG.Tools;
using System.Globalization;
using UnityEngine;

public class 練習_9 : MonoBehaviour
{
    private void Awake()
    {
        float float1 = -999.321f;
        sbyte byte1 = (sbyte)float1;
        LogSystem.LogWithColor(byte1, "#6f6");
    }
}
