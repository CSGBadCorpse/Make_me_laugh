using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("退出游戏");
        Application.Quit();
    }
}
