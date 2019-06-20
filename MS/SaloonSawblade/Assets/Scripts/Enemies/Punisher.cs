using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punisher : MonoBehaviour {

	private Rigidbody2D rb;
	private Rigidbody2D player;

	public GameObject bullet;

	public Vector3 heading;
	public float distance;

	private float rate = 5f;
	public float cooldown;

	void Start () {
		player = GameObject.FindWithTag("Sawblade").GetComponent<Rigidbody2D>();
		rb = GetComponent<Rigidbody2D>();
		cooldown = 0;
	}
	
	void Update () {
		heading = player.position - rb.position;
		distance = heading.magnitude;

		if(distance <= 10f)
			rb.velocity = (heading / distance) * -2f;
		else
			rb.velocity = new Vector3(0, 0, 0);

		if(cooldown >= 0)
			cooldown -= Time.deltaTime;
		if(distance <= 17f && cooldown <= 0)
		{	
			cooldown = rate;
			bullet.transform.position = transform.position;
			bullet.GetComponent<Missiles>().dir = heading / distance * 10f;
			Instantiate(bullet);
		}
	}
}
