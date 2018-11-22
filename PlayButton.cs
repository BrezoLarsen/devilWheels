using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	public Image fadeOut;

	// Escribimos las funciones que proporciona Unity para detectar los efectos del ratón (ineraccionan con el collider del botón)
	void OnMouseDown() {
		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f,1);
		this.gameObject.GetComponent<AudioSource>().Play();
	}

	void OnMouseOver() {
		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f,1);
	}

	void OnMouseExit() {
		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
	}

	void OnMouseUp() {
		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
		this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
		fadeOut.CrossFadeAlpha(1, 0.5f, false);
		StartCoroutine(StartGame());
	}

	IEnumerator StartGame() {
		yield return new WaitForSeconds(1);
		// Application.LoadLevel("Juego");
		SceneManager.LoadScene("Juego");
	}
	
}
