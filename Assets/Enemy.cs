using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour {
	public GameObject deathEffect;
	public float health = 1f;
	public static int EnemiesAlive=0;

	void Start()
	{
		EnemiesAlive++;
	}
	void OnCollisionEnter2D(Collision2D colInfo)
	{
		if(colInfo.relativeVelocity.magnitude > health)
		{
			Die();
		}
	}
	void Die()
	{
		Instantiate (deathEffect, transform.position, Quaternion.identity);
		EnemiesAlive--;
		Destroy (gameObject);
	}
}
