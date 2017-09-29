using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour {

	public Sprite[] Chistes;
	public GameObject ChisteGO;
	public float TimeChistes;
	public static bool ChisteBool;
	public bool ActivarChisteBool;
	public static int ChisteNumero;
	public static bool comenzoJuego;
	public static bool MostrarChiste;

	public GameObject CargandoGO;

	public GameObject EmpezarBtn;
	public GameObject CamaraBtn;
	public GameObject FondoPrevio;
	public GameObject BannerInicio;

	public float TiempoJuego;
	public int minutes;
	public int seconds;
	public Text TiempoText;
	public static bool comenzarTiempo;

	public GameObject CartelTiempo;
	public GameObject VolverJugarTime;
	bool terminoTiempo;

	public AudioSource MusicaFondo;
	public AudioClip AudioMusica;

	public AudioSource AudioPocoTiempo;
	public AudioClip PocoTiempo;
	public AudioSource AudioTerminoTiempo; 
	public bool OneShotTiempo;

	void Start(){
		//MusicaFondo = GetComponent<AudioSource> ();
	}

	public void EmpezarFuncion(){
		ChisteBool = false;
		FondoPrevio.SetActive (false);
		BannerInicio.SetActive (true);
		comenzoJuego = true;
		comenzarTiempo = true;
		EmpezarBtn.SetActive(false);
		CamaraBtn.SetActive(true);
		TimeChistes = 0;

		//MusicaFondo.clip = AudioMusica;
		//MusicaFondo.volume = 0.25f;
		MusicaFondo.Play ();
		MusicaFondo.loop = true;

	}

	public void GoToHome(){
		CargandoGO.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (comenzoJuego) {
			if (!ChisteBool) {
				ChisteNumero = Random.Range (0, 5);
				ChisteBool = true;
				ActivarChisteBool = true;
			}
			if (ActivarChisteBool) {
				TimeChistes += Time.deltaTime;
			}
			if ((ChisteNumero == 0) && (TimeChistes >= 30)&&(!terminoTiempo)) {
				ChisteGO.GetComponent<CanvasGroup> ().alpha = 1;
				ChisteGO.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				ChisteGO.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				ChisteGO.GetComponent<Image> ().sprite = Chistes [0];
				TimeChistes = 0;
				ActivarChisteBool = false;
				MostrarChiste = true;
			}
			if ((ChisteNumero == 1) && (TimeChistes >= 35)&&(!terminoTiempo)) {
				ChisteGO.GetComponent<CanvasGroup> ().alpha = 1;
				ChisteGO.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				ChisteGO.GetComponent<CanvasGroup> ().blocksRaycasts = true;;
				ChisteGO.GetComponent<Image> ().sprite = Chistes [1];
				TimeChistes = 0;
				ActivarChisteBool = false;
				MostrarChiste = true;
			}
			if ((ChisteNumero == 2) && (TimeChistes >= 40)&&(!terminoTiempo)) {
				ChisteGO.GetComponent<CanvasGroup> ().alpha = 1;
				ChisteGO.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				ChisteGO.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				ChisteGO.GetComponent<Image> ().sprite = Chistes [2];
				TimeChistes = 0;
				ActivarChisteBool = false;
				MostrarChiste = true;
			}
			if ((ChisteNumero == 3) && (TimeChistes >= 45)&&(!terminoTiempo)) {
				ChisteGO.GetComponent<CanvasGroup> ().alpha = 1;
				ChisteGO.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				ChisteGO.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				ChisteGO.GetComponent<Image> ().sprite = Chistes [3];
				TimeChistes = 0;
				ActivarChisteBool = false;
				MostrarChiste = true;
			}
			if ((ChisteNumero == 4) && (TimeChistes >= 45)&&(!terminoTiempo)) {
				ChisteGO.GetComponent<CanvasGroup> ().alpha = 1;
				ChisteGO.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				ChisteGO.GetComponent<CanvasGroup> ().blocksRaycasts = true;
				ChisteGO.GetComponent<Image> ().sprite = Chistes [4];
				TimeChistes = 0;
				ActivarChisteBool = false;
				MostrarChiste = true;
			}

			if (TiempoJuego >= 285) {//285 - 5 Min
				if (!AudioPocoTiempo.isPlaying) {
					AudioPocoTiempo.Play ();
				}
			}
		}

		//TIEMPO JUEGO
		if((comenzarTiempo)&&(!terminoTiempo)){
			TiempoJuego += Time.deltaTime;
		}

		if (TiempoJuego >= 300) {//300 - 5 Min
			AudioPocoTiempo.Stop ();
			if ((!AudioTerminoTiempo.isPlaying)&&(!OneShotTiempo)) {
				AudioTerminoTiempo.Play ();
				OneShotTiempo = true;
			}
			MusicaFondo.Stop ();
			CartelTiempo.SetActive(true);
			VolverJugarTime.SetActive(true);
			CamaraBtn.SetActive(false);
			terminoTiempo = true;
		}
	
		minutes = Mathf.FloorToInt(TiempoJuego / 60F);
		seconds = Mathf.FloorToInt(TiempoJuego - minutes * 60);
		string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
		TiempoText.text = niceTime;

		if(!comenzarTiempo){
			TiempoJuego = 0;
			minutes = 0;
			seconds = 0;
			CartelTiempo.SetActive(false);
			VolverJugarTime.SetActive(false);
			terminoTiempo = false;
		}

	}

	public void JugarDeNuevoTime(){
		OneShotTiempo = false;
		FondoPrevio.SetActive (true);
		AudioPocoTiempo.Stop ();
		AudioTerminoTiempo.Stop ();
		MusicaFondo.Stop ();
		EmpezarBtn.SetActive(true);
		comenzarTiempo = false;
		terminoTiempo = false;
		comenzoJuego = false;
		TiempoJuego = 0;
		minutes = 0;
		seconds = 0;
		TimeChistes = 0;
	}
		

}
