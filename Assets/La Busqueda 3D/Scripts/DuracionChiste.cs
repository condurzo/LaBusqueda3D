using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuracionChiste : MonoBehaviour {

	public float TimeDuration;
	public Text Relog;
	public AudioSource Sonidos;
	public AudioClip SonidoChiste1;
	public AudioClip SonidoChiste2;
	public AudioClip SonidoChiste3;
	public AudioClip SonidoChiste4;
	public AudioClip SonidoChiste5;

	public bool EmpezarContar;

	// Update is called once per frame
	void Update () {
		//Debug.Log (ManagerGame.MostrarChiste);

		if (ManagerGame.MostrarChiste) {

			EmpezarContar = true;

			if (ManagerGame.ChisteNumero == 0) {
				if (!Sonidos.isPlaying) {
					Sonidos.clip = SonidoChiste1;
					Sonidos.Play ();
					ManagerGame.MostrarChiste = false;
				}
			}
			if (ManagerGame.ChisteNumero == 1) {
				if (!Sonidos.isPlaying) {
					Sonidos.clip = SonidoChiste2;
					Sonidos.Play ();
					ManagerGame.MostrarChiste = false;
				}
			}
			if (ManagerGame.ChisteNumero == 2) {
				if (!Sonidos.isPlaying) {
					Sonidos.clip = SonidoChiste3;
					Sonidos.Play ();
					ManagerGame.MostrarChiste = false;
				}
			}
			if (ManagerGame.ChisteNumero == 3) {
				if (!Sonidos.isPlaying) {
					Sonidos.clip = SonidoChiste4;
					Sonidos.Play ();
					ManagerGame.MostrarChiste = false;
				}
			}
			if (ManagerGame.ChisteNumero == 4) {
				if (!Sonidos.isPlaying) {
					Sonidos.clip = SonidoChiste5;
					Sonidos.Play ();
					ManagerGame.MostrarChiste = false;
				}
			}

		}


		if (EmpezarContar) {
			TimeDuration += Time.deltaTime;
			if (TimeDuration >= 1) {
				Relog.GetComponent<Text> ().enabled = true;
			}
			Relog.text = ((int)TimeDuration).ToString ();
			if (TimeDuration >= 4) {
				this.gameObject.GetComponent<CanvasGroup> ().alpha = 0;
				this.gameObject.GetComponent<CanvasGroup> ().blocksRaycasts = false;
				this.gameObject.GetComponent<CanvasGroup> ().blocksRaycasts = false;
				TimeDuration = 0;
				Relog.GetComponent<Text> ().enabled = false;
				ManagerGame.ChisteBool = false;
				EmpezarContar = false;
			}
		}
	}
}
