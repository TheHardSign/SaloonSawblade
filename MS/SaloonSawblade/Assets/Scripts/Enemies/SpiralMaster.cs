using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMaster : MonoBehaviour {

	private Rigidbody2D rb;
	private Rigidbody2D player;

	public GameObject bullet; 
	private GameObject bullet2;

	public Transform weapon1;
	public Transform weapon2;

	public Vector3 heading;
	public float distance;

	private float rate = 0.5f;
	public float cooldown;

	private int shotnum = 0;

	private Animator anim;

	void Start () {
		player = GameObject.FindWithTag("Sawblade").GetComponent<Rigidbody2D>();
		rb = GetComponent<Rigidbody2D>();
		cooldown = 0;
		bullet2 = bullet;
		anim = GetComponent<Animator>();
	}
	
	void LateUpdate () {

		weapon1.localScale = new Vector3(-transform.localScale.x / Mathf.Abs(transform.localScale.x), transform.localScale.x / Mathf.Abs(transform.localScale.x), 0);
		weapon2.localScale = new Vector3(transform.localScale.x / Mathf.Abs(transform.localScale.x), transform.localScale.x / Mathf.Abs(transform.localScale.x), 0);
		
		heading = player.position - rb.position;
		distance = heading.magnitude;


		if(distance <= 10f)
			rb.velocity = (heading / distance) * -2f;
		else
			rb.velocity = new Vector3(0, 0, 0);

		anim.SetFloat("Speed", rb.velocity.magnitude);

		if(cooldown >= 0)
			cooldown -= Time.deltaTime;
		if(distance <= 20f && cooldown <= 0)
		{	
			shotnum++;
			cooldown = rate;
			bullet.transform.position = weapon1.position;
			bullet.GetComponent<Bullet>().dir = RotateVector(Vector3.one * 5f, 35f * (shotnum % 60));
			Instantiate(bullet);
			bullet2.transform.position = weapon2.position;
			bullet2.GetComponent<Bullet>().dir = -RotateVector(Vector3.one * 5f, 35f * (shotnum % 60));
			Instantiate(bullet2);

			weapon1.rotation = Quaternion.Euler(0, 0, 90 - Vector3.Angle(bullet.GetComponent<Bullet>().dir, Vector3.down) * (transform.localScale.x / Mathf.Abs(transform.localScale.x)));
			weapon2.rotation = Quaternion.Euler(0, 0, 90 - Vector3.Angle(bullet2.GetComponent<Bullet>().dir, Vector3.down) * (transform.localScale.x / Mathf.Abs(transform.localScale.x)));
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
