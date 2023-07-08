using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;

public class BallCtrl : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public int idBall;
    protected void Reset()
    {
        LoadModel();
    }

    protected void LoadModel()
    {
        Transform model = transform.Find("Model");
        spriteRender = model.GetComponent<SpriteRenderer>();
    }

    public void SetModel(Sprite sprite)
    {
        spriteRender.sprite = sprite;
    }

    public void LoadIdBall()
    {
        idBall = spriteRender.sprite.GetInstanceID();
    }
}
