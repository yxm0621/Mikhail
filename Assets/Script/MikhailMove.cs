using UnityEngine;
using System.Collections;

public class MikhailMove : MonoBehaviour {
    public GameObject cucumber;
    public MoveCucumber cucumberScript;
    public float force = .01f;
    public Vector3 forceDirection;
    public GameObject thermometer;
    public Temperature thermometerScript;
    public float temperature;
    //public bool catchMikhail = false;

	// Use this for initialization
	void Start () {
        cucumberScript = cucumber.GetComponent<MoveCucumber>();
        thermometerScript = thermometer.GetComponent<Temperature>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //if (!cucumberScript.isEat) {
            force = (1 - thermometerScript.temperature) * .01f;
            forceDirection = cucumber.transform.position - gameObject.transform.position;
            //gameObject.GetComponent<Rigidbody2D>().AddForce(forceDirection * force);
            //iTween.MoveTo(gameObject, iTween.Hash("position", cucumber.transform.position, "easeType", iTween.EaseType.linear, "time", 2f));
            gameObject.transform.Translate(forceDirection * force);
        //} else {
        //    Destroy(gameObject.GetComponent<Rigidbody2D>());
        //}
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Plate")) {
            //catchMikhail = true;
            cucumberScript.win = true;
        }
    }
}
