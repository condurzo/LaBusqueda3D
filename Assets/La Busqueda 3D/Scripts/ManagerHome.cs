using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerHome : MonoBehaviour {

	public GameObject Home;
	public GameObject Cargando;
	public GameObject Instruc4;

	public GameObject HomeiPad;
	public GameObject CargandoiPad;
	public GameObject Instruc4iPad;

	public void GotToGame () {
		Home.SetActive (false);
		Instruc4.SetActive (false);
		Cargando.SetActive (true);

		HomeiPad.SetActive (false);
		Instruc4iPad.SetActive (false);
		CargandoiPad.SetActive (true);
	}

	public void SalirAPP(){
		Application.Quit ();
	}
}
