using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonManager : MonoBehaviour {

	public GameObject buttonPrefab;
	public GameObject gridLayout;

	// Use this for initialization
	void Awake () {
		for (int i = 0; i < 225; i++) {
			GameObject prefabInstance = Object.Instantiate (buttonPrefab);
			prefabInstance.transform.SetParent (gridLayout.transform, false);  //false needed so scale doesn't change
			Button button = prefabInstance.GetComponent<Button> ();
			button.onClick.AddListener(() => { OnButtonClicked(i, button); });
		}
	}

	// Update is called once per frame
	void Start () {

	}

	public void OnButtonClicked(int buttonIndex, Button b)
	{
		b.GetComponent<Image> ().color = Color.red;
	}
}