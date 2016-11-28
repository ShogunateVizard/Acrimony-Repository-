
﻿using System.Net;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
﻿using UnityEngine;

public class TimeControl : MonoBehaviour
{

	[Range(0, 5)]
	public float TimeScale = 1.0f;

	// Alway check for the input of the time by player.
	private void Update()
	{
		Time.timeScale = TimeScale;
	}
}