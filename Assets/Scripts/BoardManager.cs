using UnityEngine;
using System;
using System.Collections.Generic;       
using Random = UnityEngine.Random;      

	
public class BoardManager : MonoBehaviour {
		
	public int width = 10;

	public int height = 8;

	public int enemyCount = 4;

	public GameObject grass;

	public GameObject enemy;

	public void Start()
	{

	}

	public void SetupScene(int level)
	{
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {

				Instantiate(grass, new Vector3((-width/4.0f + i - 1) * 4, (-height/4.0f + j -1) * 4, 0), Quaternion.identity);

			}
		}

		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		for (int i = 0; i < enemyCount; i++) {
			Vector3 pos = Vector3.zero;

			while (pos.magnitude < 5) {
				pos = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));
			}

			GameObject newEnemy = (GameObject)Instantiate(enemy, pos, Quaternion.identity);
			newEnemy.GetComponent<Track>().target = player;
		}
	}
}