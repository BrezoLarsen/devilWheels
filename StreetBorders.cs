using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetBorders : MonoBehaviour {

	public GameObject streetMotor;
	public StreetMotor streetMotorScript;
	public GameObject player;

	// Utilizamos OnTrigger porque le hemos puesto que es trigger, sino marcamos esa casilla sería OnCollisionEnter
	public void OnTriggerEnter2D(Collider2D cInfo)
	{
		if(cInfo.gameObject.tag == "Player")
		{
			streetMotorScript.SpeedBorder();
			player.GetComponent<AudioSource>().pitch = 1f;
		}
	}

	public void OnTriggerExit2D(Collider2D cInfo)
	{
		if(cInfo.gameObject.tag == "Player") 
		{
			streetMotorScript.SpeedRoad();
			player.GetComponent<AudioSource>().pitch = 1f;
		}
	}
	
}
