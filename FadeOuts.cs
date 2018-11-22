using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOuts : MonoBehaviour {

	public Image fadeOutIMG;

	// Use this for initialization
	public void Start () {
		fadeOutIMG.CrossFadeAlpha(0,0.5f,false);
	}
	public void Stop () {
		fadeOutIMG.CrossFadeAlpha(1,0.5f,false);
	}
	
}
