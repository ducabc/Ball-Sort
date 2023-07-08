using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tube : MonoBehaviour
{
    public List<TubeHolder> tubeCtrls;
    public int ballOnTube=0;

    private void Start()
    {
        LoadBallPotion(this.transform.position);
        SpamBall();
    }

    protected void LoadBallPotion(Vector3 posSpam)
    {
        posSpam = new Vector3(posSpam.x, posSpam.y - 1.4f);
        
        for (int i = 0; i < 4; i++)
        {
            posSpam.y += 0.5f;
            TubeHolder tube = new TubeHolder();
            tube.position = posSpam;
            tubeCtrls.Add(tube);
        }
    }

    protected void SpamBall()
    {
        BallManager.Instance.SpamBall(transform, tubeCtrls);
    }

    protected void OnMouseDown()
    {
        GetBallOnTop(tubeCtrls);
    }

    protected void GetBallOnTop(List<TubeHolder> tubeHolders)
    {
        ballOnTube = 0;
        foreach(TubeHolder tubeHolder in tubeHolders)
        {
            if(tubeHolder.ballCtrl !=null) ballOnTube++;
        }
        if (ballOnTube > 0)
        {
            Debug.Log("On Mouse down" + tubeHolders[ballOnTube - 1].ballCtrl.idBall.ToString());
            TubeManager.Instance.GetTubeSelect(transform, tubeHolders[ballOnTube - 1].ballCtrl, tubeHolders[ballOnTube].position);
        }
    }
}
