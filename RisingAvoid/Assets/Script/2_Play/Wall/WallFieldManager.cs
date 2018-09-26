using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WallFieldManager : MonoBehaviour {

    //フィールドの枠
    public GameObject FieldFrame;

    //壁各種

    //0.壁なし　配列番号：00
    public GameObject NoWall;

    //1.通常壁　配列番号：10
    public GameObject NomalWall;
    //通常壁配置位置配列
    public int[] NomalWallSetPoint = new int[5];

    //2.強固壁　配列番号：20
    public GameObject HardWall;
    //強固壁配置位置配列
    public int[] HardWallSetPoint;

    //3-1.トビラ壁(時間差解放)　配列番号：31
    public GameObject GateAfterOpenWall;
    //トビラ壁(時間差解放)配置位置
    public int[] GateAfterOpenWallSetPoint;

    //3-2.トビラ壁(時間差閉鎖) 配置番号：32
    public GameObject GateAfterCloseWall;
    //トビラ壁(時間差閉鎖)配置位置
    public int[] GateAfterCloseWallSetPoint;

    //4-1.得点2倍壁　配列番号：41
    public GameObject Score2timesWall;
    //得点2倍壁配置位置
    public int[] Score2timesWallSetPoint;

    //4-2.得点4倍壁　配列番号：42
    public GameObject Score4timesWall;
    //得点4倍壁配置位置
    public int[] Score4timesWallSetPoint;

    //4-3.得点8倍壁　配列番号：43
    public GameObject Score8timesWall;
    //得点4倍壁配置位置
    public int[] Score8timesWallSetPoint;

    //4-4.得点16倍壁　配列番号：44
    public GameObject Score16timesWall;
    //得点16倍壁配置位置
    public int[] Score16timesWallSetPoint;

    //4-5.得点32倍壁　配列番号：45
    public GameObject Score32timesWall;
    //得点32倍壁配置位置
    public int[] Score32timesWallSetPoint;

    //5-1.第1ワープ壁　配列番号：51
    public GameObject WarpGate1;
    //第1ワープ壁配置位置
    public int[] WarpGate1SetPoint = new int[1];

    //5-2.第2ワープ壁　配列番号：52
    public GameObject WarpGate2;
    //第2ワープ壁配置位置
    public int[] WarpGate2SetPoint = new int[1];

    //5-3.第3ワープ壁　配列番号：53
    public GameObject WarpGate3;
    //第3ワープ壁配置位置
    public int[] WarpGate3SetPoint = new int[1];

    //5-4.第4ワープ壁　配列番号：54
    public GameObject WarpGate4;
    //第4ワープ壁配置位置
    public int[] WarpGate4SetPoint = new int[1];

    //5-5.第5ワープ壁 配列番号：55
    public GameObject WarpGate5;
    //第5ワープ壁配置位置
    public int[] WarpGate5SetPoint = new int[1];

    //6.回復壁 配列番：60
    public GameObject HeelWall;
    //回復壁配置位置
    public int[] HeelWallSetPoint;

    //壁配置配列
    private string[,] WallFieldArray = new string[5, 5];

    // Use this for initialization
    void Start() {

        //試験用　START
        var WallAssets = AssetDatabase.FindAssets("t:prefab", new string[] {"Assets/Plefab/WallAssets/WallSets"});
        var path = AssetDatabase.GUIDToAssetPath(WallAssets[1]);
        var obj = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        NomalWall = obj;
        path = AssetDatabase.GUIDToAssetPath(WallAssets[0]);
        obj = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        FieldFrame = obj;

        //試験用　END
        MakeFieldArray(0);
    }

    // Update is called once per frame
    void Update() {

    }

    public void MakeFieldArray(int Level) {
        /*
        WallFieldArray = new string[,] {
            {"10","10","10","10","10"},
            {"10","10","10","10","10"},
            {"10","10","00","10","10"},
            {"10","10","10","10","10"},
            {"10","10","10","10","10"}
        };
        */
        CreateNomallWallPoint(GameObject.Find("PlayManager").GetComponent<PlayParamManager>().Level);
        SetWall(WallFieldArray);
    }

    void SetWall(string[,] WallArray) {
        int ArrayRow = 0;
        int ArrayCol = 0;

        GameObject Frame;

        Frame = Instantiate(FieldFrame, new Vector3(this.transform.position.x, this.transform.position.y + 200, this.transform.position.z), Quaternion.identity);
        Frame.transform.parent = transform;


        for (int Row = 2; Row > -3; Row--) {
            ArrayCol = 0;
            string RowObjectName = "WallRow" + (ArrayRow + 1);
            GameObject WallRow = new GameObject(RowObjectName);
            WallRow.transform.parent = transform;
            transform.Find(RowObjectName).localPosition = new Vector3(0, Row * 70, 0);

            for (int Col = -2; Col < 3; Col++) {
                string ColObjectName = "WallCol" + (ArrayCol + 1);
                GameObject WallCol = new GameObject(ColObjectName);
                WallCol.transform.parent = transform.Find(RowObjectName);
                transform.Find(RowObjectName).Find(ColObjectName).localPosition = new Vector3(Col * 70, 0, 0);
                Vector3 WallPosition = transform.Find(RowObjectName).Find(ColObjectName).position;
                GameObject Wall;
                
                switch (WallArray[ArrayRow, ArrayCol]) {
                    case "00":
                        //枠のみを設置考案中
                        break;
                    case "10":
                        Wall = Instantiate(NomalWall, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "20":
                        Wall = Instantiate(HardWall, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "31":
                        Wall = Instantiate(GateAfterOpenWall, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "32":
                        Wall = Instantiate(GateAfterCloseWall, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "41":
                        Wall = Instantiate(Score2timesWall, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "42":
                        Wall = Instantiate(Score4timesWall, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "43":
                        Wall = Instantiate(Score8timesWall, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "44":
                        Wall = Instantiate(Score16timesWall, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "45":
                        Wall = Instantiate(Score32timesWall, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "51":
                        Wall = Instantiate(WarpGate1, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "52":
                        Wall = Instantiate(WarpGate2, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "53":
                        Wall = Instantiate(WarpGate3, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "54":
                        Wall = Instantiate(WarpGate4, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "55":
                        Wall = Instantiate(WarpGate5, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                    case "60":
                        Wall = Instantiate(HeelWall, WallPosition, Quaternion.identity);
                        Wall.transform.parent = WallCol.transform;
                        break;
                }
                ArrayCol++;
            }
            ArrayRow++;
        }
    }

    void CreateNomallWallPoint(int Level){
        if (Level > 9) {
            if (Level > 99) {
                NomalWallSetPoint = new int[24];
            } else {
                NomalWallSetPoint = new int[5 + ((Level / 5) - 1)];
            }
        }
        int SetCount = 0;
        while (SetCount < NomalWallSetPoint.Length) {
            bool Set = true;
            int NomalWallPoint = Random.Range(1, 26);
            foreach (int checkValue in NomalWallSetPoint) {
                if (checkValue == NomalWallPoint) {
                    Set = false;
                }
            }
            if (Set) {
                NomalWallSetPoint[SetCount] = NomalWallPoint;
                SetCount++;
            }
        }
        foreach (int SetPoint in NomalWallSetPoint) {
            int Row = (SetPoint - 1) / 5;
            int Col = (SetPoint - 1) % 5;
            WallFieldArray[Row, Col] = "10";
        }
    }
}