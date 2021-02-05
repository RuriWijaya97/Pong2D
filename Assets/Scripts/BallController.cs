using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
		public int force;
    	Rigidbody2D rigid;
      	
      	int scoreP1;
      	int scoreP2;
      	
      	Text scoreUIP1;
      	Text scoreUIP2;
      	
      	public GameObject panelSelesai;

		private AudioSource audioSource;
		public AudioClip hitSound, goalSound;
      	
		public Text txPemenang;
      // Use this for initialization
    	void Start () {
      		rigid = GetComponent<Rigidbody2D> ();
     		Vector2 arah = new Vector2 (2, 0).normalized;
      		rigid.AddForce (arah * force);
      		scoreP1 = 0;
      		scoreP2 = 0;
      		scoreUIP1 = GameObject.Find ("Score1").GetComponent<Text> ();
      		scoreUIP2 = GameObject.Find ("Score2").GetComponent<Text> ();

      		panelSelesai = GameObject.Find("GameOverPanel");
      		panelSelesai.SetActive (false);

			audioSource = GetComponent<AudioSource>();
    	}
      // Update is called once per frame
      	void Update () {

	      }
      
      private void OnCollisionEnter2D (Collision2D coll) {
		audioSource.PlayOneShot(hitSound);
      	if (coll.gameObject.name == "SideRight") {
      		scoreP1 += 1;
      		TampilkanScore ();
			audioSource.PlayOneShot(goalSound);
      		if (scoreP1 == 5) {
      			panelSelesai.SetActive(true);
      			txPemenang = GameObject.Find("Win").GetComponent<Text>();
      			txPemenang.text = "Player 1 Win!";
      			Destroy (gameObject);
      			return;	
      		}
      		ResetBall ();
      		Vector2 arah = new Vector2 (2, 0).normalized;
      		rigid.AddForce (arah * force);
      	}
      	if (coll.gameObject.name == "SideLeft") {
      		scoreP2 += 1;
      		TampilkanScore ();
			audioSource.PlayOneShot(hitSound);
      		if (scoreP2 == 5) {
      			panelSelesai.SetActive(true);
      			txPemenang = GameObject.Find("Win").GetComponent<Text>();
      			txPemenang.text = "Player 2 Win!";
      			Destroy (gameObject);
      			return;	
      		}
      		ResetBall ();
      		Vector2 arah = new Vector2 (-2, 0).normalized;
      		rigid.AddForce (arah * force);
      	}
      	if (coll.gameObject.name == "Player1" || coll.gameObject.name == "Player2") {
      		float sudut = (transform.position.y - coll.transform.position.y) * 5f;
      		Vector2 arah = new Vector2 (rigid.velocity.x, sudut).normalized;
    		rigid.velocity = new Vector2 (0, 0);
      		rigid.AddForce (arah * force * 2);
      	}
      }
      	void ResetBall () {
      		transform.localPosition = new Vector2 (0, 0);
      		rigid.velocity = new Vector2 (0, 0);
      }	
      	void TampilkanScore () {
      		Debug.Log ("Score P1: " + scoreP1 + " Score P2: " + scoreP2);
      		scoreUIP1.text = scoreP1 + "";
      		scoreUIP2.text = scoreP2 + "";
      	}
}