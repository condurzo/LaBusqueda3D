using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class FocoContinuo : MonoBehaviour {

	public float Contador;
	public bool activar;
	public bool activarTime;

	void Start () {
		CameraDevice.Instance.SetFocusMode(
			CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
//		CameraDevice.Instance.SetFocusMode(
//			CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}

	void Update () {
//		CameraDevice.Instance.SetFocusMode(
//			CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

		Contador += Time.deltaTime;

		if (Contador >= 2) {
			CameraDevice.Instance.SetFocusMode(
				CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
			Contador = 0;
		}

	}
//
//	void Start (){
//		    var vuforia = VuforiaARController.Instance;
//		    vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
//		    vuforia.RegisterOnPauseCallback(OnPaused);
//	}
//	  
//	private void OnVuforiaStarted(){
//		    CameraDevice.Instance.SetFocusMode(
//			        CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
//	}
//	  
//	private void OnPaused(bool paused){
//		if (!paused){ // resumed
//		        // Set again autofocus mode when app is resumed
//		        CameraDevice.Instance.SetFocusMode(
//			            CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
//		    }
//	}
}
