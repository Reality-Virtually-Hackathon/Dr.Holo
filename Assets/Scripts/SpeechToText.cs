using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechToText : MonoBehaviour {
	//Unity's Speech to Text Implementation
	[SerializeField]
	private Text hypothesis;

	[SerializeField]
	private Text recognitions;

	private DictationRecognizer m_DictationRecognize();

	void Start () {
	//	dictationRecognizer = new DictationRecognizer ();
	//	dictationRecognizer.DictationResult += (text, ConfidenceLevel);
	//	dictationRecognizer.Start();
	}
}
