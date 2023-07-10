using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour, IDataPersitance
{
    private static GameCtrl instance;
    public static GameCtrl Instance => instance;
    public TubeManager tubeManager;
    public int level;
    public int tubeCount;
    public int doKho;

    private void Awake()
    {
        if (GameCtrl.instance != null) Debug.LogError("Only 1 GameCtrl allow to exist");
        GameCtrl.instance = this;
        //DataPersitanceManager.Instance.LoadGame();
        LoadGame();
    }
    protected void Reset()
    {
        tubeManager = gameObject.GetComponentInChildren<TubeManager>();
    }
    protected void LoadGame()
    {
        Debug.Log("dau void load" + level);
        if (level < 6)
        {
            doKho = 2;
            tubeCount += level;
        }
        else
        {
            doKho = 1;
            tubeCount = tubeCount + level - 5;
        }
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
