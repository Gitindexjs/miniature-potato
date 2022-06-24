using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class NarrationController : MonoBehaviour
{
	public struct scriptConfig {
		public string m_text;
		public float m_speed;
		public scriptConfig(string text, float speed) {
			m_text = text;
			m_speed = speed;
		}
	}
	[SerializeField] Text narration_text;
	[SerializeField] VideoPlayer videoPlayer;
	public IEnumerator startNarration(Dictionary<int, scriptConfig> text) {
		// 1 50 98 ...
		List<int> frames = new List<int>(text.Keys);
		// goes through every 1 50 98 
		for(int i = 0; i < frames.Count; i++) {
			narration_text.text = "";
			// 1
			if(videoPlayer.frame < frames[i]) {
				// words from narration
				string[] splitText = text[frames[i]].m_text.Split(' ');
				// goes through every word
				for(int j = 0; j < splitText.Length; j++) {
					string word = splitText[j];
					narration_text.text += word + " ";
					yield return new WaitForSeconds(text[frames[i]].m_speed);
				}
			}
		}
	}
}
