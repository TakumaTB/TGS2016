using UnityEngine;
using System.Collections;

public class EnemySEControl : MonoBehaviour 
{
	private AudioSource[] enemyAudio;

	private bool justOne_Flag = true;

	// Use this for initialization
	void Start () 
	{
		enemyAudio = gameObject.GetComponents<AudioSource> ();
		enemyAudio [1].Play ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(CommonUtility.m_sinkFlag == true && justOne_Flag == true)
		{
			enemyAudio [1].Play ();
			justOne_Flag = false;
			if(CommonUtility.m_sinkFlag == false)
			{
				justOne_Flag = true;
			}
		}
	}

	public void m_EnemyHit()
	{
		enemyAudio [0].Play ();
	}
}
