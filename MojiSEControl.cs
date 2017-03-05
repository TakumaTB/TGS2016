using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MojiSEControl : MonoBehaviour 
{
	// public AudioClip[] MojiSE;
	private AudioSource MojiAudio;
	private int valueCount = 0;
	public static int mojiRandom = Random.Range (0, 2);
	public int Daruma_SE_Count;

	[System.SerializableAttribute]
	public class valueList
	{
		public List<AudioClip> MojiSE = new List<AudioClip> ();
	}

	[SerializeField]
	private List<valueList> _valueisList = new List<valueList> ();

	// Use this for initialization
	void Start () 
	{
		MojiAudio = GetComponent<AudioSource> ();
		mojiRandom = Random.Range (0, 2);
	}
	
	// Update is called once per frame
	void Update () 
	{
		


	}

	public void MojiSE_play()
	{
		
			MojiAudio.clip = _valueisList [valueCount].MojiSE [mojiRandom];
			MojiAudio.Play ();
			valueCount++;

		if (valueCount >= 10) {
			valueCount = 0;
		}

	}
}
