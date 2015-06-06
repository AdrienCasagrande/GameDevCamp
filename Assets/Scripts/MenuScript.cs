using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {


	public Font CustomFont;
	GUIStyle customStyle;
	GUIStyle TitleStyle;
	public Texture2D Button;

	void OnGUI()
	{
		const int Width  = 300;
		const int Height = 60;

		GUI.backgroundColor = Color.clear;
		if (customStyle == null) {
			customStyle = new GUIStyle(GUI.skin.button);
			customStyle.font = CustomFont;
			customStyle.fontSize = 28;
			customStyle.normal.textColor = Color.gray;
		}

		if (TitleStyle == null) {
			TitleStyle = new GUIStyle(GUI.skin.button);
			TitleStyle.font = CustomFont;
			TitleStyle.fontSize = 25;
			TitleStyle.normal.textColor = Color.white;
		}

		Rect ExitButtonRect = new Rect (
			Screen.width / 2 - (Width / 2),
		    (2 * Screen.height / 3) - (Height / 2),
		    Width,
		    Height);

		Rect PlayButtonRect = new Rect (
			Screen.width / 2 - (Width / 2),
			(2 * Screen.height / 5) - (Height / 4),
			Width,
			Height
		);

		Rect TitleLAbel = new Rect (
			Screen.width / 2 - (Width / 2),
			(2 * Screen.height / 11) - (Height / 10),
			Width,
			Height
		); 

		GUI.Label (TitleLAbel, "Garbage Collector", TitleStyle);


		if (GUI.Button (PlayButtonRect, "Play", customStyle)) {
			//FadeLevel.LoadLevel("FirstScene" , 1,1,Color.black);
			//Application.LoadLevel ("FirstScene");

		}

		if (GUI.Button (ExitButtonRect, "Exit", customStyle)) {
			Application.Quit();
		}
	}
}
