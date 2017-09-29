using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectResolutionGame : MonoBehaviour {

	public GameObject NormalGO;
	public GameObject ipadGO;
	public GameObject ManagerNormalGO;
	public GameObject ManageripadGO;

	void Awake(){
		if ((Screen.width == 1536) && (Screen.height == 2048) || (Screen.width == 2048) && (Screen.height == 2732) || (Screen.width == 768) && (Screen.height == 1024) || (Screen.width == 1024) && (Screen.height == 1366)) {
			Debug.Log ("ES IPAD");
			NormalGO.SetActive(false);
			ipadGO.SetActive(true);
			ManagerNormalGO.SetActive(false);
			ManageripadGO.SetActive(true);

		} else {
			Debug.Log ("no es iPad");
			NormalGO.SetActive(true);
			ipadGO.SetActive(false);
			ManagerNormalGO.SetActive(true);
			ManageripadGO.SetActive(false);

		}
	}


}
