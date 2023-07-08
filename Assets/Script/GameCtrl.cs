using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{

    private static GameCtrl instance;
    public static GameCtrl Instance => instance;
    public TubeManager tubeManager;
    public int tubeCount =4;

    private void Awake()
    {
        if (GameCtrl.instance != null) Debug.LogError("Only 1 GameCtrl allow to exist");
        GameCtrl.instance = this;
    }
    protected void Reset()
    {
        tubeManager = gameObject.GetComponentInChildren<TubeManager>();
    }
}
