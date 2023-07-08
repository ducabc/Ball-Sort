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
    public Transform tube1;
    public Transform tube2;
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


    public void GetTubeSelect(Transform tube, BallCtrl ball , Vector3 position)
    {
        if (tube1 == null)
        {
            tube1 = tube;
            this.ballNeed = ball;
        }
            
        else
        {
            if (tube2 == null)
            {
                tube2 = tube;
                BallManager.Instance.TranBall(this.ballNeed, this.tube1, this.tube2, position);
            } 
            else tube1 = tube2 = null;
        }
    }
}
