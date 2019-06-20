using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counsillor : MonoBehaviour {

	private Rigidbody2D rb;
	private Rigidbody2D player;

	public GameObject bullet;
	private GameObject[] bullets = new GameObject[12];

	public Vector3 heading;
	public float distance;

	private float rate = 0.7f;
	public float cooldown;

	public float bigrate = 2f;
	public float bigcooldown;

	private int shotnum = 0;

	private Animator anim;

	void Start () {
		player = GameObject.FindWithTag("Sawblade").GetComponent<Rigidbody2D>();
		rb = GetComponent<Rigidbody2D>();
		for(int i = 0; i < 12; i++)
			bullets[i] = bullet;
		cooldown = 0;

		anim = GetComponent<Animator>();
	}
	
	void LateUpdate () {
		heading = player.position - rb.position;
		distance = heading.magnitude;

		if(distance <= 10f)
			rb.velocity = (heading / distance) * -2f;
		else
			rb.velocity = new Vector3(0, 0, 0);

		anim.SetFloat("Speed", rb.velocity.magnitude);

		bigcooldown -= Time.deltaTime;
		if(shotnum == 3)
		{	
			bigcooldown = bigrate;
			shotnum = 0;
		}
		if(bigcooldown <= 0)
		{
			if(cooldown >= 0)
			cooldown -= Time.deltaTime;
			if(distance <= 17f && cooldown <= 0)
			{	
				shotnum++;
				for(int i = 0; i < 12; i++)
				{
					cooldown = rate;
					bullets[i].transform.position = transform.position;
					bullets[i].GetComponent<Bullet>().dir = RotateVector(heading / distance * 7f, 30f * (i - 1));
					Instantiate(bullets[i]);
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
