using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour {

	public GameObject bullet;

	private Rigidbody2D rb;

	public Vector3 heading;
	public float distance;

	private float rate = 2f;
	public float cooldown;

	private float moverate = 1f;
	public float movecooldown;

	public float bigrate = 4f;
	public float bigcooldown;

	private int shotnum = 0;
	private int maxshotnum = 5;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
		cooldown = 0;
		movecooldown = 0;
	}
	
	void Update () {
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
			if(cooldown <= 0)
			{	
				shotnum++;
				cooldown = rate;
				bullet.transform.position = transform.position;
				Instantiate(bullet);
				bullet.GetComponent<Rigidbody2D>().AddForce(rb.velocity * -5f);
			}
		}
		if(movecooldown >= 0)
			movecooldown -= Time.deltaTime;
		if(movecooldown <= 0)
		{	
			rb.velocity = new Vector2(Random.Range(-7f, 7f), Random.Range(-7f, 7f));
			movecooldown = moverate;
		}
	}
}
