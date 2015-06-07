using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	private HealthScript PlayerInfo;
	const int Width  = 120;
	const int Height = 60;

	void Start () {
		PlayerInfo = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthScript>();
	}

	Rect HudBarHp = new Rect (
		Screen.width / 2 - (Width / 2),
		(2 * Screen.height / 3) - (Height / 2),
		Width,
		Height);

	void OnGUI()
	{
		GUI.backgroundColor = Color.green;
		GUI.HorizontalScrollbar (HudBarHp, 0, PlayerInfo.hp, 0, 10);
	}
}

