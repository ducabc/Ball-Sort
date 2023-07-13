using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;

public class BallManager : MonoBehaviour
{

    public List<BallObj> listSprite = new();
    public Transform tubeManager;
    private int DoKho = 2;

    private SpamCS SpamCS;
    private static string ball = "Ball";
    private BallObj ballObj;
    public List<BallObj> ballObjs;
    public List<Sprite> ballSprites;
    private List<int> spriteId = new List<int> {-1,-1};

    private int ballTaora;
    private int ballConLai;
    private int ballMin;
    private int ballMax;
    private int tubeConLai;
    private static BallManager instance;
    public static BallManager Instance => instance;
    private void Awake()
    {
        if (instance != null) Debug.LogError("only 1 ball manager");
        BallManager.instance = this;
    }

    private void Start()
    {
        LoadBallObj();
        DoKho = GameCtrl.Instance.doKho;
        tubeConLai = GameCtrl.Instance.tubeCount - 1;
        ballConLai = (GameCtrl.Instance.tubeCount - DoKho) * 4;
        GetRandomSprite();
    }

    private void Reset()
    {
        tubeManager = GameObject.Find("TubeManager").transform;
    }
    public void SpamBall(Transform holder, List<TubeHolder> posSpam)
    {
        if (ballMin < 0) ballMin = 0;
        if (ballConLai >= 4) ballMax = 5;
        else
        {
            if (ballConLai == 0) ballMax = ballMin = 0;
            else ballMax = ballConLai + 1;
        }
        ballTaora = Random.Range(ballMin, ballMax);
        ballMin = 4 + (ballConLai - ballTaora - tubeConLai * 4);
        for (int i = 0; i < ballTaora; i++)
        {
            Transform newBall = SpamCS.Instance.Spam(ball, holder, posSpam[i].position);
            BallCtrl ballCtrl = newBall.GetComponent<BallCtrl>();
            ballCtrl.SelectBall(false);
            ballCtrl.SetModel(SetSprite());
            ballCtrl.LoadIdBall();
            posSpam[i].ballCtrl = ballCtrl;
            ballConLai--;
        }
        tubeConLai--;
    }

    public void TranBall(BallCtrl ball, Tube tube1,Tube tube2, Vector3 posSpam)
    {
        ChangeParent(ball, tube2);
        ball.transform.position = posSpam;
    }

    protected void ChangeParent(BallCtrl ball, Tube parent)
    {
        ball.transform.SetParent(parent.transform);
    }

    protected void LoadBallObj()
    {///////////////////////////////////////////////////////////////////////////////
        
        for(int i = 1; i < 6; i++)
        {
            listSprite.Add(Resources.Load<BallObj>($"BallStyle{i}"));
        }
        ballObj = listSprite[Random.Range(0, listSprite.Count )];
    }
    protected Sprite SetSprite()
    {
        int random = Random.Range(0, ballSprites.Count);
        Sprite sprite = ballSprites[random];
        ballSprites.RemoveAt(random);
        return sprite;
    }

    protected void GetRandomSprite()
    {
        int random =-1;
        for(int i = 0; i < ballConLai/4; i++)
        {
            while (CheckRandom(spriteId, random))
            {
                random = Random.Range(0, ballObj.balls.Count);
            }
            spriteId.Add(random);
            for (int j = 0; j < 4; j++)
            {
                ballSprites.Add(ballObj.balls[random]);
            }

        }
    }

    protected bool CheckRandom(List<int> list, int x)
    {
        bool check = true;
        for(int i = 0; i < list.Count; i++)
        {
            if(list[i] == x)
            {
                check = true;
                break;
            }
            else check= false;
        }
        return check;
    }
}
