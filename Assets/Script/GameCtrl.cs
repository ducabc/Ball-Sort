using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour, IDataPersitance
{
    private static GameCtrl instance;
    public static GameCtrl Instance => instance;
    public TubeManager tubeManager;
    public GameObject WinUi;
    public int level;
    public int tubeCount;
    public int doKho;

    private void Awake()
    {
        if (GameCtrl.instance != null) Debug.LogError("Only 1 GameCtrl allow to exist");
        GameCtrl.instance = this;
    }
    private void Start()
    {
        WinUi.SetActive(false);
        LoadGame();
    }
    protected void Reset()
    {
        tubeManager = gameObject.GetComponentInChildren<TubeManager>();
        WinUi = GameObject.Find("WinGame");
    }
    protected void LoadGame()
    {
        if(level > 10)
        {
            Application.Quit();
        }
        Debug.Log("dau void load" + level);
        if (level < 6)
        {
            doKho = 2;
            tubeCount += level-1;
        }
        else
        {
            doKho = 1;
            tubeCount = tubeCount + level - 6;
        }
    }
    public void WinGameUi()
    {
        Time.timeScale = 0;
        float n = Time.time;
        if (n <= 15) Debug.Log("3 sao");
        else
        {
            if (n <= 30) Debug.Log("2 sao");
            else
            {
                if (n <= 45) Debug.Log("1 sao");
                else Debug.Log("0 sao");
            }
        }
        WinUi.SetActive(true);
    }

    public void NextLevel()
    {
        level++;
        DataPersitanceManager.Instance.SaveGame();
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadData(GameData data)
    {
        this.level = data.level;
    }

    public void SaveData(ref GameData data)
    {
        data.level = this.level;
    }
}
