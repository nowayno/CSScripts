using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickScripts : MonoBehaviour
{
    public GameObject go;
    /// <summary>
    /// 显示房间面板
    /// </summary>
    public void ShowIPUI()
    {
        go.SetActive(true);
    }
    /// <summary>
    /// 进入游戏
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("Animator Controller");
        PlayerPrefs.SetInt("NetPlayer", 0);
    }
    /// <summary>
    /// 选择角色
    /// </summary>
    /// <param name="player">数字表示英雄</param>
    public void SetPlayer(int player)
    {
        PlayerPrefs.SetInt("Player", player);
    }
    /// <summary>
    /// 退出游戏
    /// </summary>
    public void EndGame()
    {
        Application.Quit();
    }
}
