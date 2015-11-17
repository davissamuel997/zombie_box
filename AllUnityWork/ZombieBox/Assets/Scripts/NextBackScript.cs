﻿using UnityEngine;
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
		back = GameObject.Find("Back");
		next = GameObject.Find("Next");
		back.SetActive(false);
		stats = GameObject.Find("StatsDisplay");
		stats.SetActive(false);

	}

	public void NextPressed () 
	{
		if(facing == 0)
		{
			back.SetActive(true);
			stats.SetActive(true);
		}
		if (facing == 1)
		{
			next.GetComponentInChildren<Text>().text = "Play";
			stats.SetActive(false);
		}
		if(facing == 2)
		{
			PlayerPrefs.SetString("charID", Regex.Replace(CharSelect.selected.name, "[^0-9]", ""));
			
			Application.LoadLevel ("base");              

		}
		rotateRight = true;
		facing++;
	}

	public void BackPressed ()
	{
		if(facing == 1)
		{
			back.SetActive(false);
		}
		if(facing == 2)
		{
			stats.SetActive(true);
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

		/*if (facing == 0)
		{

		}

		if (facing == 1)
		{

		}

		if (facing == 2)
		{

		}*/
	}
}