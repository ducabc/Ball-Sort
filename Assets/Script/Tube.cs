using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tube : MonoBehaviour
{
    public List<TubeHolder> tubeHolder;
    public List<BallCtrl> ballInTube;
    public bool prefect = false;
    private int ballOnTube;

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
            tubeHolder.Add(tube);
        }
    }

    public void RefreshBallPotions()
    {
        LoadBallInTube();
        int i;
        for (i = 0; i < 4; i++)
        {
            if (tubeHolder[i].ballCtrl == null)
                break;
        }
        if (i <= ballInTube.Count) tubeHolder[i].ballCtrl = ballInTube[i];
        else tubeHolder[i-1].ballCtrl = null;

    }

    protected void LoadBallInTube()
    {
        if (ballInTube.Count != 0)
            ballInTube.Clear();
        ballInTube.AddRange(transform.GetComponentsInChildren<BallCtrl>());
        ballOnTube = ballInTube.Count;
    }

    protected void SpamBall()
    {
        BallManager.Instance.SpamBall(transform, tubeHolder);
        LoadBallInTube();
    }

    protected void OnMouseDown()
    {
        if (!prefect)
        {
            GetTubeHolderTop(tubeHolder);
            TubeManager.Instance.GetTubeSelect(this);
            CheckWin();
        }
    }

    protected void GetTubeHolderTop(List<TubeHolder> tubeHolders)
    {
        ballOnTube = 0;
        foreach(TubeHolder tubeHolder in tubeHolders)
        {
            if(tubeHolder.ballCtrl !=null) ballOnTube++;
        }
    }

    public BallCtrl GetBallOnTop()
    {
        BallCtrl ball = new BallCtrl();
        if (ballOnTube == 0)
        {
            ball = null;
        }
        else ball = tubeHolder[ballOnTube - 1].ballCtrl;
        return ball;
    }

    public Vector3 GetPositionOnTop()
    {
        Vector3 positions;
        if (ballOnTube == 4)
        {
            positions = Vector3.zero;
        }
        else positions = tubeHolder[ballOnTube].position;
        return positions;
    }

    public bool CheckWin()
    {
        int id;
        if(ballOnTube == 4)
        {
            id = ballInTube[0].idBall;
            foreach (BallCtrl ballCtrl in ballInTube)
            {
                if (ballCtrl.idBall != id)
                {
                    prefect = false;
                    break;
                }
                else prefect = true;
            }
        }
        return prefect;
    }
}
