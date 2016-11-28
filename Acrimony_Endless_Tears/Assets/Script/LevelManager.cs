
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager: MonoBehaviour
{
	public float TimeLimitToLoad;

	// Run once when the game starts
	private void Start ()
	{
		KeepTrackOfScenes ();
	}

	//Keep the track of the current scene and its objects
	private void KeepTrackOfScenes ()
	{
		// Check if the timer between level is active 
		if (TimeLimitToLoad == 0)
		{
            print("Auto load is disabled");
		}

		//Check if the current scene is the main menu of the game.
		int currentScene = SceneManager.GetActiveScene ().buildIndex;
		int mainMenuIndex = 1;
		if (currentScene < mainMenuIndex)
		{
			Invoke ("LoadNextLevel", TimeLimitToLoad);
		} else if (currentScene >= mainMenuIndex)
		{
			CancelInvoke ("LoadNextLevel");
		}
	}

	//Load level
	public void LoadLevel (string name)
	{
		SceneManager.LoadScene (name);
	}

	//Check if the player request to exit the game
	public void QuitRequest ()
	{
		Application.Quit ();
	}

	//Load next level while run time
	public void LoadNextLevel ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
