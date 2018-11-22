using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetDestroy : MonoBehaviour 
{
	// En Unity, donde añadimos el script Street Destroy añadimos: 
	// Script -> StreetDestroy
	// Street Motor Script -> StreetMotor (lo añadimos desde la ventana de jerarquía)
	public StreetMotor streetMotorScript;

	public void OnTriggerEnter2D(Collider2D cInfo) 
	{
		if(cInfo.gameObject.tag == "StreetLimit") 
		{
			Destroy(cInfo.transform.parent.gameObject);
			streetMotorScript.StreetCreator();
		}
	}

}
