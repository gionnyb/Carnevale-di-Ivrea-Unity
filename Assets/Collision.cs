using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	public GameObject ExplotionParticles;
	public GameObject GameControlObject;
	private GameControl GameControlScript;
	public AudioClip ExplotionAudio;
	public int goal = 0;
	void Awake ()
	{

	}
	
	// Use this for initialization
	void Start () {
		GameControlScript = GameControlObject.GetComponent<GameControl>();
	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		GameControlScript.AddScore(goal);

		Debug.Log ("OnTriggerEnter");
		audio.PlayOneShot(ExplotionAudio);
		Instantiate(ExplotionParticles, transform.position, transform.rotation);
		ExplotionParticles.particleEmitter.emit = true;
		renderer.enabled = false;

		Destroy(other.gameObject);
		Destroy(gameObject);
	
	}
}
