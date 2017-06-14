using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour 
{
	private LevelManager levelManager;
	int strike = 0;
	void Start()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	void OnTriggerEnter2D (Collider2D collision)
	{
		print ("trigger");
		strike++;
		//if (strike == 3)
			levelManager.LoadLevel("Lose");
		print ("Strike " + strike);
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		print ("Collision");
	}
}
