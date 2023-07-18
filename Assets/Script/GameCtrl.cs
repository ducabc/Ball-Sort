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
    public List<int> listBallObj;
    public LevelUI levelUI;
    public int level;
    public int tubeCount;
    public int doKho;
    public int coin;
    public float timeCount = 0;
    
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
        WinUi = GameObject.FindObjectOfType<WinUI>().gameObject;
        levelUI = GameObject.FindObjectOfType<LevelUI>();
        tubeCount = 4; doKho = 2;
    }
    protected void LoadGame()
    {
        if(level > 10)
        {
            Application.Quit();
        }
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
        timeCount = Time.time;
        WinUi.SetActive(true);
    }

    public void AddIdBall(int n)
    {
        if (listBallObj.Count == 0)
        {
            listBallObj.Add(n);
        }
        else
        {
            if (listBallObj.Contains(n)) return;
            else
            {
                listBallObj.Add(n);
            }
        }
    }

    public void totalCoin(int n)
    {
        coin += n;
        levelUI.updateCoin();
    }

    public void LoadData(GameData data)
    {
        this.level = data.level;
        this.coin = data.coin;
        this.listBallObj = data.idBallObj;
    }

    public void SaveData(ref GameData data)
    {
        data.level = this.level;
        data.coin = this.coin;
        data.idBallObj = this.listBallObj;
    }
}
