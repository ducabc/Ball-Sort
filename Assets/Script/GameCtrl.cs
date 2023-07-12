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
    private int coin;

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
        if (n <= 15)
        {
            Debug.Log("3 sao");
            Star(10);
        }
        else
        {
            if (n <= 30)
            {
                Debug.Log("2 sao");
                Star(6);
            }
            else
            {
                if (n <= 45)
                {
                    Debug.Log("1 sao");
                    Star(4);
                }
                else 
                {
                    Debug.Log("0 sao");
                    Star(1);
                }
            }
        }
        WinUi.SetActive(true);
    }
    private void Star(int n)
    {
        coin = coin + n;
        Debug.Log("Tong so coin dang co laf: " + coin);
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
        this.coin = data.coin;
    }

    public void SaveData(ref GameData data)
    {
        data.level = this.level;
        data.coin = this.coin;
    }
}
