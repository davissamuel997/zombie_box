using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;
using System;
/*
Severity	Code	Description	Project	File	Line
Warning		The primary reference "Npgsql, Version=2.2.5.0, Culture=neutral, 
PublicKeyToken=5d8b90d52f46fda7, processorArchitecture=MSIL" could not be resolved because it has an 
indirect dependency on the framework assembly "System.DirectoryServices, Version=2.0.0.0, Culture=neutral, 
PublicKeyToken=b03f5f7f11d50a3a" which could not be resolved in the currently targeted framework. ".NETFramework,Version=v3.5,
Profile=Unity Subset v3.5". To resolve this problem, either remove the reference "Npgsql, Version=2.2.5.0, Culture=neutral, 
PublicKeyToken=5d8b90d52f46fda7, processorArchitecture=MSIL" or retarget your application to a framework version which contains "
System.DirectoryServices, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a".	ZombieBox.CSharp		


using Npgsql;
*/
    public class LoginMenu : MonoBehaviour {

	public static GameObject selected;
	public CanvasGroup canvasGroup;
	public bool init_flag = true;
	private Button loginButton;
	private InputField usernameInput;
	private InputField passwordInput;
	private WWW webCall;
    /*public System.Data.DataSet data = new System.Data.DataSet();
    */
    public void getData()
    {
        string connString = "Server=localhost;Port=5432;User Id=Eric;Password=;Database=railsdb_development";
        /*
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
                    Debug.Log(row[column]);
                }
            }
        }*/
    }
	void Start()
	{

			string connString = "Server=localhost;Port=5432;User Id=Eric;Password=;Database=railsdb_development";
		/*
		NpgsqlConnection conn = new NpgsqlConnection (connString);
		conn.Open ();
		string sql = "SELECT * from posts";
		NpgsqlDataAdapter da = new NpgsqlDataAdapter (sql, conn);
		System.Collections.CollectionBase test;
	*/

        
		loginButton = GameObject.FindObjectOfType<Button>();
		usernameInput = GameObject.FindObjectsOfType<InputField>()[0];
		passwordInput = GameObject.FindObjectsOfType<InputField>()[1];
		Debug.Log ("starting...");
		loginButton.onClick.AddListener (delegate {
			login();
		});

		init_flag = false;
        getData();
        
	}

	void Update () 
	{

		//loginButton = GameObject.FindObjectOfType<Button> ();


		

	}	 
		
	public void login()
	{
		Debug.Log ("loging in");
		Debug.Log (usernameInput.text);
		Debug.Log (passwordInput.text);


	}
}
