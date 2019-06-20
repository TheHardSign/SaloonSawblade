using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunslingerScript : MonoBehaviour {

	private Rigidbody2D rb;
	private Rigidbody2D player;

	public GameObject bullet;
	public Transform weapon;

	public Vector3 heading;
	public float distance;

	private float rate = 0.5f;
	public float cooldown;

	public float bigrate = 2f;
	public float bigcooldown;

	private int shotnum = 0;
	private int maxshotnum = 5;

	private Animator anim;

	void Start () {
		player = GameObject.FindWithTag("Sawblade").GetComponent<Rigidbody2D>();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		cooldown = 0;
	}
	
	Vector3 oldhead = new Vector3(0, 0, 0);

	void LateUpdate () {
		weapon.localScale = new Vector3(-transform.localScale.x / Mathf.Abs(transform.localScale.x), transform.localScale.x / Mathf.Abs(transform.localScale.x), 0);

		Vector2 weppos = new Vector2(weapon.position.x, weapon.position.y);
		heading = player.position - weppos;
		distance = heading.magnitude;

		weapon.rotation = Quaternion.Euler(0, 0, 90 - Vector3.Angle(heading / distance, Vector3.down) * (transform.localScale.x / Mathf.Abs(transform.localScale.x)));

		if(distance <= 10f)
			rb.velocity = (heading / distance) * -2f;
		else
			rb.velocity = new Vector3(0, 0, 0);

		anim.SetFloat("Speed", rb.velocity.magnitude);

		bigcooldown -= Time.deltaTime;
		if(shotnum == maxshotnum)
		{	
			maxshotnum = Random.Range(3, 6);
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
				cooldown = rate;
				bullet.transform.position = weapon.transform.position;
				bullet.GetComponent<Bullet>().dir = heading / distance * 10f;
				Instantiate(bullet);
			}
		}

		oldhead = heading;
	}
}
