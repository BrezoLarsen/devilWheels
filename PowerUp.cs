using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public GameObject ChronoGO;
	public Chrono chronoScript;

	void OnTriggerEnter2D (Collider2D cInfo)
	{
		if(cInfo.gameObject.tag == "Player")
		{
			chronoScript.time += 10;
			chronoScript.moreTimeIMG();
			// Desactivamos la imagen
			gameObject.SetActive(false);
		}
	}
}
