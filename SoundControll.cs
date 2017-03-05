using UnityEngine;
using System.Collections;

public class SoundControll : MonoBehaviour 
{
	public AudioClip StageClear;
	public AudioClip StartSE;
	public AudioClip FireSE;


	private AudioSource SoundEffect;

	// Use this for initialization
	void Start () 
	{
		SoundEffect = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void stageClear_Play()
	{
		SoundEffect.clip = StageClear;
		SoundEffect.Play ();
	}

	public void StageStart_Play()
	{
		SoundEffect.clip = StartSE;
		SoundEffect.Play ();
	}

	public void Fire_Play()
	{
		SoundEffect.clip = FireSE;
		SoundEffect.Play ();
	}
}
