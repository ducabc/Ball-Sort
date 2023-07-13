using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBtn : MonoBehaviour ,IDataPersitance
{
    public Transform shopUI;
    public List<int> idBallObj;
    private void Reset()
    {
        shopUI = transform.Find("ShopUI");
        shopUI.gameObject.SetActive(false);
    }
    public void OpenShop()
    {
        shopUI.gameObject.SetActive(true);
    }
    public void BuyBall()
    {
        idBallObj.Add(int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name));
        DataPersitanceManager.Instance.SaveGame();
    }

    public void LoadData(GameData data)
    {
        this.idBallObj = data.idBallObj;
    }

    public void SaveData(ref GameData data)
    {
        data.idBallObj = this.idBallObj;
    }

}
