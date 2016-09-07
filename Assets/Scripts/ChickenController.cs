using UnityEngine;
using System.Collections;

public class ChickenController : MonoBehaviour {

	void OnEnable(){
		Invoke ("Destroy", 1.5f);
	}
	
	void Destroy(){
		gameObject.SetActive (false);
	}
	
	void OnDisable(){
		CancelInvoke ();
	}

	void Update(){
		if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				gameObject.SetActive (false);
				GameObject obj = (GameObject) Instantiate(Resources.Load ("chicken_3"), hit.transform.position, hit.transform.rotation);
				obj.AddComponent<Rigidbody2D>();
				if(obj.transform.position.y < -5)
					Destroy(obj);
			}
		}
	}
}
