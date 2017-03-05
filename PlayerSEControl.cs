using UnityEngine;
using System.Collections;

public class PlayerSEControl : MonoBehaviour 
{
	public AudioClip ShotSE;
	public AudioClip ChargeSE;
	public AudioClip ScreamSE;
	public AudioClip EnptySE;

	private AudioSource playerAudio;
	private MojiSEControl mojiObj;
	private CardboardHead CardBoradObj;

	int Daruma_SE_Count;
	// Use this for initialization
	void Start () 
	{
		mojiObj = GameObject.Find ("MojiSE_Control").GetComponent<MojiSEControl> ();
		playerAudio = gameObject.GetComponent<AudioSource> ();

		CardBoradObj = GameObject.Find ("Head").GetComponent<CardboardHead> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Fire1") || CommonUtility.gameControl.IsBPress && CommonUtility.m_reload_Flag == false && CommonUtility.m_gameover_Flag == false)
		{
			playerAudio.clip = ShotSE;
			playerAudio.Play ();
			Daruma_SE_Count = 0;

		}
		else if (Input.GetButtonDown("Fire1") || CommonUtility.gameControl.IsBPress /*CommonUtility.gameControl.IsBPress*/ && CommonUtility.m_reload_Flag && CommonUtility.m_gameover_Flag == false)
		{
			if (Daruma_SE_Count < 10) {
				playerAudio.clip = ChargeSE;
				playerAudio.Play ();
				mojiObj.MojiSE_play ();
				Daruma_SE_Count++;
			}
		}

		// 弾切れｓE
		if(CardBoradObj.backRock == false && CommonUtility.m_reload_Flag == false)
		{
			playerAudio.clip = EnptySE;
			playerAudio.Play ();
		}
	}

	public void Scream_Play()
	{
		playerAudio.clip = ScreamSE;
		playerAudio.Play ();
	}
}
