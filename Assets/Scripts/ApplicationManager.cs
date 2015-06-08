using UnityEngine;
using System.Collections;

public class ApplicationManager : MonoBehaviour {
	

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void Play()
	{
		//Application.LoadLevel ("FirstScene");
		FadeLevel.instance.LoadLevel ("FirstScene" , 1,1,Color.black);
	}

	public void MainMenu()
	{
		FadeLevel.instance.LoadLevel ("Menu 3D", 1, 1, Color.black);
	}

	public void Pause()
	{
		FadeLevel.instance.LoadLevel ("PauseMenu", 1, 1, Color.black);
	}
}
