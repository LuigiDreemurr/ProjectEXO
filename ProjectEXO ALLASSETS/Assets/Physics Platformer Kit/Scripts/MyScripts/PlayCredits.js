var movTexture :MovieTexture;
function Start(){
	GetComponent.<Renderer>().material.mainTexture.Play();
}

function Update(){
	if(movTexture.isPlaying == false)
{
	//load level
	Application.LoadLevel(0);
}
}
