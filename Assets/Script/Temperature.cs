using UnityEngine;
using System.Collections;

public class Temperature : MonoBehaviour {
    public GameObject number;
    public float temperature = 0;
    public Vector3 temperatureScale;
    public float speed = .005f;
    public int reduceTimes = 50;

	// Use this for initialization
	void Start () {
        temperatureScale = number.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetMouseButtonDown(1))) {
            float reduceAmount = speed * reduceTimes * temperature;
            if (temperature > reduceAmount) {
                temperature -= reduceAmount;
            } else {
                temperature = 0;
            }
        } else {
            if (temperature < 1) {
                temperature += speed;
            } else {
                temperature = 1;
            }
        }
        
        temperatureScale.y = temperature;
        number.transform.localScale = temperatureScale;
	}
}
