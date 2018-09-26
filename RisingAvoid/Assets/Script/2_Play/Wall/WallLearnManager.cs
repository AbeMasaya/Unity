using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLearnManager : MonoBehaviour {

    public int[] LearnNum = new int[]{1,2,3,4};
    public float LearnSpeed = 3f;
    public int Level = 1;

	// Use this for initialization
	void Start () {
        //ゲーム開始時の壁作成
        foreach(int FieldNum in LearnNum){
            GameObject WallField = new GameObject("WallField" + FieldNum);
            WallField.GetComponent<Transform>().position = new Vector3(0, 0, 2700 + (FieldNum - 1) * 900);
            WallField.transform.parent = transform;
            WallField.AddComponent<WallFieldManager>();

        }
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("WallField1").transform.position.z <= -105) {
            Destroy(GameObject.Find("WallField1"));
            GameObject WallField = new GameObject("WallField1");
            WallField.GetComponent<Transform>().position = new Vector3(0,0, transform.Find("WallField4").position.z + 900);
            WallField.transform.parent = transform;
            WallField.AddComponent<WallFieldManager>();
        }
        if (GameObject.Find("WallField2").transform.position.z <= -105) {
            Destroy(GameObject.Find("WallField2"));
            GameObject WallField = new GameObject("WallField2");
            WallField.GetComponent<Transform>().position = new Vector3(0, 0, transform.Find("WallField1").position.z + 900);
            WallField.transform.parent = transform;
            WallField.AddComponent<WallFieldManager>();
        }
        if (GameObject.Find("WallField3").transform.position.z <= -105) {
            Destroy(GameObject.Find("WallField3"));
            GameObject WallField = new GameObject("WallField3");
            WallField.GetComponent<Transform>().position = new Vector3(0, 0, transform.Find("WallField2").position.z + 900);
            WallField.transform.parent = transform;
            WallField.AddComponent<WallFieldManager>();
        }
        if (GameObject.Find("WallField4").transform.position.z <= -105) {
            Destroy(GameObject.Find("WallField4"));
            GameObject WallField = new GameObject("WallField4");
            WallField.GetComponent<Transform>().position = new Vector3(0, 0, transform.Find("WallField3").position.z + 900);
            WallField.transform.parent = transform;
            WallField.AddComponent<WallFieldManager>();
        }
    }

    void FixedUpdate() {
        if (GameObject.Find("WallField1") != null) {
            GameObject.Find("WallField1").GetComponent<Transform>().Translate(0, 0, -LearnSpeed);
        }
        if (GameObject.Find("WallField2") != null) {
            GameObject.Find("WallField2").GetComponent<Transform>().Translate(0, 0, -LearnSpeed);
        }
        if (GameObject.Find("WallField3") != null) {
            GameObject.Find("WallField3").GetComponent<Transform>().Translate(0, 0, -LearnSpeed);
        }
        if (GameObject.Find("WallField4") != null) {
            GameObject.Find("WallField4").GetComponent<Transform>().Translate(0, 0, -LearnSpeed);
        }
    }

    public void LevelCahnge(int afterLevel){
        if(Level < afterLevel){
            LearnSpeed += 0.1f;
        }
    }
}
