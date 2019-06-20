using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Rigidbody2D Player;

	private Vector3 offset, smoothdetination;

	void Start () {
		offset = transform.position - Player.transform.position;
	}
	
	public bool smoothmove = false;

	void LateUpdate () {
		smoothdetination = new Vector3(transform.position.x, Player.transform.position.y + offset.y, transform.position.z); 

		if(transform.position != smoothdetination)
			transform.position += (smoothdetination - transform.position) / 10;
	}
}
