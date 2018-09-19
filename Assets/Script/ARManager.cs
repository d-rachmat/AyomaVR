using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ARManager : MonoBehaviour {

	public GameObject[] gambar;
	public GameObject[] infos;
	public GameObject panelWalkTrough;
	public Animator buildanim, n1, n2;
	public Button UGIN1,UGIN2,UREF;


	public void change(GameObject aktif)
	{

		for (int i = 0; i < gambar.Length; i++) 
		{
			gambar [i].SetActive (false);
		}

		aktif.SetActive (true);

	}

	public void changei(GameObject infor)
	{

		for (int i = 0; i < infos.Length; i++) 
		{
			infos [i].SetActive (false);
			
		}

		infor.SetActive (true);

	}

	public void closebtn()
	{
		panelWalkTrough.SetActive (false);
	}

	public void ControlN2()
	{
		n2.SetTrigger ("N2");
		UGIN2.interactable = false;
		UGIN1.interactable = true;
	}

	public void ControlN1()
	{
		n1.SetTrigger ("N1");
		UGIN1.interactable = false;
		UREF.interactable = true;
		UREF.interactable = true;
	}

	public void Refresh()
	{
		n2.SetTrigger ("N2-");
		n1.SetTrigger ("N1-");
		UGIN1.interactable = false;
		UGIN2.interactable = true;
		UREF.interactable = false;
	}
}
