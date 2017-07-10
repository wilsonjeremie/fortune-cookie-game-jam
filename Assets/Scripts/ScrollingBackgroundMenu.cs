using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundMenu : MonoBehaviour {


	void Start()
	{
		
	}

	void Update()
	{
		transform.position += (Vector3.left * 75f * 0.1f * Time.deltaTime);
		if (transform.position.x < -480)
			transform.position += Vector3.right * 480f;
	}
}