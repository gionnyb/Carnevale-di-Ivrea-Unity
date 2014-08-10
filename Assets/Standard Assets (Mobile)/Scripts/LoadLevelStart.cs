using UnityEngine;
using System.Collections;

public class LoadLevelStart : MonoBehaviour
{
	void OnTriggerEnter(Collider other){
		AutoFade.LoadLevel("Game" ,2,1,Color.black);
	}
}