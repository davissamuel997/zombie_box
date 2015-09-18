using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;
//using Npgsql

public class LoginMenu : MonoBehaviour {

	public static GameObject selected;
	public CanvasGroup canvasGroup;
	public bool init_flag = true;
	private Button loginButton;
	private InputField usernameInput;
	private InputField passwordInput;
	private WWW webCall;
	//public Button loginButton;
	///works with visual studio compiler with System.Data, but will not work with Unity Mono
/*	void Start()
	{


	}*/
	IEnumerator Start()
	{

		/*	string connString = "Server=localhost;Port=5432;User Id=Eric;Password=;Database=railsdb_development";
		
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
		string input = "GET /Posts";
		Dictionary<string,string> headers = new Dictionary<string,string> ();
		byte[] body = Encoding.UTF8.GetBytes (input);
		webCall = new WWW("http://localhost:3000",body,headers);
		yield return webCall;
		Debug.Log (webCall.text);
		Debug.Log ("web done");
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
