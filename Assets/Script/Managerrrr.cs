using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Vuforia;

public class Managerrrr : MonoBehaviour {

	private GameObject[] itt;
	public GameObject cvs1,cvs2;
	public GameObject templates;


	public void back()
	{
		cvs1.SetActive (false);
		cvs2.SetActive (true);
	}
}
