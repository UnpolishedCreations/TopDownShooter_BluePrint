using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int gameTimer;
	public static bool isGameStarted;

	// Initialization for game
	void Start () {

		// hide cursor
		Screen.showCursor = false; 

		isGameStarted = true;
		gameTimer = 10;

	}

}
