using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;

public class BallCtrl : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public GameObject spriteSelect;
    public int idBall;
    protected void Reset()
    {
        LoadModel();
        LoadSelect();
    }

    protected void LoadModel()
    {
        Transform model = transform.Find("Model");
        spriteRender = model.GetComponent<SpriteRenderer>();
    }
    protected void LoadSelect()
    {
        Transform model = transform.Find("Circle");
        spriteSelect = model.gameObject;
    }

    public void SelectBall(bool active)
    {
        spriteSelect.SetActive(active);
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
