using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private AudioSource audioSource;
	public AudioClip ClickSound;
    // Start is called before the first frame update
    public GameObject ExitPanel;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
			ExitPopup();
		}
    }
    public void PlayGame() {
		SceneManager.LoadScene ("GamePlayScene");
        audioSource.PlayOneShot(ClickSound);
	}
    public void ExitPopup() {
        ExitPanel.SetActive(true);
        audioSource.PlayOneShot(ClickSound);
    }
    public void CloseExitPopup() {
        ExitPanel.SetActive(false);
        audioSource.PlayOneShot(ClickSound);
    }
    public void ExitGame() {
        Application.Quit();
        audioSource.PlayOneShot(ClickSound);
    }
    public void BackToMenu() {
        SceneManager.LoadScene ("MainMenuScene");
        audioSource.PlayOneShot(ClickSound);
    }
}
