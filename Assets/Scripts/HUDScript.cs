using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	
	GUIStyle    CustomFontStyle;
	public Font CustomStyleFont;

	//Texture2D Image;
	public GUIContent Bullet;
	public GUIContent Lazer;
	public GUIContent RedBullet;
	public GUIContent OverCheat;

	private HealthScript PlayerInfo;
	private CannonScript BulletInfo;
	const int Width  = 200;
	const int Height = 250;
	private bool ifCheated = false;

	const int pointWidth  = 120;
	const int pointHeight = 60;
	
	void Start () {
		PlayerInfo = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthScript>();
		BulletInfo = GameObject.FindGameObjectWithTag ("Cannon").GetComponent<CannonScript>();
	}

	Rect HudBarHp = new Rect (
		Screen.width / 12 - (Width / 12),
		(2 * Screen.height / 20) - (Height / 19),
		Width,
		Height
		);
	
	void Update() {
	}

	void OnGUI()
	{
		if (ifCheated) {
			GUI.backgroundColor = Color.red;
			GUI.Button (new Rect (Screen.width / 2, Screen.height - 56, 48, 48), OverCheat);
		}
		if (CustomFontStyle == null) {
			CustomFontStyle = new GUIStyle(GUI.skin.button);
			CustomFontStyle.font = CustomStyleFont;
			CustomFontStyle.fontSize = 38;
			CustomFontStyle.normal.textColor = Color.white;
		}
		if (BulletInfo.ammoSelect == 0) {
			GUI.backgroundColor = Color.white;
		} else {
			GUI.backgroundColor = Color.clear;
		}
		GUI.Button (new Rect (Screen.width / 3.3f, Screen.height - 56, 48, 48), Bullet);
		if (BulletInfo.ammoSelect == 1) {
			GUI.backgroundColor = Color.white;
		} else {
			GUI.backgroundColor = Color.clear;
		}
		GUI.Button (new Rect (Screen.width / 2.7f, Screen.height - 56, 48, 48), Lazer);

		//if (BulletInfo.ammoSelect == 2) {
		//	GUI.backgroundColor = Color.white;
		//} else {
		//	GUI.backgroundColor = Color.clear;
		//}
		//GUI.Button (new Rect (Screen.width / 2.3f, Screen.height - 56, 48, 48), RedBullet);

		GUI.backgroundColor = Color.green;
		GUI.HorizontalScrollbar (HudBarHp, 0, PlayerInfo.hp, 0, 10);
		GUI.backgroundColor = Color.clear;
		GUI.Label (new Rect (Screen.width / 2 - 100, 0, 200, 46), "0", CustomFontStyle);
	}
}
