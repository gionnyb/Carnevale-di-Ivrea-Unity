using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour
{
	public static GameControl control;
	public Material ominoMarerial;
	public Material carroMarerial;
	public int score;
	public string piazza;
	public string team;
	public string opposingteam;

	public int time;
	public GUIText Guitimer;
	public GUIText Guiscore;

	IEnumerator countdown()
	{
		while (time > 0)
		{
			yield return new WaitForSeconds(1);
			float minutes = Mathf.Floor(time / 60);
			float seconds = time%60;
			Guitimer.text = minutes.ToString()+ " : " + seconds.ToString();
			time -= 1;
			if(time < 10)
			{
				if(time%2==0) 
				{
					Guitimer.color = Color.red;
				}
				else
				{
					Guitimer.color = Color.black;
				}
			}
		}
		
		Guitimer.text = "Game finish!";
	}

	// Use this for initialization+
	void Start(){
		Load ();
		score = 0;

	}
	
	void Awake ()
	{
		if (control == null) {
				DontDestroyOnLoad (gameObject);
				control = this;
		} else if (control != this) {
				Destroy (gameObject);
		}
		StartCoroutine (countdown());

	}
	void OnGUI()
	{
		Guiscore.text = "score: "+score;
		if(GUI.Button(new Rect( 20,20,100,30), "Back")){
			External.back();
			
		}
		if(GUI.Button(new Rect( 200,20,100,30), "Next")){
			External.next();
		}

	}
	
	public void Save()
	{
		PlayerPrefs.SetInt ("Battle_Score", score);
	}

	public void Load()
	{
		piazza = PlayerPrefs.GetString("Battle_Piazza");
		team = PlayerPrefs.GetString("Battle_Team");
		opposingteam = PlayerPrefs.GetString("Battle_OpposingTeam");
		Setscene ();
	}
	public void Setscene()
	{
		//Instantiate place 
		Debug.Log ("Place: "+piazza);

		GameObject Piazza = Instantiate(Resources.Load(piazza)) as GameObject; 
		//Instantiate carri

		//set texture opposingteam
		Debug.Log ("Opposingteam: "+opposingteam);
		Texture2D texomini = Resources.Load("Textures/omini/"+opposingteam) as Texture2D;
		ominoMarerial.SetTexture("_MainTex",texomini);
		//set texture carri
		int rndCarro = Random.Range (1, 6);
		Texture2D texcarri = Resources.Load("Textures/Carro/carro"+rndCarro) as Texture2D;
		carroMarerial.SetTexture("_MainTex",texcarri);
	}

	public void AddScore(int goal)
	{
		score = score + goal;
		Guiscore.text = "score: "+score;
		Save ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Save ();
			//Debug.Log("Unity Next calll Android");
			using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
					//AndroidJavaClass cls_MainActivity = new AndroidJavaClass("com.example.unityandroid");
					obj_Activity.CallStatic("ScoreUpdateActivity", obj_Activity);
					
					Debug.Log("Called ScoreUpdateActivity from Unity");
				}
			}
		
			//Application.Quit();
		}
	}
}
