using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadUi : MonoBehaviour
{
    public void ReloadGame()
    {
        AudioManager.Instance.PlaySound("Reset");
        SceneManager.LoadScene("SampleScene");
    }
}
