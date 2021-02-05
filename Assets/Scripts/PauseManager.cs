using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
	public GameObject panelPause;

	private AudioSource audioSource;
	public AudioClip ClickSound;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (Time.timeScale == 1) {
				panelPause.SetActive (true);
				Time.timeScale = 0;
				audioSource.PlayOneShot(ClickSound);
			}
		}
	}
	
	public void MenuSelect() {
		SceneManager.LoadScene ("MainMenuScene");
		Time.timeScale = 1;
		panelPause.SetActive (false);
		audioSource.PlayOneShot(ClickSound);
	}

	public void Unpause() {
		Time.timeScale = 1;
		panelPause.SetActive (false);
		audioSource.PlayOneShot(ClickSound);
	}	
}
