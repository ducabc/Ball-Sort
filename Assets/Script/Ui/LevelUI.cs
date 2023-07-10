using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{

    public Text textLevel;
    // Start is called before the first frame update

    private void Start()
    {
        textLevel.text ="LEVEL: " +  GameCtrl.Instance.level.ToString();
    }
}
