using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Gameover : MonoBehaviour 
{
	// 血のアニメーションを一回だけ通す用フラグ
	private bool justOnce_Flag = true;
	// ゲームオーバーの画像
	public GameObject gameoverImage;
	// レンダラー取得用
	SpriteRenderer m_spriteRenderer;
	// 血の初期イメージ
	public Image bloodImage;

	// 血のアニメーション
	Animator bloodAnim;

	private BGMControll BGMObj;
	public PlayerSEControl PlayerSEObj;

	// Use this for initialization
	void Start ()
	{
		bloodAnim = bloodImage.GetComponent<Animator> ();
		//bloodImage.GetComponent<SpriteRenderer> ().enabled = false;
		m_spriteRenderer = gameoverImage.GetComponent<SpriteRenderer> ();
		m_spriteRenderer.color = new Color(255,255,255,0);

		BGMObj = GameObject.Find ("BGM_Control").GetComponent<BGMControll> ();
		PlayerSEObj = GameObject.Find ("PlayerSE").GetComponent<PlayerSEControl> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if(CommonUtility.m_gameover_Flag)
		{

			StartCoroutine (GameOver_wait_time ());
			// gameoverImageの非透明化

			if(justOnce_Flag)
			{
				var color = m_spriteRenderer.color;
				color.a += 1f;
				m_spriteRenderer.color = color;
				// bloodAnimation.SetBool ("BloodEffect_Flag", true);

				/*GameObject.Instantiate (bloodAnim,
										Canvas.transform.position,
										Quaternion.identity);*/
				// bloodAnim.transform.SetParent (Canvas.transform, false);
				//bloodImage.GetComponent<SpriteRenderer> ().enabled = true;
				// Debug.Log ("kita");


				BGMObj.GameOver_BGM ();
				PlayerSEObj.Scream_Play ();
		
				justOnce_Flag = false;

			}
		}
	}

	IEnumerator GameOver_wait_time()
	{
		yield return new WaitForSeconds (3f);
		bloodAnim.SetInteger ("Blood_Flag",0);
		yield return new WaitForSeconds (10f);

		CommonUtility.init ();
		SceneManager.LoadScene ("Title");

		// justOnce_Flag = true;

	}
}
