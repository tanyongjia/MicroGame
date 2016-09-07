using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public float spawnTime = .5f;
	public Transform spawnLocation;

	void Start () {
		InvokeRepeating ("SpawnChicken", spawnTime, spawnTime);
	}

	void SpawnChicken(){
		Vector2 location = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(Screen.height / 2f, Screen.height)));
		spawnLocation.position = location;

		GameObject obj = NewObjectPooler.current.GetPooledObject ();
		if (obj == null)
			return;
		obj.transform.position = spawnLocation.position;
		obj.transform.rotation = spawnLocation.rotation;
		obj.SetActive(true);
	}
}
