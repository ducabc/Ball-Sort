using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBall : MonoBehaviour
{
    public Transform image;
    public Text textItem;
    public int id;

    private bool canBuy = true;

    private void Start()
    {
        image = transform.Find("Image");
        textItem = image.GetComponentInChildren<Text>();
        if (GameCtrl.Instance.listBallObj.Contains(id))
        {
            textItem.text = "Buyed";
            canBuy = false;
        }
        else
        {
            textItem.text = (id * 2).ToString();
        }
    }

    public void BuyItem()
    {
        if (canBuy && GameCtrl.Instance.coin >= (id * 2))
        {
            textItem.text = "Buyed";
            canBuy=false;
            GameCtrl.Instance.AddIdBall(id);
            GameCtrl.Instance.totalCoin(-id * 2);
        }
    }
}
