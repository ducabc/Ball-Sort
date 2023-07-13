using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{

    public Text textLevel;
    public Text coinText;
    // Start is called before the first frame update

    private void Reset()
    {
        Transform coin = transform.Find("Coin");
        coinText = coin.GetComponentInChildren<Text>();
    }
    private void Start()
    {
        textLevel.text ="LEVEL: " +  GameCtrl.Instance.level.ToString();
        coinText.text ="x " +  GameCtrl.Instance.coin.ToString();
    }
}
