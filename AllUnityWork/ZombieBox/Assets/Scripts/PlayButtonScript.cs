using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class PlayButtonScript : MonoBehaviour {
	public void PlayPressed ()
	{

		PlayerPrefs.SetString("charID", Regex.Replace(CharSelect.selected.name, "[^0-9]", ""));
		Application.LoadLevel ("base");              
	}
}
