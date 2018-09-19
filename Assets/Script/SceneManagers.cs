using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour {

	public bool splash;
	public GameObject mainMenuel;
	public GameObject arMenuel;
	public GameObject vrMenuel;
	public GameObject spinner;


	void Start()
	{
		if (splash == true) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}


	void Update()
	{
		if (Input.GetKey(KeyCode.Escape)) 
		{
			exits ();
		}
	}
		


	public void exit()
	{
		exits ();
	}


	void exits()
	{
		Application.Quit ();
	}


	public void SceneARMenu()
	{
		mainMenuel.SetActive (false);
		arMenuel.SetActive (true);
	}

	public void SceneVRMenu()
	{
		mainMenuel.SetActive (false);
		vrMenuel.SetActive (true);
	}

	public void ChangeScene(string scenes)
	{
		Application.LoadLevel (scenes);
		spinner.SetActive (true);
	}

	public void backbtn()
	{
		arMenuel.SetActive (false);
		vrMenuel.SetActive (false);
		mainMenuel.SetActive (true);
	}

	public void mainMenu()
	{
		Application.LoadLevel ("Scene_MainMenu");
	}

	public void OK(GameObject intro)
	{
		
		intro.SetActive (true);
		gameObject.SetActive (false);

	}

	public void room(GameObject me)
	{
		me.SetActive (false);
	}
}
