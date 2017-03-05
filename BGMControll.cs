	using UnityEngine;
using System.Collections;

public class BGMControll : MonoBehaviour 
{
	private AudioSource[] BGM;
	private bool loopFlag = true;
	private float loopCount;

	private bool BGM1_Flag = true;
	private bool BGM2_Flag = true;

	// private main fukaiObj;

	/*
	AudioSource[2] -> gameClear
	AudioSource[3] -> gameOver
	*/

	// Use this for initialization
	void Start () 
	{
		BGM = gameObject.GetComponents<AudioSource> ();
		// fukaiObj = GameObject.Find ("fukai").GetComponent<main> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		loopCount += Time.deltaTime;

		if(loopFlag && BGM1_Flag)
		{
			BGM1_Flag = false;
			BGM [0].Play ();
		}
		if(loopCount >= 10.25 && loopFlag)
		{
			loopFlag = false;
			BGM1_Flag = true;
		}

		if(loopFlag == false && BGM2_Flag)
		{
			BGM2_Flag = false;
			BGM [1].Play ();
		}
		if(loopCount >= 20.5 && !loopFlag)
		{
			loopFlag = true;
			BGM2_Flag = true;
			loopCount = 0;
		}
	}

	// ゲームクリアBGMの処理
	public void GameClear_BGM()
	{
		BGM [2].Play ();
	}

	// ゲームオーバーBGMの処理
	public void GameOver_BGM()
	{
		BGM [3].Play ();
		BGM [0].Stop ();
		BGM [1].Stop ();
	}
}
