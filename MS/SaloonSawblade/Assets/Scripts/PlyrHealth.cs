using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlyrHealth : MonoBehaviour {

	public int maxHealth = 4;
	private int curHealth;

	public Text txt;
	public Slider slid;
	public Image damageImg;

	private float dmgCooldown;
	private float dmgColAlph = 0.3f;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.tag == "DamagingObj" && curHealth >= 0)
		{
			curHealth--;
			dmgColAlph = 0.3f;
			damageImg.color = new Color(1, 0, 0, 0.3f);
			dmgCooldown = 0.1f;
		}
	}

	void Start () {
		curHealth = maxHealth;
		slid.maxValue = maxHealth;
		dmgCooldown = 0;
	}
	
	void Update () {
		if(slid.value - Mathf.Abs(curHealth) > 0.1f)
			slid.value -= 0.1f;
		if(dmgCooldown <= 0)
			damageImg.color = new Color(0, 0, 0, 0);
		else
		{	
			dmgCooldown -= Time.deltaTime;
			dmgColAlph -= 0.03f;
			damageImg.color = new Color(1, 0, 0, dmgColAlph);
		}
		if(curHealth <= 0)
		{
			slid.value = 0;
			Destroy(gameObject);
		}
		txt.text = curHealth + " / " + maxHealth;
	} 
}
