using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager: MonoBehaviour {

    //ボタン押下判定
    public bool boolGameStart;
    public bool boolShop;
    public bool boolRanking;
    public bool boolOption;

    //ブラックフェードアウト用ステータス
    GameObject BrackOut;
    Image BrackOutImage;
    private float BrackOutSpeed;
    private float BrackOutAlpha;

    //カメラ設定
    GameObject MainCamera;
    private float CameraRoll;

    // Use this for initialization
    void Start()
    {
        boolGameStart = false;
        boolShop = false;
        boolRanking = false;
        boolOption = false;
        BrackOut = GameObject.Find("BlackOutImage");
        BrackOutImage = BrackOut.GetComponent<Image>();
        BrackOutAlpha = 0f;
        BrackOutSpeed = 0.02f;
        MainCamera = GameObject.Find("Main Camera");
        CameraRoll = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        //CameraRoll += CameraRollSpeed;
        MainCamera.GetComponent<Transform>().Rotate(new Vector3(0,CameraRoll,0));

        if (boolGameStart || boolShop || boolRanking || boolOption)
        {
            BrackOutAlpha += BrackOutSpeed;
            BrackOutImage.color = new Color(0, 0, 0, BrackOutAlpha);
        }

        if (BrackOutAlpha >= 1f)
        {
            if (boolGameStart)
            {
                SceneManager.LoadScene("2_PlayScene");
            }
            else if (boolShop)
            {
                SceneManager.LoadScene("3_ShopScene");
            }
            else if (boolRanking)
            {
                SceneManager.LoadScene("4_RankingScene");
            }
            else if (boolOption)
            {
                SceneManager.LoadScene("5_OptionScene");
            }
        }
    }

    //ボタン押下時メソッド
    public void PushGameStart()
    {
        boolGameStart = true;
        BrackOutImage.enabled = true;
    }
    public void PushShop()
    {
        boolShop = true;
        BrackOutImage.enabled = true;
    }
    public void PushRanking()
    {
        boolRanking = true;
        BrackOutImage.enabled = true;
    }
    public void PushOption()
    {
        boolOption = true;
        BrackOutImage.enabled = true;
    }


}
