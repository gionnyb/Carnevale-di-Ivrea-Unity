#pragma strict
import System;


var ShotJoystick : Joystick;

var ShotParticle : ParticleSystem;


var startPosition : GameObject;
var myTarget: Transform;  // drag the target here
var TargetImage: Transform;  // drag the target here
var shootAngle: float = 40;  // elevation angle
var theBullet: GameObject;  // drag the cannonball prefab here

var colorStart : Color = Color.yellow;
var color0 : Color = Color.blue;
var color1 : Color = Color.green;
var color2 : Color = Color.red;


private var startTime = 0;
private var delta = 0;
private var Shot = false;

function OnEndGame()
{
	// Disable joystick when the game ends	
	ShotJoystick.Disable();	

	// Don't allow any more control changes when the game ends
	this.enabled = false;
}

function Update () {
	if (Input.GetKeyDown(KeyCode.Escape))
    	Application.Quit();
	
	if ( ShotJoystick.tapCount == 1 || Input.GetMouseButtonDown(1) ){
		
		if(!Shot){
			startTime = Time.time%60;
			
			delta=0;
			Shot = true;
			
		}
		else{
		
			delta = (Time.time%60) - startTime;
			
			myTarget.transform.Translate(Vector3.forward * 0.9);
			TargetImage.transform.Translate(Vector3.back * 0.4);
			//Gui.guiText.text = "myTarget.position: "+myTarget.position;
			
			ShotParticle.startColor = colorStart;
			ShotParticle.emissionRate = 5*delta;
			
			if(delta > 1 && delta <= 2 ){
				ShotParticle.startColor = color0;
			}
			else if(delta > 2 && delta <= 5 ){
				ShotParticle.startColor = color1;
			}
			else if(delta > 5 && delta <= 10 ){
				ShotParticle.startColor = color2;		
			}
			else if(delta > 10){
				Shot = false;
			}
		}
	}
		
	if ( ShotJoystick.tapCount == 0){
	
		if(Shot){
			
			var ball: GameObject = Instantiate(theBullet, startPosition.transform.position, startPosition.transform.rotation);
	        ball.rigidbody.velocity = BallisticVel(myTarget, shootAngle);
	        Destroy(ball, 20);
	        myTarget.transform.position = new Vector3( startPosition.transform.position.x, startPosition.transform.position.y, startPosition.transform.position.z);
			TargetImage.transform.position = new Vector3( startPosition.transform.position.x, startPosition.transform.position.y, startPosition.transform.position.z);
	        Shot = false;
		}
		ShotParticle.emissionRate = 0;
	}
}
function BallisticVel(target: Transform, angle: float): Vector3 {
    var dir = target.position - transform.position;  // get target direction
    var h = dir.y;  // get height difference
    dir.y = 0;  // retain only the horizontal direction
    var dist = dir.magnitude ;  // get horizontal distance
    var a = angle * Mathf.Deg2Rad;  // convert angle to radians
    dir.y = dist * Mathf.Tan(a);  // set dir to the elevation angle
    dist += h / Mathf.Tan(a);  // correct for small height differences
    // calculate the velocity magnitude
    var vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
    return vel * dir.normalized;
}
