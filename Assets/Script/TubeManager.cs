using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script;

public class TubeManager : MonoBehaviour
{
    public List<Vector3> positions;
    public Transform Prefab;
    private SpamCS SpamCS;
    public Tube tube1;
    public Tube tube2;
    public BallCtrl ballNeed;
    public static string TUBE = "Tube";

    private static TubeManager instance;

    public static TubeManager Instance => instance;
    private void Awake()
    {
        if (TubeManager.instance != null) Debug.LogError("only 1 tube manager");
        TubeManager.instance = this;
        SpamTube();
    }
    protected void Reset()
    {
        Prefab = GameObject.Find("Prefabs").transform;
        SpamPosition();
    }
    protected void SpamPosition()
    {
        Vector3 posSpam = new Vector3(this.transform.position.x, transform.position.y);
        for (int i = 0; i < 8; i++)
        {
            posSpam.x += 1.2f;
            if (posSpam.x > 4f)
            {
                posSpam.x = 0.2f;
                posSpam.y = -2.6f;
            }
            positions.Add(posSpam);
        }
    }

    protected void SpamTube()
    {
        int n = GameCtrl.Instance.tubeCount;
        for (int i=0;i< n; i++)
        {
            SpamCS.Instance.Spam(TUBE, transform, positions[i]);
        }
    }


    public void GetTubeSelect(Tube tube, BallCtrl ball , Vector3 position)
    {
        if (tube1 == null)
        {
            if (ball != null)
            {
                tube1 = tube;
                this.ballNeed = ball;
            }
            else return;
        }
        else
        {
            if (tube2 == null && position != Vector3.zero)
            {
                tube2 = tube;
                if (tube2 != tube1)
                {
                    BallManager.Instance.TranBall(this.ballNeed, this.tube1, this.tube2, position);
                    tube1.RefreshBallPotions();
                    tube2.RefreshBallPotions();
                    tube1 = tube2 = null;
                }
            }
            else tube1 = tube2 = null;
        }
    }
}
