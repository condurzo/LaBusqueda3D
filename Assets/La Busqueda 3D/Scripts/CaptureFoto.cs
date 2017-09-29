using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CaptureFoto : MonoBehaviour {

	Camera mainCamera;
	RenderTexture renderTex;
	Texture2D screenshot;
	Texture2D LoadScreenshot;
	int width = Screen.width;   // for Taking Picture
	int height = Screen.height; // for Taking Picture
	string fileName;
	string screenShotName = "PictureShare.png";
	public GameObject PictureImage;
	public GameObject VolverJugarBtn;
	public GameObject MenuBtn;
	public GameObject BannerFinal;


	public GameObject EmpezarBtn;
	public GameObject CamaraBtn;

	public GameObject FondoPrevio;
	public GameObject BannerInicio;

	public void Snapshot ()
	{
		ManagerGame.comenzoJuego = false;
		ManagerGame.comenzarTiempo = false;
		StartCoroutine (CaptureScreen ());
	}

	public IEnumerator CaptureScreen ()
	{
		yield return null; // Wait till the last possible moment before screen rendering to hide the UI

		GameObject.Find ("Canvas").GetComponent<Canvas> ().enabled = false;
		yield return new WaitForEndOfFrame (); // Wait for screen rendering to complete

			mainCamera = Camera.main.GetComponent<Camera> (); // for Taking Picture
			renderTex = new RenderTexture (width, height, 24);
			mainCamera.targetTexture = renderTex;
			RenderTexture.active = renderTex;
			mainCamera.Render ();
			screenshot = new Texture2D (width, height, TextureFormat.RGB24, false);
			screenshot.ReadPixels (new Rect (0, 0, width, height), 0, 0);
			screenshot.Apply (); //false
			RenderTexture.active = null;
			mainCamera.targetTexture = null;


		// on Win7 - C:/Users/Username/AppData/LocalLow/CompanyName/GameName
		// on Android - /Data/Data/com.companyname.gamename/Files
		File.WriteAllBytes (Application.persistentDataPath + "/" + screenShotName, screenshot.EncodeToPNG ());  

		// on Win7 - it's in project files (Asset folder)
		//File.WriteAllBytes (Application.dataPath + "/" + screenShotName, screenshot.EncodeToPNG ());  
		//File.WriteAllBytes ("picture1.png", screenshot.EncodeToPNG ());
		//File.WriteAllBytes (Application.dataPath + "/../../picture3.png", screenshot.EncodeToPNG ());
		//Application.CaptureScreenshot ("picture2.png");
		GameObject.Find ("Canvas").GetComponent<Canvas> ().enabled = true; // Show UI after we're done
		LoadImage();

	}


	public void LoadImage ()
	{
		string path = Application.persistentDataPath + "/" + screenShotName;
		byte[] bytes;
		bytes = System.IO.File.ReadAllBytes(path);
		LoadScreenshot = new Texture2D(4, 4);
		LoadScreenshot.LoadImage(bytes);
		Sprite sprite = Sprite.Create(screenshot, new Rect(0, 0, width, height), new Vector2(0.5f, 0.0f), 1.0f);

		GameObject.Find("Picture").GetComponent<Image>().sprite = sprite;
		PictureImage.GetComponent<CanvasGroup> ().alpha = 1;
		PictureImage.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		PictureImage.GetComponent<CanvasGroup> ().interactable = true;
		VolverJugarBtn.SetActive (true);
		MenuBtn.SetActive (true);
		BannerFinal.SetActive (true);
		Debug.Log("LOAD IMAGE");
	}

	public void PlayAgain(){
		FondoPrevio.SetActive (true);
		BannerInicio.SetActive (false);
		PictureImage.GetComponent<CanvasGroup> ().alpha = 0;
		PictureImage.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		PictureImage.GetComponent<CanvasGroup> ().interactable = false;
		VolverJugarBtn.SetActive (false);
		MenuBtn.SetActive (false);
		BannerFinal.SetActive (false);
	
		GameObject.Find ("Canvas").GetComponent<Canvas> ().enabled = true;
		EmpezarBtn.SetActive(true);
		CamaraBtn.SetActive(false);
	}



//	public void close ()
//	{
//		#if UNITY_EDITOR
//		UnityEditor.EditorApplication.isPlaying = false;
//		#else
//		Application.Quit();
//		#endif
//	}
}
