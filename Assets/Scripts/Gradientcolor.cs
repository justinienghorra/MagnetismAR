using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gradientcolor : MonoBehaviour {

	public Color startColor;
	public Color endColor;
	
	// Use this for initialization
	void Start () {
		var mesh = GetComponent<MeshFilter>().mesh;
		var uv = mesh.uv;
		var colors = new Color[uv.Length];

		// Instead if vertex.y we use uv.x
		for (var i = 0; i < uv.Length;i++)
			colors[i] = Color.Lerp(Color.white, Color.white, uv[i].x); 

		mesh.colors = colors;	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
