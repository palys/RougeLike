using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemiesCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		int enemiesCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		string text = "Enemies count = " + enemiesCount;
		GetComponent<Text> ().text = text;
	}
}
