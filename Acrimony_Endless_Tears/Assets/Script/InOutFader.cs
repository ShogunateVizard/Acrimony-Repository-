using UnityEngine;
using UnityEngine.UI;

public class InOutFader: MonoBehaviour
{

	public float FadeTime;

	private Image _image;
	private Color _currentColor = Color.black;

	// Use this for initialization
	void Start ()
	{
		_image = GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.timeSinceLevelLoad < FadeTime)
		{
			_image.CrossFadeColor(_currentColor, FadeTime, false, true);
		} else
		{
			gameObject.SetActive (false);
		}
	}
}
