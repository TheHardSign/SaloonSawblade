using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperR : MonoBehaviour {

	private Rigidbody2D rb;
	private Rigidbody2D player;

	public GameObject bullet;

	public Vector3 heading;
	private Vector3 direction;
	public float distance;

	private float rate = 0.1f;
	public float cooldown;

	private float bigrate = 6f;
	public float bigcooldown;

	public int bigshotnum = 0;
	private int shotnum = 0;
	private int cyclenum = 0;

	private Animator anim;

	void Start () {
		player = GameObject.FindWithTag("Sawblade").GetComponent<Rigidbody2D>();
		rb = GetComponent<Rigidbody2D>();
		cooldown = 0;

		anim = GetComponent<Animator>();
	}
	
	void Update () {
		heading = player.position - rb.position;
		distance = heading.magnitude;

		if(distance <= 7f)
			rb.velocity = (heading / distance) * -2f;
		else
			rb.velocity = new Vector3(0, 0, 0);

		anim.SetFloat("Speed", rb.velocity.magnitude);

		bigcooldown -= Time.deltaTime;

		if(bigshotnum % 45 == 0)
		{
			bigcooldown = bigrate;
			bigshotnum++;
		}

		if(bigcooldown <= 0)
		{
			direction = RotateVector(heading / distance * 5f, 60f);
			if(cooldown >= 0)
				cooldown -= Time.deltaTime;
			if(distance <= 40f && cooldown <= 0)
			{	
				if(shotnum % 12 == 0)
					cyclenum++;

				if(cyclenum % 2 != 0)
					shotnum--;
				else
					shotnum++;

				cooldown = rate;
				bullet.transform.position = transform.position;

				if(shotnum % 12 != 0)
				{	
					bullet.GetComponent<Bullet>().dir = RotateVector(direction, 10 * (shotnum % 12));
					Instantiate(bullet);
					bigshotnum++;
				}
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
