using UnityEngine;
using System.Collections;

public class FadeLevel : MonoBehaviour 
{
		public static FadeLevel instance = null;
		private Material m_Material = null;
		private string m_LevelName = "";
		private int m_LevelIndex = 0;
		private bool m_Fading = false;

		public static bool Fading
		{
			get { return instance.m_Fading; }
		}
		
		private void Awake()
		{
			DontDestroyOnLoad(this);
			if (instance == null) {
				instance = this;
			} else {
				Destroy (this.gameObject);
			}
			m_Material = new Material("Shader \"Plane/No zTest\" { SubShader { Pass { Blend SrcAlpha OneMinusSrcAlpha ZWrite Off Cull Off Fog { Mode Off } BindChannels { Bind \"Color\",color } } } }");
		}
		
		private void DrawQuad(Color aColor,float aAlpha)
		{
			aColor.a = aAlpha;
			m_Material.SetPass(0);
			GL.PushMatrix();
			GL.LoadOrtho();
			GL.Begin(GL.QUADS);
			GL.Color(aColor);
			GL.Vertex3(0, 0, -1);
			GL.Vertex3(0, 1, -1);
			GL.Vertex3(1, 1, -1);
			GL.Vertex3(1, 0, -1);
			GL.End();
			GL.PopMatrix();
		}
		
		private IEnumerator Fade(float aFadeOutTime, float aFadeInTime, Color aColor)
		{
			float t = 0.0f;
			while (t<1.0f)
			{
				yield return new WaitForEndOfFrame();
				t = Mathf.Clamp01(t + Time.deltaTime / aFadeOutTime);
				DrawQuad(aColor,t);
			}
			if (m_LevelName != "")
				Application.LoadLevel(m_LevelName);
			else
				Application.LoadLevel(m_LevelIndex);
			while (t>0.0f)
			{
				yield return new WaitForEndOfFrame();
				t = Mathf.Clamp01(t - Time.deltaTime / aFadeInTime);
				DrawQuad(aColor,t);
			}
			m_Fading = false;
		}
		private void StartFade(float aFadeOutTime, float aFadeInTime, Color aColor)
		{
			m_Fading = true;
			StartCoroutine(Fade(aFadeOutTime, aFadeInTime, aColor));
		}
		
		public void LoadLevel(string aLevelName,float aFadeOutTime, float aFadeInTime, Color aColor)
		{
			if (Fading) return;
			instance.m_LevelName = aLevelName;
			instance.StartFade(aFadeOutTime, aFadeInTime, aColor);
		}
		public void LoadLevel(int aLevelIndex,float aFadeOutTime, float aFadeInTime, Color aColor)
		{
			if (Fading) return;
			instance.m_LevelName = "";
			instance.m_LevelIndex = aLevelIndex;
			instance.StartFade(aFadeOutTime, aFadeInTime, aColor);
		}
	}
