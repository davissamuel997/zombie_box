using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class NextBackScript : MonoBehaviour {

	public Camera mainCamera;
	public CanvasGroup canvasGroup;

	public float speed = 55.0f;
	private float rotation = 0.0f;
	private Quaternion qTo = Quaternion.identity;

	private bool rotateRight = false;
	private bool rotateLeft = false;
	private int facing = 0;

	private GameObject back;
	private GameObject next;
	private GameObject stats;
	
	void Start()
	{
		back = GameObject.Find("BackBtn");
		next = GameObject.Find("NextBtn");
		back.SetActive(false);
	}

	public void NextPressed () 
	{
		if(facing == 0)
		{
			back.SetActive(true);
		}
		if (facing == 1)
		{

		}
		if (facing == 2)
		{
			next.GetComponentInChildren<Text>().text = "Play";
		}
		if(facing == 3)
		{
			PlayerPrefs.SetString("charID", Regex.Replace(CharSelect.selected.name, "[^0-9]", ""));

			Application.LoadLevel("base");
		}
		else
		{
			rotateRight = true;
			facing++;
		}
	}

	public void BackPressed ()
	{
		if(facing == 1)
		{
			back.SetActive(false);
		}
		if(facing == 3)
		{
			next.GetComponentInChildren<Text>().text = "Next";
		}
		rotateLeft = true;
		facing--;
	}

	void Update ()
	{
		if (rotateRight)	
		{
			rotation += 90.0f;
			qTo = Quaternion.Euler(0.0f, rotation, 0.0f);
			rotateRight = false;
		}
		if (rotateLeft)
		{
			rotation -= 90.0f;
			qTo = Quaternion.Euler(0.0f, rotation, 0.0f);
			rotateLeft = false;
		}

		mainCamera.transform.rotation = Quaternion.RotateTowards(mainCamera.transform.rotation, qTo, speed * Time.deltaTime);
	}
}
