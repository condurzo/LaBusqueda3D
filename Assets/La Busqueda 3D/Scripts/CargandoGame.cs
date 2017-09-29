using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargandoGame : MonoBehaviour {

	void Start () {
		Invoke ("IrHome", 0.1f);
	}

	void IrHome(){
		ManagerGame.comenzarTiempo = false;
		Application.LoadLevel ("Home");
	}
}
