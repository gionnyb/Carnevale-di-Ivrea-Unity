using System;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class PluginController : MonoBehaviour {

	private string buttonText = "Send Message";

	// Use this for initialization
	void Start () {
		#if UNITY_IPHONE


		#elif UNITY_ANDROID

			Debug.Log("Numero Tiri = "+ OSHookBridge.ReturnNumTiri());

		#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetButtonText(string newText){
		Debug.Log ("Button Text = " + newText);
		buttonText = newText;
	}

	void OnGUI(){
		if (GUI.Button (new Rect (10, 10, 100, 50), buttonText)){
			#if UNITY_IPHONE
			
			
			#elif UNITY_ANDROID

			OSHookBridge.SendUnityMessage(this.name, "SetButtonText", "Ottimo");
			
			#endif			
		}
	}
}
