using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	
	public void LoadLevel (string name)
	{
		Debug.Log("Level load requested for " + name);
		Bricks.breakableCounter=0;
		Application.LoadLevel(name);
	}
	
	public void QuitGame ()
	{
		Debug.Log("Bye!");
		Application.Quit();
	}
	
	public void LoadNextLevel ()
	{
		Bricks.breakableCounter=0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed ()
	{
		if(Bricks.breakableCounter <= 0)
		{
			LoadNextLevel();
		}
	}
}
