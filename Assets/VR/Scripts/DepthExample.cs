using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DepthExample : MonoBehaviour
{
	[SerializeField]
	Color Color = Color.white;

	[SerializeField]
	Material DepthTestOn;

	[SerializeField]
	Material DepthTestOff;

    public void ToggleDepthTest(bool on)
	{
		Renderer r = GetComponentInChildren<Renderer>();
		if(!r) return;

		//set the chosen material
		r.sharedMaterial = on ? DepthTestOn : DepthTestOff;

		//also set color per object
		SetColor();
	}

	void SetColor()
	{
		Renderer r = GetComponentInChildren<Renderer>();
		if(!r) return;

		MaterialPropertyBlock mpb = new MaterialPropertyBlock();
		mpb.SetColor("_BaseColor", Color);
		r.SetPropertyBlock(mpb);
	}

	void OnValidate()
	{
		SetColor();
	}
}
