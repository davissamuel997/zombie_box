using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;
using System;

using Npgsql;

public class LoginMenu : MonoBehaviour
{

	public static GameObject selected;
	public CanvasGroup canvasGroup;
	public bool init_flag = true;
	private Button loginButton;
	private InputField usernameInput;
	private InputField passwordInput;
	private WWW webCall;
	public System.Data.DataSet data = new System.Data.DataSet();

	public void getData()
	{
		string connString = "Server=localhost;Port=5432;User Id=Eric;Password=;Database=railsdb_development";

		NpgsqlConnection conn = new NpgsqlConnection(connString);
		conn.Open();
		string sql = "SELECT * from posts";
		NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

		da.Fill(data);
		// For each table in the DataSet, print the row values. 
		foreach (System.Data.DataTable table in data.Tables)
		{
			foreach (System.Data.DataRow row in table.Rows)
			{
				foreach (System.Data.DataColumn column in table.Columns)
				{

					string temp = row[column].ToString();
					// Debug.Log(temp);

					if (temp.Equals(usernameInput.text))
					{
						Debug.Log("User Name recognized");
					}
				}
			}
		}
	}
	void Start()
	{

		string connString = "Server=ec2-50-19-208-138.compute-1.amazonaws.com;Port=5432;User Id=utrrhvfbgrydtz;Password=fIzDft9cKGp4LMrc6tIlvA63WP;Database=d85j68vua3mpp0";

		NpgsqlConnection conn = new NpgsqlConnection(connString);
		conn.Open();
		string sql = "SELECT * from posts";
		NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
		System.Collections.CollectionBase test;



		loginButton = GameObject.FindObjectOfType<Button>();
		usernameInput = GameObject.FindObjectsOfType<InputField>()[0];
		passwordInput = GameObject.FindObjectsOfType<InputField>()[1];
		Debug.Log("starting...");
		loginButton.onClick.AddListener(delegate
		{
			login();
		});

		init_flag = false;

	}

	void Update()
	{

		//loginButton = GameObject.FindObjectOfType<Button> ();




	}

	public void login()
	{
		Debug.Log("loging in");
		getData();
		Debug.Log(usernameInput.text);
		Debug.Log(passwordInput.text);


	}
}
