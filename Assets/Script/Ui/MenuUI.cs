using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject menuUi;

    private void Start()
    {
        
    }

    public void OpenMenu()
    {
        menuUi.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitMenu()
    {
        menuUi.SetActive(false);
        Time.timeScale = 1;
    }
}
