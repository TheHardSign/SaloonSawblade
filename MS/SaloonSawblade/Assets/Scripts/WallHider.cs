using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
			gameObject.SetActive(false);
	}

	void Start () {
		
	}
	
	void Update () {
		
	}
}
