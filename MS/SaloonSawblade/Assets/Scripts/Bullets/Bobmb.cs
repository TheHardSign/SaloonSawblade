using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobmb : MonoBehaviour {

	public GameObject spark;

	public GameObject bullet;
	private GameObject[] bullets = new GameObject[6];

	private float countdown = 2f;

	void Start() {
		for(int i = 0; i < 6; i++)
			bullets[i] = bullet;
	}
	
	void FixedUpdate() {
		if(this.gameObject.GetComponent<SpriteRenderer>().color == Color.white)
			this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		else
			this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		if(countdown <= 0)
			Destroying();
		countdown -= Time.deltaTime;
	}

	void Destroying() {
		for(int i = 0; i < 6; i++)
		{
			bullets[i].transform.position = transform.position;
			bullets[i].GetComponent<Bullet>().dir = RotateVector(Vector3.one * 7f, 60f * (i - 1));
			Instantiate(bullets[i]);
		}
		spark.transform.position = transform.position;
		Instantiate(spark);
		Destroy(gameObject);
	}

	public Vector2 RotateVector(Vector2 v, float angle)
	{
    	float radian = angle*Mathf.Deg2Rad;
    	float _x = v.x*Mathf.Cos(radian) - v.y*Mathf.Sin(radian);
    	float _y = v.x*Mathf.Sin(radian) + v.y*Mathf.Cos(radian);
    	return new Vector2(_x,_y);
	} 
}
