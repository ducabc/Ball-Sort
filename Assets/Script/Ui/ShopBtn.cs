using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBtn : MonoBehaviour
{
    public Transform shopUI;
    private void Reset()
    {
        shopUI = transform.Find("ShopUI");
        shopUI.gameObject.SetActive(false);
    }
    public void OpenShop()
    {
        shopUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitShop()
    {
        shopUI?.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
