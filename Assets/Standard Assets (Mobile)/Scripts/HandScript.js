var OrangeSpawn : Transform;
var Orange : GameObject;

function Start () {

}

function Update () {
	if(Input.GetButtonDown("Fire1")){
		Instantiate(Orange , OrangeSpawn.transform.position, OrangeSpawn.transform.rotation);
	}

}