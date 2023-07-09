using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour
{

    private static GameCtrl instance;
    public static GameCtrl Instance => instance;
    public TubeManager tubeManager;
    public int level = 0;
    public int tubeCount;
    public int doKho = 2;

    private void Awake()
    {
        if (GameCtrl.instance != null) Debug.LogError("Only 1 GameCtrl allow to exist");
        GameCtrl.instance = this;
        SetDataGame();
        tubeCount = PlayerPrefs.GetInt("TUBECOUNT");
    }
    protected void Reset()
    {
        tubeManager = gameObject.GetComponentInChildren<TubeManager>();
    }

    protected void SetDataGame()
    {
        level++;
        PlayerPrefs.SetInt("TUBECOUNT", 4 + level - 1);
        PlayerPrefs.SetInt("LEVEL", 2);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
