using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildingUDT : MonoBehaviour {

	public GameObject rf;
	public GameObject[] n2;
	public GameObject[] n1;
	public Button btn2, btn1,rfs;
	public void rfak()
	{
		rf.SetActive (true);
	}

	void Update()
	{
		
	}

	public void N2ctrl()
	{
		GameObject[] n2 = GameObject.FindGameObjectsWithTag ("N2");
		for (int i = 0; i < n2.Length; i++) 
		{
			n2 [i].GetComponent<Animator> ().SetTrigger ("N2");
		}
		rfs.interactable = false;
		btn2.interactable = false;
		btn1.interactable = true;
	}

	public void N1ctrl()
	{
		GameObject[] n1 = GameObject.FindGameObjectsWithTag ("N1");
		for (int i = 0; i < n1.Length; i++) 
		{
			n1 [i].GetComponent<Animator> ().SetTrigger ("N1");
		}
		btn1.interactable = false;
		rfs.interactable = true;
		btn2.interactable = false;
	}

	public void RefresingCtrl()
	{
		GameObject[] n1 = GameObject.FindGameObjectsWithTag ("N1");
		for (int i = 0; i < n1.Length; i++) 
		{
			n1 [i].GetComponent<Animator> ().SetTrigger ("N1-");
		}

		GameObject[] n2 = GameObject.FindGameObjectsWithTag ("N2");
		for (int i = 0; i < n2.Length; i++) 
		{
			n2 [i].GetComponent<Animator> ().SetTrigger ("N2-");
		}

		btn1.interactable = false;
		btn2.interactable = true;
		rfs.interactable = false;

	}
}
