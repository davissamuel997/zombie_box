using UnityEngine;
using System.Collections;

public class urlLink : MonoBehaviour {

	public void newUser()
	{
		Application.OpenURL("https://nameless-harbor-4730.herokuapp.com/users/sign_in");
	}

	public void forgotPassword()
	{
		Application.OpenURL("https://nameless-harbor-4730.herokuapp.com/users/forgot_password");
	}
}
