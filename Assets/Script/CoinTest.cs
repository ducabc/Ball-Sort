using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTest : MonoBehaviour, IDataPersitance
{
    public Text textLevel;
    public int Level = 0;
    // Start is called before the first frame update
    void Start()
    {
        textLevel  = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Level++;
            textLevel.text = "Level" + Level;
        }
    }

    public void LoadData(GameData data)
    {
        this.Level = data.level;
    }

    public void SaveData(ref GameData data)
    {
        data.level = this.Level;
    }
}
