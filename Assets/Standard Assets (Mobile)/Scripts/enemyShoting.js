#pragma strict


var startPosition : GameObject;
var myTarget: Transform;  // drag the target here
var shootAngle: float = 40;  // elevation angle
var theBullet: GameObject;  // drag the cannonball prefab here
var minTime: float = 5;
var maxTime: float = 15;
var raggio: float = 5;

var nextShotTime : float;


function Start(){
	if(Time.time >= nextShotTime){
		nextShotTime = Time.time + Random.Range(minTime, maxTime);
	}
}

function Update () {
	
	if(Time.time >= nextShotTime)
    {	
		var ball: GameObject = Instantiate(theBullet, startPosition.transform.position, Quaternion.identity);
		ball.rigidbody.velocity = BallisticVel(myTarget, shootAngle);
		Destroy(ball, 10);
		nextShotTime = Time.time + Random.Range(minTime, maxTime);
    }
}

function BallisticVel(target: Transform, angle: float): Vector3 {
	var VectorTarget = target.position;
	VectorTarget= new Vector3(VectorTarget.x+Random.Range(-raggio, raggio),VectorTarget.y+Random.Range(-raggio, raggio),VectorTarget.z+Random.Range(-raggio, raggio));
    
    var dir = VectorTarget - transform.position;  // get target direction
    var h = dir.y;  // get height difference
    dir.y = 0;  // retain only the horizontal direction
    var dist = dir.magnitude-1 ;  // get horizontal distance
    var a = angle * Mathf.Deg2Rad;  // convert angle to radians
    dir.y = dist * Mathf.Tan(a);  // set dir to the elevation angle
    dist += h / Mathf.Tan(a);  // correct for small height differences
    // calculate the velocity magnitude
    var vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
    return vel * dir.normalized;
}