using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControl : MonoBehaviour
{
	bool isAPress = false;
	public bool IsAPress { get { return isAPress; } }
	bool isBPress = false;
	public bool IsBPress { get { return isBPress; } }

	private bool connected = false;

	// Use this for initialization
	void Start () 
	{
		CommonUtility.gameControl = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		var _x = Input.GetAxis ("Horizontal");
		var _x2 = Input.GetAxis ("Vertical");
		var _x13 = Input.GetAxis ("Horizontal2");
		var _x14 = Input.GetAxis ("Vertical2");
		var _x15 = Input.GetAxis ("Horizontal3");
		var _x16 = Input.GetAxis ("Vertical3");
		// Debug.Log ("kita");
		// Aボタンの判定
		if(Input.GetKeyDown(KeyCode.Joystick1Button14))
			isAPress= true;
		else
			isAPress= false;
		Debug.Log ("A Press = " + isAPress);
		// Bボタンの判定
		if (Input.GetKeyDown(KeyCode.Joystick1Button13))
			isBPress = true;
		else 
			isBPress = false;


		/*
		if (Input.GetKey ("joystick button 3"))
			_x5 = "X Press";
		if (Input.GetKey ("joystick button 4"))
			_x6 = "Y Press";
		if (Input.GetKey ("joystick button 6"))
			_x7 = "L1 Press";
		if (Input.GetKey ("joystick button 7"))
			_x8 = "R1 Press";
		if (Input.GetKey ("joystick button 8"))
			_x9 = "L2 Press";
		if (Input.GetKey ("joystick button 9"))
			_x10 = "R2 Press";
		if (Input.GetKey ("joystick button 11"))
			_x11 = "Start Press";
		if (Input.GetKey ("joystick button 10"))
			_x12 = "Select Press";
		*/
	}

	// コントローラーの検知
	IEnumerator CheckForControllers()
	{
		while (true)
		{
			var controllers = Input.GetJoystickNames();
			if (!connected && controllers.Length > 0)
			{
				connected = true;
				Debug.Log("Connected");
			}
			else if (connected && controllers.Length == 0)
			{
				connected = false;
				Debug.Log("Disconnected");
			}
			yield return new WaitForSeconds(1f);
		}
	}

	void Awake()
	{
		StartCoroutine(CheckForControllers());
	}

}
