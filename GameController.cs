using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject streetMotor;
    public StreetMotor streetMotorScript;

	public GameObject popGameOverGO;
    public GameOverPopUp popGameOverScript;

	public Chrono chronoScript;

    public GameObject player;

	public Image lessLife;

	GameObject[] lives;
	// Detectamos cuál fue la última imagen que ocultamos. Al pricipio ninguna, por eso es 0
	int actualLifeIndex = 0;

	void Awake(){
		lives = new GameObject[3];
		lives[0] = GameObject.Find("Life1");
		lives[1] = GameObject.Find("Life2");
		lives[2] = GameObject.Find("Life3");
	}

	// public void AddLife(){
	// 	lives[actualLifeIndex].SetActive(true);
	// 	actualLifeIndex--;
	// }

	public void RemoveLife()
	{
		if(actualLifeIndex == 2) {
			chronoScript.EndGame();
			return;
		}
		/* if(life0.activeSelf)
        {            
            DeactiveLife(life0);
            return;
        }
        if (life1.activeSelf)
		{
			DeactiveLife(life1);
            return;
		}
		if(life2.activeSelf)
		{
			DeactiveLife(life2);
            return;
		}*/

		for(var i = 0; i < lives.Length; i++){
			var life = lives[i];
			if(life.activeSelf)
			{
				print(actualLifeIndex);
				lessLifeIMG();
				DeactiveLife(life);
				actualLifeIndex++;
				return;
			}	
		}

		
	}

    private void DeactiveLife(GameObject life)
    {
        life.GetComponent<Image>().CrossFadeAlpha(0, 0.3f, false);
        life.SetActive(false);
    }

	public void lessLifeIMG()
		{
			lessLife.CrossFadeAlpha(1,0.5f,false);
			// this.gameObject.GetComponent<AudioSource>().Play();
			StartCoroutine(HideLessLifeIMG());
		}

		IEnumerator HideLessLifeIMG() 
		{
			yield return new WaitForSeconds(1);
			lessLife.CrossFadeAlpha(0,0.5f,false);
		}

}
