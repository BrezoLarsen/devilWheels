using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetMotor : MonoBehaviour {

	//Declaramos todos los elementos de StreetMotor
	public GameObject streetMotor;
	public GameObject[] streetContainer;

	public float speed;

	public int streetSelectorNum;
	public int streetCounter = 0;

	public bool countDownEnd;
	public bool endGame;

	GameObject[] lives;


	// Use this for initialization
	void Start () {
		endGame = false;
		InitGame();
	}

	public void InitGame() {
		StreetCreator();
		SpeedRoad();
		countDownEnd = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(countDownEnd && (endGame == false)) 
		{
			// Vector3.down se refiere al eje Y hacia abajo
			// Time.deltatime obtiene una velocidad por segundo (controla la velocidad en el Update)
			streetMotor.transform.Translate(Vector3.down * speed * Time.deltaTime);

		}


		
	}

	// Función para crear las calles
	public void StreetCreator() 
	{
		streetSelectorNum = Random.Range(0,5);

		// Instanciamos el objeto calle, que es de tipo GameObject, lo buscamos en el streetContainer con el num aleatorio que dijimos arriba
		GameObject Street = (GameObject)Instantiate(streetContainer[streetSelectorNum],
													new Vector3(0,50,0),
													transform.rotation);

		// Accedemos a las propiedades del GameObject Street
		Street.SetActive(true);
		streetCounter++;
		Street.name = "Street"+streetCounter;
		// Hacemos Street hijo de streetMotor
		Street.transform.parent = streetMotor.transform;

		// Con (streetCounter-1) cogemos la pieza anterior a la que tenemos 
		GameObject auxPiece = GameObject.Find("Street"+(streetCounter-1));

		// Trabajamos la posición de la calle
		Street.transform.position = new Vector3(transform.position.x, // Valor 0 en X
												auxPiece.GetComponent<Renderer>().bounds.size.y + // Calculamos el tamaño de la pieza en Y
												auxPiece.transform.position.y, // En Y teníamos la posición 50, le sumamos el tamaño de la pieza
												auxPiece.transform.position.z); // Valor 0 en Z
	}

	// Funciones de velocidad
	public void SpeedStop () 
	{
		speed = 0;
	}

	public void SpeedBorder() 
	{
		speed = 5;
	}

	public void SpeedRoad() 
	{
		speed = 20;
	}

	public void SpeedObstacle() 
	{
		speed = 3;
	}

	public void EndingGame() 
	{
		SpeedStop();
	}
}
