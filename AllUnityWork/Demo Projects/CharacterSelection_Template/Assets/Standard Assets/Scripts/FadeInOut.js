// FadeInOut
// This script just fades a scene in from black (or any color you choose). It uses a 2d texture, thats a small black 32x32 texture. It stretches the small texture
//to fill the entire screen ratio and then adjust it's material alpha for the fade. You can plug in any color texture and fade in from white, etc.
//
//--------------------------------------------------------------------
//                        Public parameters
//--------------------------------------------------------------------

public var fadeOutTexture : Texture2D;
public var fadeSpeed = 0.3;

var drawDepth = -1000;

//--------------------------------------------------------------------
//                       Private variables
//--------------------------------------------------------------------

private var alpha = 1.0; 

private var fadeDir = -1;

//--------------------------------------------------------------------
//                       Runtime functions
//--------------------------------------------------------------------

//--------------------------------------------------------------------

function OnGUI(){
    
    alpha += fadeDir * fadeSpeed * Time.deltaTime;  
    alpha = Mathf.Clamp01(alpha);   
    
    GUI.color.a = alpha;
    
    GUI.depth = drawDepth;
    
    GUI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
}

//--------------------------------------------------------------------

function fadeIn(){
    fadeDir = -1;   
}

//--------------------------------------------------------------------

function fadeOut(){
    fadeDir = 1;    
}

function Start(){
    alpha=1;
    fadeIn();
}