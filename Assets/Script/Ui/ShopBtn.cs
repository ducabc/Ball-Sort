using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBtn : MonoBehaviour
{
    public Transform shopUI;
    private bool openShop = false;
    private void Reset()
    {
        shopUI = transform.Find("ShopUI");
        shopUI.gameObject.SetActive(false);
    }
    public void OpenShop()
    {
        if (!openShop)
        {
            shopUI.gameObject.SetActive(true);
            Time.timeScale = 0;
            openShop = true;
        }
        else
        {
            shopUI.gameObject.SetActive(false);
            Time.timeScale = 0;
            openShop = false;
        }
    }

}
