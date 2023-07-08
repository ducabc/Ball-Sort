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
        Debug.Log("bong rong tai vi tri: " + i);
        Debug.Log("tong so bong trong cot: " + ballInTube.Count);
        if (i <= ballInTube.Count) tubeHolder[i].ballCtrl = ballInTube[i];
        else tubeHolder[i-1].ballCtrl = null;

    }

    protected void LoadBallInTube()
    {
        if (ballInTube.Count != 0)
            ballInTube.Clear();
        ballInTube.AddRange(transform.GetComponentsInChildren<BallCtrl>());
    }

    protected void SpamBall()
    {
        BallManager.Instance.SpamBall(transform, tubeHolder);
    }

    protected void OnMouseDown()
    {
        GetBallOnTop(tubeHolder);
    }

    protected void GetBallOnTop(List<TubeHolder> tubeHolders)
    {
        BallCtrl ball = new BallCtrl();
        Vector3 positions;
        ballOnTube = 0;
        foreach(TubeHolder tubeHolder in tubeHolders)
        {
            if(tubeHolder.ballCtrl !=null) ballOnTube++;
        }
        if (ballOnTube == 0)
        {
            Debug.Log("stop here");
            ball = null;
            positions = tubeHolders[ballOnTube].position;
        }
        else ball = tubeHolders[ballOnTube - 1].ballCtrl;

        if (ballOnTube == 4)
        {
            positions = Vector3.zero;
            ball = tubeHolders[ballOnTube - 1].ballCtrl;
        }
        else positions = tubeHolders[ballOnTube].position;
        //Debug.Log("On Mouse down " + tubeHolders[ballOnTube - 1].ballCtrl.idBall.ToString());
        TubeManager.Instance.GetTubeSelect(this, ball,positions);
        //LoadBallInTube();
    }
}
