using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPopUp : MonoBehaviour {

	public Image BGPop;
	public Image ImgPop;
	public Button restartButton;
	public Text finalDistance;
	public GameObject PopGameOverGo;
	public Image fadeOutIMG;
	public Chrono chronoScript;
	public GameObject gameMusic;
	public AudioClip gameOverMusic;


		// Use this for initialization
		void Start () {
			PopGameOverGo.SetActive(false);
		}

		public void GameOverActive() {
			// Cambiamos la música del juego por la de Game Over
			gameMusic.GetComponent<AudioSource>().clip = gameOverMusic;
			gameMusic.GetComponent<AudioSource>().loop = false;
			gameMusic.GetComponent<AudioSource>().Play();
			// Hacemos que aparezca el popup
			restartButton.gameObject.SetActive(true);
			BGPop.CrossFadeAlpha(1,0.3f,false);
			ImgPop.CrossFadeAlpha(1,0.3f,false);
			finalDistance.CrossFadeAlpha(1,0.3f,false);
			// Mostramos la distancia total recorrida, hacemos un cast para pasar el dato de float a string
			finalDistance.text = ((int)chronoScript.distance).ToString() + "mts";
		}

		public void RestartGame() 
		{
			// Iniciamos una coroutine para esperar a que acabe de hacer la imagen de fundido
			StartCoroutine(SceneCharge());
		}

		// Función tipo Coroutine tiene que ser IEnumerator
		IEnumerator SceneCharge()
		{
			// Hacemos que espere un segundo antes de cargar la escena
			yield return new WaitForSeconds(0);
			fadeOutIMG.CrossFadeAlpha(1,0.3f,false);
		
			// Cargamos la escena
			SceneManager.LoadScene("Intro");
			Start();
		}
}
