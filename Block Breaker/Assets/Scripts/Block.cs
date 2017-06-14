using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () 
	{
		timesHit = 0;
		isBreakable = (this.tag == "Breakable");
		
		if (isBreakable)
		{
			breakableCount++;
			print (breakableCount);
		}
		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		//AudioSource.PlayClipAtPoint(crack, transform.position);
		if (isBreakable)
		{
			HandleHits();
		} 
		//levelManager.LoadNextLevel();
	}
	
	void HandleHits()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits)
		{
			breakableCount--;
			print (breakableCount);
			Destroy(gameObject);
			levelManager.BrickDestroyed();
		}
		else
			LoadSprites();
	}
	
	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex])
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}	
}
