using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script;

public class TubeManager : MonoBehaviour
{
    public List<Vector3> positions;
    public List<Tube> listTube;
    public int tubePerfect = 0;

    private Transform Prefab;
    private SpamCS SpamCS;
    public Tube tube1;
    public Tube tube2;
    private BallCtrl ballNeed;
    private static string TUBE = "Tube";

    private static TubeManager instance;

    public static TubeManager Instance => instance;
    private void Awake()
    {
        if (TubeManager.instance != null) Debug.LogError("only 1 tube manager");
        TubeManager.instance = this;
    }
    private void Start()
    {
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
        LoadTube();
    }

    protected void LoadTube()
    {
        listTube.AddRange(gameObject.GetComponentsInChildren<Tube>());
    }
    public void GetTubeSelect(Tube tube)
    {
        if (tube1 == null)
        {
            tube1 = tube;
            this.ballNeed = tube1.GetBallOnTop();
            if (ballNeed == null) tube1 = null;
            else ballNeed.SelectBall(true);
        }
        else
        {
            if (tube2 == null)
            {
                tube2 = tube;
                Vector3 position;
                position = tube2.GetPositionOnTop();
                if (position == Vector3.zero)
                {
                    tube2 = null;
                    return;
                }
                if (tube2 != tube1)
                {
                    if (tube2.GetBallOnTop() == null || tube2.GetBallOnTop().idBall == ballNeed.idBall)
                    {
                        BallManager.Instance.TranBall(this.ballNeed, this.tube1, this.tube2, position);
                        tube1.RefreshBallPotions();
                        tube2.RefreshBallPotions();
                        if (CheckWin())
                        {
                            GameCtrl.Instance.WinGameUi();
                            AudioManager.Instance.PlaySound("Win");
                        }
                        tube1 = tube2 = null;
                        ballNeed.SelectBall(false);
                    }
                    else
                    {
                        tube2 = tube1 = null; ballNeed.SelectBall(false);
                    }
                }
            }
        }
    }

    protected bool CheckWin()
    {
        tubePerfect = 0;
        foreach (Tube tube in listTube)
        {
            if (tube.CheckWin()) tubePerfect++;
        }
        bool win = false;
        if(tubePerfect == GameCtrl.Instance.tubeCount - GameCtrl.Instance.doKho) win = true;
        return win;
    }

    public void CreateTubeHelp()
    {
        int n = GameCtrl.Instance.tubeCount;
        if (n < 8)
        {
            SpamCS.Instance.Spam(TUBE, transform, positions[n]);
            LoadTube();
        }
        else Debug.Log("Can help you with max of difficle level");
    }
}
