using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    public float totalTime = 5f;
    public float timer;
    public GameObject bar;
    public GameObject text;
    public Vector3 barScale;
    public float maxLength = 1.05f;

	// Use this for initialization
	void Start () {
        timer = totalTime;
        barScale = bar.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0) {
            timer -= Time.deltaTime;
            barScale.x = maxLength * (totalTime - timer) / 5f;
            bar.transform.localScale = barScale;
            text.GetComponent<TextMesh>().text = ((int)timer + 1).ToString() + "s";
        } else {
            timer = -1;
            text.GetComponent<TextMesh>().text = "0s";
        }
	}
}
