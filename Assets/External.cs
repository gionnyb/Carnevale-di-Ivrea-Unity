using UnityEngine;
using System.Collections;

public class External : MonoBehaviour
{
	
		void Awake ()
		{
				AndroidJNI.AttachCurrentThread ();
		}
	
		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	
	
	#if UNITY_ANDROID
	public static void back() {
		//Debug.Log("Unity Back calll Android");
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
				
				obj_Activity.CallStatic("back", obj_Activity);
				Debug.Log("Called back from Unity");
			}
		}
	}
	
	public static void next() {
		//Debug.Log("Unity Next calll Android");
		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
				//AndroidJavaClass cls_MainActivity = new AndroidJavaClass("com.example.unityandroid");
				obj_Activity.CallStatic("next", obj_Activity);
				
				Debug.Log("Called next from Unity");
			}
		}
	}
	#elif UNITY_EDITOR
	public static void back() {
		Debug.Log("Unity Back calll Android");
	}
	
	public static void next() {
		Debug.Log("Unity Next calll Android");
	}
	#endif
}
