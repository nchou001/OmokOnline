using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonManager : MonoBehaviour {

	public GameObject buttonPrefab;
	public GameObject gridLayout;
	public GameLogic gameLogic;

	// Use this for initialization
	void Awake () {
		for (int i = 0; i < 225; i++) {
			GameObject prefabInstance = Object.Instantiate (buttonPrefab);
			prefabInstance.transform.SetParent (gridLayout.transform, false);  //false needed so scale doesn't change
			Button button = prefabInstance.GetComponent<Button> ();
			int index = i;
			button.onClick.AddListener(() => { OnButtonClicked(index, button); });
		}
	}

	// Update is called once per frame
	void Start () {

	}

	public void OnButtonClicked(int buttonIndex, Button b)
	{
		int currPlayer = gameLogic.GetCurrPlayer ();
		if (gameLogic.PlaceMove (buttonIndex) == 0) {
			if (currPlayer == 1) {
				b.GetComponent<Image> ().color = Color.red;
			} else if (currPlayer == 2) {
				b.GetComponent<Image> ().color = Color.blue;
			}
		} else {
			Debug.Log ("Tried to click opponent's piece");
		}
	}
}