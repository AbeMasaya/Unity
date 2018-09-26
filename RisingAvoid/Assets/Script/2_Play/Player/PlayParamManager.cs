using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayParamManager : MonoBehaviour {

    //現HP
    public int PlayerHP = 100;
    //獲得スコア
    public int Score = 0;
    //現レベル
    public int Level = 0;
    //現スピード
    public float speed = 200f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("LevelValue").GetComponent<Text>().text = Level.ToString();
	}
}
