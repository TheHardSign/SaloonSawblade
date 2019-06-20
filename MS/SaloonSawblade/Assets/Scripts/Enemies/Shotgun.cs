using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour {

	private Rigidbody2D rb;
	private Rigidbody2D player;

	public GameObject bullet;
	private GameObject[] bullets = new GameObject[5];

	public Vector3 heading;
	public float distance;

	private float rate = 1f;
	public float cooldown;

	public float bigrate = 2f;
	public float bigcooldown;

	private int shotnum = 0;
	private int maxshotnum = 5;

	void Start () {
		player = GameObject.FindWithTag("Sawblade").GetComponent<Rigidbody2D>();
		rb = GetComponent<Rigidbody2D>();
		for(int i = 0; i < 5; i++)
			bullets[i] = bullet;
		cooldown = 0;
	}
	
	void LateUpdate () {
		heading = player.position - rb.position;
		distance = heading.magnitude;

		if(distance <= 10f)
			rb.velocity = (heading / distance) * -2f;
		else
			rb.velocity = new Vector3(0, 0, 0);

		bigcooldown -= Time.deltaTime;
		if(shotnum == maxshotnum)
		{	
			maxshotnum = Random.Range(1, 4);
			bigcooldown = bigrate;
			shotnum = 0;
		}
		if(bigcooldown <= 0)
		{
			if(cooldown >= 0)
			cooldown -= Time.deltaTime;
			if(distance <= 10f && cooldown <= 0)
			{	
				shotnum++;
				for(int i = 0; i < 5; i++)
				{
					cooldown = rate;
					bullets[i].transform.position = transform.position;
					bullets[i].GetComponent<Shot>().dir = RotateVector(heading / distance * Random.Range(5, 10), Random.Range(-30, 30));
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

