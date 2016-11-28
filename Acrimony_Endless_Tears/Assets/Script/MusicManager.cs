using UnityEngine;

public class MusicManager: MonoBehaviour
{
	public AudioClip[] MusicChangerArray;
    private AudioSource _audioSource;

	//First thing that will run when the game is ran.
	private void Awake()
	{
        _audioSource = GetComponent<AudioSource>();
		DontDestroyOnLoad(gameObject);
		_audioSource.clip = MusicChangerArray [0];
		_audioSource.Play ();
	}


	// Check if the level was loaded 
    private void OnLevelWasLoaded(int level)
    {
        print("Music Playing from: " + name); 
        AudioClip thisLevelAudioClip = MusicChangerArray[level];

		//If there is a music element attached to the array index
        if (thisLevelAudioClip != null) 
        {
            _audioSource.clip = thisLevelAudioClip;
            _audioSource.loop = true;
            _audioSource.Play();
        }

    }
}
