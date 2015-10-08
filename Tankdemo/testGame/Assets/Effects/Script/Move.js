#pragma strict

function Start () {

}
@Range(0,100)
 public var speed:int = 25;
function Update () {
  if(Input.GetKey(KeyCode.A)){
      transform.Rotate(0,-speed*Time.deltaTime,0,Space.Self);
      }
  if(Input.GetKey(KeyCode.D)){
      transform.Rotate(0,speed*Time.deltaTime,0,Space.Self);
       
      }
  if(Input.GetKey(KeyCode.W)){
      transform.Rotate(-speed*Time.deltaTime,0,0,Space.Self);
      }
  if(Input.GetKey(KeyCode.S)){
      transform.Rotate(speed*Time.deltaTime,0,0,Space.Self);
      }
      
    
}