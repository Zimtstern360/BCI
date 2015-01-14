//#pragma strict
//@script ExecuteInEditMode
var TextureMode:boolean = false;
var txrHeartbeat:Texture2D;
var txrGradient:Texture2D;
var frequency:float = 1.0;
var amplitude:float = 1.0;
var viewport:Rect = new Rect(100,100,240,50);
var color:Color = new Color(0,0,0,0);
private var txrBackground:Texture2D;
private var txrRender: RenderTexture;
private static var lineMaterial : Material;
private var txrTarget:Texture2D;

function Awake() {
	CreateLineMaterial();
	txrBackground = new Texture2D(1,1);
	txrBackground.SetPixel(0,0,Color.white);
	txrBackground.Apply();
	txrTarget = new Texture2D(240,50);
}

function Start() {
	txrRender = new RenderTexture(viewport.width, viewport.height, 16, RenderTextureFormat.ARGBFloat	);
	RenderTexture.active = txrRender;
	RenderLine();
	txrTarget.ReadPixels(viewport, 0, 0, true);
	RenderTexture.active = null;
}

function OnGUI() {
	frequency = Mathf.Clamp(frequency, 1, 5);
	GUI.BeginGroup(viewport);
	GUI.color = color;
	GUI.DrawTexture(Rect(0, 0, viewport.width, viewport.height), txrBackground, ScaleMode.StretchToFill);
	var w:float = txrHeartbeat.width * 1/frequency;
	var h:float = txrHeartbeat.height * amplitude;
	GUI.color = Color(1,1,1,1);
	if (TextureMode)
		GUI.DrawTexture(Rect(0, (viewport.height - h)/2, w, h), txrHeartbeat, ScaleMode.StretchToFill);
	else
		RenderHeartbeat();
	GUI.color = color;
	
	var gradientOffset:float = viewport.width * (Time.realtimeSinceStartup % 1);
	var gradientRect:Rect = new Rect(gradientOffset, 0, viewport.width, viewport.height);
	GUI.DrawTexture(gradientRect, txrGradient, ScaleMode.StretchToFill);
	gradientRect.x -= viewport.width;
	GUI.DrawTexture(gradientRect, txrGradient, ScaleMode.StretchToFill);
	
	GUI.EndGroup();
}

function RenderHeartbeat() {
	GL.PushMatrix();
	lineMaterial.SetPass(0);
	//GL.Clear( false, true, Color.green);
	GL.Viewport(Rect(viewport.x,Screen.height-viewport.height-viewport.y, viewport.width, viewport.height));
	GL.LoadPixelMatrix(0,viewport.width, viewport.height,0);
	GL.Begin(GL.LINES);
	GL.Color(Color.white);
	//
	var yBase:float = 0.7 * viewport.height;
	var v:Vector3 = new Vector3(0,yBase,0);
	GL.Vertex(v);
	// heartbeat resolution: 5ms, 1 second drawn
	for (var x:float = 0; x < 1; x+=0.005) {
		var beat:float = 1 + 100*((x+0.9) % (1/frequency))	;
		var damp:float = 1/(beat);
		var y:float = damp * amplitude * Mathf.Sin(beat);
		v.y = yBase - y * viewport.height/2;
		v.x = x * viewport.width;
		GL.Vertex(v);
		GL.Vertex(v);
	}
	//
	GL.End();
	GL.Viewport(Rect(0,0,Screen.width,Screen.height));
	GL.PopMatrix();
}

function RenderLine() {
	GL.PushMatrix();
	lineMaterial.SetPass(0);
	GL.Viewport(Rect(0,Screen.height-viewport.height, viewport.width, viewport.height));
	GL.LoadPixelMatrix(0,viewport.width, viewport.height,0);
	GL.Clear( false, true, Color(0,1,1,1));
	GL.Begin(GL.LINES);
	GL.Color(Color.yellow);
	GL.Vertex(Vector3(0,0,0));
	GL.Vertex(Vector3(viewport.width, viewport.height, 0));
	GL.End();
	GL.PopMatrix();
}

static function CreateLineMaterial() {
	if( !lineMaterial ) {
		lineMaterial = new Material( "Shader \"Lines/Colored Blended\" {" +
			"SubShader { Pass { " +
			"    Blend SrcAlpha OneMinusSrcAlpha " +
			"    ZWrite Off Cull Off Fog { Mode Off } " +
			"    BindChannels {" +
			"      Bind \"vertex\", vertex Bind \"color\", color }" +
			"} } }" );
		lineMaterial.hideFlags = HideFlags.HideAndDontSave;
		lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
	}
}