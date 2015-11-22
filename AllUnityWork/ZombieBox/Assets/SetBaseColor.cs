using UnityEngine;
using System.Collections;

public class SetBaseColor : MonoBehaviour {
	void Start () {
		this.GetComponent<Renderer>().materials[1].color = new Color(PlayerPrefs.GetFloat("BaseRed"),
																	PlayerPrefs.GetFloat("BaseGreen"),
																	PlayerPrefs.GetFloat("BaseBlue"));
	}
}
