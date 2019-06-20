using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminator : MonoBehaviour {

	

	private Rigidbody2D rb;
	private Rigidbody2D player;

	public GameObject bullet;

	public Vector3 heading;
	public float distance;

	private float rate = 0.01f;
	public float cooldown;

	public float bigrate = 2f;
	public float bigcooldown;

	private int shotnum = 0;

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

		bigcooldown -= Time.deltaTime;
		if(shotnum == 10)
		{	
			bigcooldown = bigrate;
			shotnum = 0;
		}
		if(bigcooldown <= 0)
		{
			if(cooldown >= 0)
				cooldown -= Time.deltaTime;
			if(distance <= 20f && cooldown <= 0)
			{	
				shotnum++;
				cooldown = rate;
				bullet.transform.position = transform.position;
				bullet.GetComponent<Bullet>().dir = RotateVector(heading / distance * 10f, Random.Range(-5f, 5f));
				Instantiate(bullet);
			}
		}
	}

	public Vector2 RotateVector(Vector2 v, float angle)
	{
    	float radian = angle*Mathf.Deg2Rad;
    	float _x = v.x*Mathf.Cos(radian) - v.y*Mathf.Sin(radian);
    	float _y = v.x*Mathf.Sin(radian) + v.y*Mathf.Cos(radian);
    	return new Vector2(_x,_y);
	} 
}
