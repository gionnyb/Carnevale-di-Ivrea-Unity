using System;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class OSHookBridge
{
#if UNITY_IPHONE

#elif UNITY_ANDROID

	public static int ReturnNumTiri(){
		AndroidJavaClass ajc = new AndroidJavaClass("it.polito.applicazionimultimediali.carnevalediivrea.battle.MyBattleActivity");
		return ajc.CallStatic<int>("ReturnNumTiri");
	}
	public static void SendUnityMessage(string objectName, string methodName, string parameterText){
		AndroidJavaClass ajc = new AndroidJavaClass("com.gionnyb.oshook.Bridge");
		ajc.CallStatic("SendUnityMessage", objectName, methodName, parameterText);
	}

#endif
}
