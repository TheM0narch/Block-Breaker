using UnityEngine;
using System.Collections;

public class BackgroundMusicPlayer : MonoBehaviour 
{

	static BackgroundMusicPlayer instance=null;
	
	void Awake ()
	{
		if(instance!=null)
		{
			Destroy(gameObject);
			print ("Dublicate player destructing");
		}
		else
		{
			instance=this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	 {
	
	}
}
