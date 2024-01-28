using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewStartButton : MonoBehaviour
{
    public void onClicked()
    {
        SceneManager.LoadScene("UIScene");
        Time.timeScale = 1f;
    }
}
