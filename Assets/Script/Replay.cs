using UnityEngine;
using System.Collections;

public class Replay : MonoBehaviour {
    public bool isPress = false;
    public GameObject replay;
    public GameObject replayPress;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isPress) {
            replay.SetActive(false);
            replayPress.SetActive(true);
        } else {
            replay.SetActive(true);
            replayPress.SetActive(false);
        }
	}

    void OnMouseDown() {
        isPress = true;
    }

    void OnMouseUp() {
        isPress = false;
        Application.LoadLevel(0);
    }
}
