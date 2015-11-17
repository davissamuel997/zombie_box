using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class PlayButtonScript : MonoBehaviour {

	public void PlayPressed ()
	{

		PlayerPrefs.SetString("charID", Regex.Replace(CharSelect.selected.name, "[^0-9]", ""));
		//mainCamera.transform.Rotate(Vector3.forward, 10.0f * Time.deltaTime);

		//Application.LoadLevel ("base");              
	}
}
