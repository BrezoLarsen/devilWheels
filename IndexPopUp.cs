using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndexPopUp : MonoBehaviour {

	public Image BGpop;
	public Image imgPop;
	public Button continueButton;
	public GameObject IndexPopUpGO;
	public CountDown countDownScript;

	public void ClosePop() 
	{
		// Cuando le demos al botón continuar se inicia la cuenta a trás
		countDownScript.InitCountDown();
		// Las imágenes se funden
		BGpop.CrossFadeAlpha(0,0.3f,false);
		imgPop.CrossFadeAlpha(0,0.3f, false);
		// Desactivamos el botón
		continueButton.gameObject.SetActive(false);
	}



}
