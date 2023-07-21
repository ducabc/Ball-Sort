using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    public BallObj ballObj;
    public Image sprite;
    private void Reset()
    {
        ballObj = Resources.Load<BallObj>($"BackGround");
        sprite = this.GetComponent<Image>();
    }

    public void Start()
    {
        sprite.sprite = ballObj.balls[Random.Range(0,12)];
    }
}
