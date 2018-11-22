using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	public GameObject Player;
	public float carVelocity;

	//float factor = 3;
	public float turningAngle;

	// UTILIZO FIXUPDATE estoy moviendo un componente rigidbody que choca con autos rigidos	
	void FixedUpdate() {
		// el giro en cero
		float turningAxisZ = 0;
		// teclas left y right afectan al coche
		transform.Translate(Vector3.right * 
							Input.GetAxis("Horizontal")*
							carVelocity*
							Time.deltaTime
							);

		// ROTACIÓN DEL COCHE
		// Calculo el giro left y right multiplicando el angulo de rotacion
		turningAxisZ = Input.GetAxis("Horizontal")* -turningAngle;
		// Aplicamos la rotación al coche
		// Quaternion.Euler -> Función avanzada que controla las funciones de giro
		Player.transform.rotation = Quaternion.Euler(0, 0, turningAxisZ);

		// Detectamos si el coche sale de la pantalla
		if(Player.transform.position.y < -4.3f || Player.transform.position.x < -10.0f 
											   || Player.transform.position.x > 10) 
		{
			ResetPosition();
		}
	}

	void ResetPosition()
	{
		Player.transform.position = new Vector3(0f, -2.4f, 0f);
	}

}
