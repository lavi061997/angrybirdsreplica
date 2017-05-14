using UnityEngine;
using System.Collections;


public class ball : MonoBehaviour {

	private bool isPressed = false;
	public float releaseTime = 0.15f;
	public Rigidbody2D rb;
	public Rigidbody2D hook;
	public GameObject nextBall;
	public float maxDragDistance = 15f;
	void Update()
	{
		if (isPressed) 
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if(Vector3.Distance(mousePos,hook.position) > maxDragDistance)
			{
				rb.position = hook.position + (mousePos  - hook.position).normalized *maxDragDistance;
			}
			else
			rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

	}


	void OnMouseDown()
	{
		isPressed = true;
		rb.isKinematic = true; 
	}

	void OnMouseUp()
	{ 
		isPressed = false;
		rb.isKinematic = false;
		StartCoroutine (Release ());
	}

	IEnumerator Release()
	{
		yield return new WaitForSeconds (releaseTime);
		GetComponent<SpringJoint2D>().enabled = false;
		this.enabled = false;
		yield return new WaitForSeconds(2f);
		if (nextBall != null) {
			nextBall.SetActive (true);
		}


	}

}
