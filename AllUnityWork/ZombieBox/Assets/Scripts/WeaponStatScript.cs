using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponStatScript : MonoBehaviour {
	Slider amoSlider;
	Slider dmgSlider;
	Text caption;
	public WeaponUpgrade temp;
	// Use this for initialization
	void Start () 
	{
		Slider[] temp= this.GetComponentsInChildren<Slider>();
		dmgSlider = temp[0];
		amoSlider = temp[1];
		amoSlider.value = 0;
		dmgSlider.value = 0;
		caption = this.GetComponentInParent<Text>();
		


	}
	public void upgradeAmo()
	{
		if(amoSlider.value < 5)
			amoSlider.value++;
	}

	public void upgradeDmg()
	{
		if (dmgSlider.value < 5)
			dmgSlider.value++;
	}
	public void updateText(string str)
	{
		caption.text = str;
	}
	// Update is called once per frame
	void Update () 
	{
		updateText(temp.name);
	}
}
