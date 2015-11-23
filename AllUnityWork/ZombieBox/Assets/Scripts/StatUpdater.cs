using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatUpdater : MonoBehaviour {

	//public PlayerHealth playerHealth;
	//public BaseHealth baseHealth;
	//public WeaponManager weaponManager;
	public RoundStats roundStats;

	//public Slider healthSlider;
	//public Slider baseSlider;

	public Text ammo;
	public Text score;
	public Text round;

	void Start()
	{
        
		round.text = "" + roundStats.ROUND_NUMBER;
		score.text = "" + roundStats.roundPoints;
	}

	public void setAmmo(int bullets)
	{
		ammo.text = "" + bullets;
	}

	public void clearAmmo()
	{
		ammo.text = "";
	}

	public void updateScore()
	{
		score.text = "" + roundStats.roundPoints;
       
	}
}
