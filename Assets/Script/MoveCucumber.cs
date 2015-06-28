using UnityEngine;
using System.Collections;

public class MoveCucumber : MonoBehaviour {
    public bool canControl = true;
    public bool isDrag = false;
    public Vector3 mousePos;
    public Vector3 cucumberPos;
    public bool isEat = false;
    public GameObject cucumberIdle;
    public GameObject cucumberEat;
    public GameObject mikhail;
    public GameObject basket;
    public GameObject timer;
    public GameObject catchMikhail;
    //public GameObject replayButton;
    public bool win = false;
    public bool gameOver = false;

    public GameObject winText;
    public GameObject walkMouse;
    public GameObject loseText;


	// Use this for initialization
	void Start () {
        cucumberPos = new Vector3(-6f, 2f, 0f);
        winText.SetActive(false);
        loseText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Input.mousePosition);
        if (isDrag) {
            Move();
        }

        if (isEat) {
            cucumberIdle.SetActive(false);
            cucumberEat.SetActive(true);
            if (!canControl) {
                win = true;
            }
        } else {
            cucumberIdle.SetActive(true);
            cucumberEat.SetActive(false);
        }

        if (win && !gameOver) {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(mikhail.GetComponent<Rigidbody2D>());
            if (timer.GetComponent<Timer>().timer == -1f) {
                Debug.Log("You run out of time!!");
                gameOver = true;
                //iTween.MoveTo(replayButton, new Vector3(0, 0, 0), .5f);
                loseText.SetActive(true);
            } else {
                Debug.Log("Catch Mikhail!!");
                iTween.MoveTo(basket, iTween.Hash("y", 3.3f, "time", .5f, "oncomplete", "CatchInCage", "oncompletetarget", this.gameObject));
                gameOver = true;
            }
        }

	}

    void Move() {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    void OnMouseDown() {
        isDrag = true;
    }

    void OnMouseUp() {
        isDrag = false;
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Plate")) {
            canControl = false;
            gameObject.transform.position = cucumberPos;
        }
    }

    void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Mikhail")) {
            isEat = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Mikhail")) {
            isEat = false;
        }
    }

    void CatchInCage() {
        iTween.MoveTo(catchMikhail, iTween.Hash("y", 7, "time", 2f, "oncomplete", "ShowText", "oncompletetarget", this.gameObject));
    }

    void ShowText() {
        winText.SetActive(true);
        iTween.MoveTo(walkMouse, iTween.Hash("x", -10f, "easeType", iTween.EaseType.linear, "looptype", "pingpong", "islocal", true, "time", 10f));
    }
}