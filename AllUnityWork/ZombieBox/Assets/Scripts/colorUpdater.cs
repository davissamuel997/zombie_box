using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class colorUpdater : MonoBehaviour
{

	public Slider rSlider;
	public Slider gSlider;
	public Slider bSlider;

	public InputField rField;
	public InputField gField;
	public InputField bField;

	public float r;
	public float g;
	public float b;

	public Renderer baseRenderer;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void updateBaseColor()
	{
		baseRenderer.materials[1].color = new Color(r, g, b, 1);
	}

	public void updateRedFromSlider()
	{
		r = rSlider.value;
		rField.text = "" + floatToInt(r);
		updateBaseColor();
	}

	public void updateGreenFromSlider()
	{
		g = gSlider.value;
		gField.text = "" + floatToInt(g);
		updateBaseColor();
	}

	public void updateBlueFromSlider()
	{
		b = bSlider.value;
		bField.text = "" + floatToInt(b);
		updateBaseColor();
	}

	public void updateRedFromField()
	{
		int fieldIn = int.Parse(rField.text);

		if (fieldIn == null  || fieldIn < 0)
		{
			r = 0;
			rSlider.value = 0;
		}
		else if (fieldIn > 255)
		{
			r = 255;
			rSlider.value = 255;
		}
		else
		{
			r = intToFloat(fieldIn);
			rSlider.value = r;
		}
	}

	public void updateGreenFromField()
	{
		int fieldIn = int.Parse(gField.text);

		if (fieldIn == null || fieldIn < 0)
		{
			g = 0;
			gSlider.value = 0;
		}
		else if (fieldIn > 255)
		{
			g = 255;
			gSlider.value = 255;
		}
		else
		{
			g = intToFloat(fieldIn);
			gSlider.value = g;
		}
	}

	public void updateBlueFromField()
	{
		int fieldIn = int.Parse(bField.text);

		if (fieldIn == null || fieldIn < 0)
		{
			b = 0;
			bSlider.value = 0;
		}
		else if (fieldIn > 255)
		{
			b = 255;
			bSlider.value = 255;
		}
		else
		{
			b = intToFloat(fieldIn);
			bSlider.value = b;
		}
	}

	int floatToInt(float f)
	{
		return (int)Mathf.Floor((f == 1.0f ? 255.0f : f * 256.0f));
	}

	float intToFloat(int i)
	{
		return i / 255.0f;
	}
}
