using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerDown : MonoBehaviour {

	public GameController gameController;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			gameController.RemoveLife();
			// Desactivamos la imagen
			gameObject.SetActive(false);
		}
	}
}


// public class PowerDown : MonoBehaviour {
// 	public GameObject[] lifes;
// 	public int lifeCounter = 3;
// 	// Lo llamamos cuando se acaban las vidas
// 	public GameObject PopGameOverGo;
// 	// El script popGameOverScript lo necesitamos para llamar a la función GameOverActive
// 	public GameOverPopUp popGameOverScript;
// 	// El motor de carreteras lo llamamos para pararle el sonido
// 	public GameObject steetMotor;
// 	// El script StreetMotorScript lo necesitamos para parar la velocidad en caso de perder las vidas
// 	public StreetMotor StreetMotorScript;
// 	// El script chronoScript lo necesitamos para parar el cronómetro
// 	public Chrono chronoScript;

// 	public Image life;

// 	void Start() 
// 	{
// 		life.CrossFadeAlpha(0,0.3f,false);
// 	}

// 	void Update()
// 	{
// 		if(lifeCounter == 2 && StreetMotorScript.endGame == false)
// 		{
// 			lifes[2].SetActive(false);
// 		}
// 		if(lifeCounter == 1)
// 		{
// 			lifes[1].SetActive(false);
// 		}
// 		if(lifeCounter == 0 && StreetMotorScript.endGame == false)
// 		{
// 			lifes[0].SetActive(false);
// 			StreetMotorScript.endGame = true;
// 			chronoScript.chronoOn = false;
// 			PopGameOverGo.SetActive(true);
// 			popGameOverScript.GameOverActive();
// 		}
// 	}

// 	public void LessLife()
// 	{
// 		if(lifeCounter >= 1)
// 		{
// 			life.CrossFadeAlpha(1,0.5f,false);
// 			this.gameObject.GetComponent<AudioSource>().Play();
// 			StartCoroutine(CloseLessLifeIMG());
// 		}
// 	}

// 	IEnumerator CloseLessLifeIMG()
// 	{
// 		yield return new WaitForSeconds(1);
// 		life.CrossFadeAlpha(0,0.5f,false);
// 	}
// }
