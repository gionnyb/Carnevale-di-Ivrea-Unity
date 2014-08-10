using UnityEngine;
using System.Collections;

public class LoadLevelGame : MonoBehaviour
{
	void OnTriggerEnter(Collider other){
		AutoFade.LoadLevel("Game" ,2,2,Color.black);
	}
}