using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToMe : MonoBehaviour
{
	private Transform trans;
	public Transform player;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        if(trans.position.x > player.position.x)
        	trans.localScale = new Vector3(3, 3, 0);
        else
        	trans.localScale = new Vector3(-3, 3, 0);
    }
}
