using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	private int currPlayer;
	private int[,] array2D = new int[15, 15];
	// Use this for initialization
	void Start () {
		currPlayer = 1;
	}

	public int PlaceMove (int buttonIndex) {
		int x = buttonIndex / 15;
		int y = buttonIndex % 15;
		Debug.Log (buttonIndex);
		Debug.Log (x);
		Debug.Log (y);
		if (array2D [x, y] == 0) {
			array2D [x, y] = currPlayer;
			if (currPlayer == 1) {
				currPlayer = 2;
			} else if (currPlayer == 2) {
				currPlayer = 1;
			}
			if (CheckWin () != 0) {
				Debug.Log ("GameOver");
			}
			return 0;
		} else {
			return 1;
		}
	}

	public int GetCurrPlayer () {
		return currPlayer;
	}

	private int CheckWin(){
		//Check for vertical win
		for (int row = 0; row <= 10; row++) {
			for (int col = 0; col <= 14; col++) {
				if (array2D [row, col] != 0 &&
				   array2D [row, col] == array2D [row + 1, col] &&
				   array2D [row, col] == array2D [row + 2, col] &&
				   array2D [row, col] == array2D [row + 3, col] &&
				   array2D [row, col] == array2D [row + 4, col]) {
					return array2D [row, col];
				}
			}
		}

		//Check for horizontal win
		for (int row = 0; row <= 14; row++) {
			for (int col = 0; col <= 10; col++) {
				if (array2D [row, col] != 0 &&
					array2D [row, col] == array2D [row, col+1] &&
					array2D [row, col] == array2D [row, col+2] &&
					array2D [row, col] == array2D [row, col+3] &&
					array2D [row, col] == array2D [row, col+4]) {
					return array2D [row, col];
				}
			}
		}

		//Check for diagonal win
		for (int col = 0; col <= 10; col++) {
			for (int row = 0; row <= 10; row++) {
				if (array2D [row, col] != 0 &&
				    array2D [row, col] == array2D [row + 1, col + 1] &&
				    array2D [row, col] == array2D [row + 2, col + 2] &&
				    array2D [row, col] == array2D [row + 3, col + 3] &&
				    array2D [row, col] == array2D [row + 4, col + 4]) {
					return array2D [row, col];
				}
			}
			for (int row = 4; row <= 14; row++) {
				if (array2D [row, col] != 0 &&
				    array2D [row, col] == array2D [row - 1, col + 1] &&
				    array2D [row, col] == array2D [row - 2, col + 2] &&
				    array2D [row, col] == array2D [row - 3, col + 3] &&
				    array2D [row, col] == array2D [row - 4, col + 4]) {
					return array2D [row, col];
				}
			}
		}

		return 0;
	}
}
