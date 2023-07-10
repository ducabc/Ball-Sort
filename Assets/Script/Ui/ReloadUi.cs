using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadUi : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
