using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinUI : MonoBehaviour, IDataPersitance
{
    public Transform star;
    public Image coinImages;
    public Text coinBonus;
    private int c =0;
    private void Reset()
    {
        star = transform.Find("Star");
        Transform coin = transform.Find("Coin");
        coinImages = star.GetComponentInChildren<Image>();
        coinBonus = coin.GetComponentInChildren<Text>();
        coinImages.gameObject.SetActive(false);
    }
    private void Start()
    {
        TotalStar();
        TotalCoin();
    }

    public void StarGame(int n)
    {
        for(int i = 0; i < n; i++)
        {
            Image newImage = Instantiate(coinImages, star.transform);
            newImage.gameObject.SetActive(true);
        }
        coinBonus.text = $"x {c}";
    }

    protected void TotalCoin()
    {
        GameCtrl.Instance.coin += c;
    }

    protected void TotalStar()
    {
        float n = Time.time;
        
        if (n <= 15)
        {
            c = 10;
            StarGame(3);
        }
        else
        {
            if (n <= 30)
            {
                c = 6;
                StarGame(2);
            }
            else
            {
                if (n <= 45)
                {
                    c = 4;
                    StarGame(1);
                }
                else
                {
                    c = 1;
                    StarGame(0);
                }
            }
        }
    }
    public void NextLevel()
    {
        GameCtrl.Instance.level++;
        DataPersitanceManager.Instance.SaveGame();
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadData(GameData data)
    {
        GameCtrl.Instance.level = data.level;
        GameCtrl.Instance.coin = data.coin;
    }

    public void SaveData(ref GameData data)
    {
        data.level = GameCtrl.Instance.level;
        data.coin = GameCtrl.Instance.coin;
    }
}
