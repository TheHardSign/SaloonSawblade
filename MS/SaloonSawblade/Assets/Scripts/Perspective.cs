using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : MonoBehaviour
{
	private Transform trans;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        //trans.position = new Vector3(trans.position.x, trans.position.y, trans.position.z + trans.position.y);
    }
}
