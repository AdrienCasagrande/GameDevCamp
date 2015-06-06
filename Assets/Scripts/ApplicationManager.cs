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
		FadeLevel.LoadLevel("FirstScene" , 1,1,Color.black);
	}

	public void Main()
	{
		FadeLevel.LoadLevel ("Menu 3D", 1, 1, Color.black);
	}

	public void Over()
	{
		FadeLevel.LoadLevel ("GameOver", 1, 1, Color.black);
	}
}
