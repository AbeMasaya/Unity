using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour {

    //機体、カメラ位置のワールド座標
    public Vector3 playerPosition;
    //機体のみのローカル座標
    public GameObject playerBody;

    //パラメータ
        //プレイ中固定上下左右移動速度
        public float moveSpeed;
        //獲得点
        public int Point = 10;
        //ボタンプッシュ時上下左右移動速度
        public float moveSpeedWork;
        //機体回転、傾き速度
        public float rollSpeed;
        //機体回転、傾き速度
        public float rollSpeedWork;
        //移動距離管理変数
        public float distance;
        public float addDistance;
        //移動範囲制限
        public float moveAreaRimit;
    //ワープ壁通過判定
    public bool throughGate1;
    public bool throughGate2;
    public bool throughGate3;
    public bool throughGate4;
    public bool throughGate5;

    //アニメーション
    public Animator playerAnim;

    //キープッシュフラグ
    public bool pushUpKey;
    public bool pushDownKey;
    public bool pushRightKey;
    public bool pushLeftKey;
    //移動中他の方向のボタンプッシュ防止用フラグ
    public bool pushButton;

    // Use this for initialization
    void Start () {
        playerPosition = GetComponent<Transform>().position;
        playerBody = GameObject.Find("PlayerBody");
        moveSpeed = 5f;
        moveSpeedWork = 0f;
        distance = 70f;//GameObject.Find("WallField").GetCompornent<wall>().(壁感覚距離の変数);
        moveAreaRimit = 140f;//GameObject.Find("WallField").GetCompornent<wall>().(壁フィールドの境界線の変数);
        rollSpeed = 360/(distance / moveSpeed);
        rollSpeedWork = 0f;
        pushUpKey = false;
        pushDownKey = false;
        pushRightKey = false;
        pushLeftKey = false;
        pushButton = false;
        addDistance = 0f;
        playerAnim = playerBody.GetComponent<Animator>();
        throughGate1 = false;
        throughGate2 = false;
        throughGate3 = false;
        throughGate4 = false;
        throughGate5 = false;
    }

    // Update is called once per frame
    void Update() {
        //ボタンプッシュ判定
            //左に移動ボタンフラグを立てる
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
                if (!pushLeftKey) {
                    if (!pushButton) {
                        pushLeftKey = true;
                        pushButton = true;
                        if (playerPosition.x >= -(moveAreaRimit - 0.1f)) {
                            playerAnim.SetBool("moveLeft", true);
                        }
                    }
                }
            }
            //右に移動ボタンフラグを立てる
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
                if (!pushRightKey) {
                    if (!pushButton) {
                        pushRightKey = true;
                        pushButton = true;
                        if (playerPosition.x <= moveAreaRimit - 0.1f) {
                            playerAnim.SetBool("moveRight", true);
                        }
                    }
                }
            }
            //上に移動ボタンフラグを立てる
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
                if (!pushUpKey) {
                    if (!pushButton) {
                        pushUpKey = true;
                        pushButton = true;
                        if (playerPosition.y <= moveAreaRimit - 0.1f) {
                            playerAnim.SetBool("moveUp", true);
                        }
                    }
                }
            }
            //下に移動ボタンフラグを立てる
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
                if (!pushDownKey) {
                    if (!pushButton) {
                        pushDownKey = true;
                        pushButton = true;
                        if (playerPosition.y >= -(moveAreaRimit - 0.1f)) {
                            playerAnim.SetBool("moveDown", true);
                        }
                    }
                }
            }

        //左に移動
        if (pushLeftKey) {
            if (playerPosition.x >= -(moveAreaRimit - 0.1f)) {
                moveSpeedWork = moveSpeed;
                playerPosition.x -= moveSpeedWork;
                transform.Translate(-moveSpeedWork, 0, 0);
                rollSpeed = 360 / (distance / moveSpeed);
                playerBody.transform.Rotate(0, 0, rollSpeed);
                addDistance += moveSpeed;
                if (addDistance >= distance) {
                    //移動完了後、プッシュフラグを戻す
                    pushLeftKey = false;
                    pushButton = false;
                    moveSpeedWork = 0f;
                    addDistance = 0f;
                    playerAnim.SetBool("moveLeft", false);
                }
            } else {
                pushLeftKey = false;
                pushButton = false;
                moveSpeedWork = 0f;
                addDistance = 0f;
            }
        }
        //右に移動
        if (pushRightKey) {
            if (playerPosition.x <= moveAreaRimit - 0.1f) {
                moveSpeedWork = moveSpeed;
                playerPosition.x += moveSpeedWork;
                transform.Translate(moveSpeedWork, 0, 0);
                rollSpeed = 360 / (distance / moveSpeed);
                playerBody.transform.Rotate(0, 0, -rollSpeed);
                addDistance += moveSpeed;
                if (addDistance >= distance) {
                    //移動完了後、プッシュフラグを戻す
                    pushRightKey = false;
                    pushButton = false;
                    moveSpeedWork = 0f;
                    addDistance = 0f;
                    playerAnim.SetBool("moveRight", false);
                }
            } else {
                pushRightKey = false;
                pushButton = false;
                moveSpeedWork = 0f;
                addDistance = 0f;
            }
        }
        //上に移動
        if (pushUpKey) {
            if (playerPosition.y <= moveAreaRimit - 0.1f) {
                moveSpeedWork = moveSpeed;
                playerPosition.y += moveSpeedWork;
                transform.Translate(0, moveSpeedWork, 0);
                addDistance += moveSpeed;
                if (addDistance >= distance) {
                    //移動完了後、プッシュフラグを戻す
                    pushUpKey = false;
                    pushButton = false;
                    moveSpeedWork = 0f;
                    addDistance = 0f;
                    playerAnim.SetBool("moveUp", false);
                }
            } else {
                pushUpKey = false;
                pushButton = false;
                moveSpeedWork = 0f;
                addDistance = 0f;
            }
        }
        //下に移動
        if (pushDownKey) {
            if (playerPosition.y >= -(moveAreaRimit - 0.1f)) {
                moveSpeedWork = moveSpeed;
                playerPosition.y -= moveSpeedWork;
                transform.Translate(0, -moveSpeedWork, 0);
                addDistance += moveSpeed;
                if (addDistance >= distance) {
                    //移動完了後、プッシュフラグを戻す
                    pushDownKey = false;
                    pushButton = false;
                    moveSpeedWork = 0f;
                    addDistance = 0f;
                    playerAnim.SetBool("moveDown", false);
                }
            } else {
                pushDownKey = false;
                pushButton = false;
                moveSpeedWork = 0f;
                addDistance = 0f;
            }
        }
    }

    void OnTriggerEnter(Collision other) {
        //0.壁通過
        if(other.gameObject.tag == "NoWall"){
            GameObject.Find("PlayManager").GetComponent<PlayParamManager>().Score = Point;
        }
        //1.通常壁
        if (other.gameObject.tag == "NomalWall") {
            GameObject.Find("PlayManager").GetComponent<PlayParamManager>().PlayerHP -= 10;
        }
        //2.強固壁
        if (other.gameObject.tag == "HardWall") {
            GameObject.Find("PlayManager").GetComponent<PlayParamManager>().PlayerHP -= 20;
        }
        //3.トビラ壁
        if (other.gameObject.tag == "GateWall") {
            GameObject.Find("PlayManager").GetComponent<PlayParamManager>().PlayerHP -= 10;//通常壁と同じダメージ
        }
        //4.得点壁
        if (other.gameObject.tag == "ScoreWall") {
            //GameObject.Find("PlayManager").GetCompornent<PlayParamManager>().(変数);
        }
        //5.ワープ壁
            //第一ゲート
            if (other.gameObject.tag == "Warp1Wall") {
                throughGate1 = true;
            } else {
                GateFlagRemit();
            }
            //第二ゲート
            if (other.gameObject.tag == "Warp2Wall" && throughGate1) {
                throughGate2 = true;
            } else {
                GateFlagRemit();
            }
            //第三ゲート
            if (other.gameObject.tag == "Warp3Wall" && throughGate1 && throughGate2) {
                throughGate3 = true;
            } else {
                GateFlagRemit();
            }
            //第四ゲート
            if (other.gameObject.tag == "Warp4Wall" && throughGate1 && throughGate2 && throughGate3) {
                throughGate4 = true;
            } else {
                GateFlagRemit();
            }
            //第五ゲート
            if (other.gameObject.tag == "Warp5Wall" && throughGate1 && throughGate2 && throughGate3 && throughGate4) {
                throughGate5 = true;
            } else {
                GateFlagRemit();
            }
            if (throughGate1 && throughGate2 && throughGate3 && throughGate4 && throughGate5) {
                //ワープ処理
            }
        //6.回復壁
        if (other.gameObject.tag == "HeelWall") {
            GameObject.Find("PlayManager").GetComponent<PlayParamManager>().PlayerHP += 10;
        }
    }

    void GateFlagRemit() {
        throughGate1 = false;
        throughGate2 = false;
        throughGate3 = false;
        throughGate4 = false;
        throughGate5 = false;
    }
}
