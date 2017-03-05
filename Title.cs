using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Title : MonoBehaviour
{
	[SerializeField] Text titleText;
	[SerializeField] float m_AngularFrequency = 1.0f;
	[SerializeField] float m_DeltaTime = 0.3f;

	Coroutine m_Coroutine;

	// Use this for initialization
	void Start () 
	{
		
	}
		
	// Update is called once per frame
	void Update () 
	{
		if(CommonUtility.gameControl.IsBPress == true)
		{
			SceneManager.LoadScene ("main");
		}
	}

	void Reset()
	{
		titleText = GetComponent<Text>();
	}

	void Awake()
	{
		StartFlash ();
	}

	IEnumerator Flash()
	{
		float m_Time = 0.0f;

		while(true)
		{
			m_Time += m_AngularFrequency * m_DeltaTime;
			var color = titleText.color;
			color.a = Mathf.Abs (Mathf.Sin (m_Time));
			titleText.color = color;

			yield return new WaitForSeconds (m_DeltaTime);
		}
	}

	public void StartFlash()
	{
		m_Coroutine = StartCoroutine (Flash ());
	}

	public void StopFlash()
	{
		StopCoroutine (m_Coroutine);
	}
}
