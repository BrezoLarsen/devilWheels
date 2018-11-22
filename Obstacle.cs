using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public GameObject streetMotor;
	public StreetMotor streetMotorScript;
	public GameObject player;

	// Utilizamos OnCollisionEnter2D porque no le hemos puesto que es trigger, si marcamos esa casilla sería OnTriggerEnter2D
	public void OnCollisionEnter2D(Collision2D cInfo)
	{
		if(cInfo.gameObject.tag == "Player")
		{
			streetMotorScript.SpeedObstacle();
			player.GetComponent<AudioSource>().pitch = 1f;
			this.gameObject.GetComponent<AudioSource>().Play();
		}
		
	}

	public void OnCollisionExit2D(Collision2D cInfo)
	{
		if(cInfo.gameObject.tag == "Player") 
		{
			streetMotorScript.SpeedRoad();
			player.GetComponent<AudioSource>().pitch = 1f;
		}
	}

}
