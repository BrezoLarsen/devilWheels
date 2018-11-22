using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chrono : MonoBehaviour {

    public GameObject streetMotor;
    public StreetMotor streetMotorScript;

    public Text timeText;
    public Text mtrText;

    public float distance;
    public float time;

    public bool chronoOn;

    public Image moreTime;
    public Image lessLife;

    public GameObject popGameOverGO;
    public GameOverPopUp popGameOverScript;

    public GameObject player;

    void Start() 
    {
        timeText.text = "1:30";
        mtrText.text = "0";

        time = 90;

        // Esta función decide la transparencia de la imagen de 0 a 1
        // El siguiente parámetro decide cuando aparece
        // El siguiente es si quiero usar un tiempo aparte
        moreTime.CrossFadeAlpha(0,0,false);
        lessLife.CrossFadeAlpha(0,0,false);

    }

    void Update () 
    {

        if (streetMotorScript.endGame == false && chronoOn == true)
        {
            // Calculamos la distancia: tiempo * velocidad
            distance += Time.deltaTime * streetMotorScript.speed;
            mtrText.text = ((int)distance).ToString();

            // Calculamos el tiempo (la cuenta es regresiva)
            time -= Time.deltaTime;
            int minutes = (int)time/60;
            int seconds = (int)time%60;
            // PadLeft nos dice que rellene siempre con dos caracteres, y si no tiene con qué rellenar que le poga un '0'
            timeText.text = minutes.ToString() + ":" + seconds.ToString().PadLeft(2,'0'); 
        }

        // Comprobamos si el tiempo llega a 0:
        if (time <= 0.00f && streetMotorScript.endGame == false)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        streetMotorScript.endGame = true;
        // Activamos el popup de game over
        popGameOverGO.SetActive(true);
        popGameOverScript.GameOverActive();
        player.GetComponent<AudioSource>().Stop();
    }

    public void moreTimeIMG()
    {
        moreTime.CrossFadeAlpha(1,0.5f,false);
        this.gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(HideMoreTimeIMG());
    }

    IEnumerator HideMoreTimeIMG() 
    {
        yield return new WaitForSeconds(1);
        moreTime.CrossFadeAlpha(0,0.5f,false);
    }
}