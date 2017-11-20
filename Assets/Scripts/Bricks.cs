using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour 
{
	public static int breakableCounter = 0;
	public Sprite [] hitSprites;
	public AudioClip crack;
	public GameObject smoke;
	
	private int counter;
	private int maxHits;
	private LevelManager levelManager;
	private bool isBreakable;
	
	
	// Use this for initialization
	void Start () 
	{
		isBreakable = (this.tag == "Breakable");
		if(isBreakable)
		{
			breakableCounter++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position,0.3f);
		if (isBreakable) 
		{
			HandleHits ();
			
		}
	}
	
	void HandleHits ()
	{
		counter ++;
		maxHits=hitSprites.Length + 1;
		if(counter >= maxHits)
		{
			breakableCounter--;
			GameObject smokePuff = Instantiate(smoke,transform.position, Quaternion.identity) as GameObject;
			smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		}
		else
		{
			LoadSprites ();
		}
	}
	void LoadSprites ()
	{
		int i = counter - 1;
		if(hitSprites[i])
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[i];
		}
	}
}