using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoundPicker : MonoBehaviour {

	public Text highestText;
	public InputField roundField;

	public int highestRound = 1;
	public int selectedRound = 1;


	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("highestRound")) ;
		{
			highestRound = PlayerPrefs.GetInt("highestRound");
		}
		highestText.text = "" + highestRound;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void incrementRound()
	{
		if ( selectedRound+1 <= highestRound)
		{
			roundField.text = "" + (int.Parse(roundField.text) + 1);
			selectedRound += 1;
		}
	}

	public void decrementRound()
	{
		if ( selectedRound - 1 > 0 )
		{
			roundField.text = "" + (int.Parse(roundField.text) - 1);
			selectedRound -= 1;
		}
	}

	public void verifyRoundInput()
	{
		int fieldIn = int.Parse(roundField.text);

		if (fieldIn == null || fieldIn < 1)
		{
			selectedRound = 1;
			roundField.text = "" + 1;
		}
		else if (fieldIn > highestRound)
		{
			selectedRound = highestRound;
			roundField.text = "" + highestRound;
		}
		else
		{
			selectedRound = fieldIn;
		}
	}

}
