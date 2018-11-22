using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

	public GameObject streetMotor;
	public GameObject gameMusic;
	public GameObject startSound;
	public GameObject carMotorSound;
	public GameObject numbers;

	public Sprite[] numbersIMG;

	public StreetMotor streetMotorScript;
	public Chrono chronoScript;

	float waitTime = 4;

	public bool stopCount = false;
	public bool endCounter = false;

	// Estos componentes los seteamos en Unity en el script del CountDown
	public AudioSource countDownAudioSource;
	public AudioClip[] counterSounds;


	// Use this for initialization
	void Start () 
	{
		countDownAudioSource = this.gameObject.GetComponent<AudioSource>();
		// Comentamos una función para que esta acción ocurra desde IndexPopUp.cs
		//InitCountDown();
	}

	public void InitCountDown() 
	{
		//Con esta función podemos setear tiempos de espera
		StartCoroutine(StartCountDown());
	}

	public IEnumerator StartCountDown() 
	{
		// Iniciamos el sonido de arrancar el coche
		// Estos componentes los seteamos en Unity en el script del CountDown
		startSound.GetComponent<AudioSource>().Play();
		// Le indicamos que espere un segundo antes de seguir leyendo el código
		yield return new WaitForSeconds(1);
		// LLamamos a la función "Contando" cada segundo, y esperamos un segundo para volver a llamarla
		InvokeRepeating("Counting", 1.0f, 1.0f);
	}

	void Counting()
	{
		// Restamos un número
		waitTime --;

		if(waitTime >= 3)
		{
			numbers.GetComponent<SpriteRenderer>().sprite = numbersIMG[3];
			countDownAudioSource.clip = counterSounds[0];
			countDownAudioSource.Play();
		}
		if(waitTime <= 3 && waitTime >= 2)
		{
			numbers.GetComponent<SpriteRenderer>().sprite = numbersIMG[2];
			countDownAudioSource.clip = counterSounds[0];
			countDownAudioSource.Play();
		}
		if(waitTime <= 2 && waitTime >= 1)
		{
			numbers.GetComponent<SpriteRenderer>().sprite = numbersIMG[1];
			countDownAudioSource.clip = counterSounds[0];
			countDownAudioSource.Play();
		}
		if(waitTime <= 1 && endCounter == false)
		{
			endCounter = true;
			chronoScript.chronoOn = true;
			streetMotorScript.countDownEnd = true;
			numbers.GetComponent<SpriteRenderer>().sprite = numbersIMG[0];
			countDownAudioSource.clip = counterSounds[1];
			countDownAudioSource.Play();

			gameMusic.GetComponent<AudioSource>().Play();
			// Estos componentes los seteamos en Unity en el script del CountDown
			carMotorSound.GetComponent<AudioSource>().Play();
		}
		if(waitTime <= 0)
		{
			// Cancelamos las llamadas recurrentes que convocamos previamente (línea 47)
			CancelInvoke();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Comrpobamos que si el tiempo de espera es mayor o igual a 
		if(waitTime == 0 && stopCount == false)
		{
			stopCount = true;
			numbers.SetActive(false);
		}
	}
}
