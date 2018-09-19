using UnityEngine;
using System.Collections;
using Vuforia;

public class ChageObject : MonoBehaviour{
	
	public GameObject objek1,objek2,objek3, objek4;
	public GameObject[] objek3D = new GameObject[4];
	public int no = 1;

	public GameObject[] obj;
	public GameObject me, builder;

	public void Start(){
		objek3D [0] = objek1;
		objek3D [1] = objek2;
		objek3D [2] = objek3;
		objek3D [3] = objek4;
	}

	public void nextObject()
	{
		if (no < 4)
		{
			no++;
		}
	}

	public void prevObject()
	{
		if (no > 1)
		{	
			no--;
		}
	}

	public void ChangesO(GameObject Model)
	{
		builder.SetActive (true);

		for (int i = 0; i < obj.Length; i++) 
		{
			obj [i].SetActive (false);
		}

		Model.SetActive (true);

		me.SetActive (false);
	}

	public void Update()
	{
		if (no == 1) 
		{
			objek1.SetActive(true);
			objek2.SetActive(false);
			objek3.SetActive(false);
			objek4.SetActive(false);
		}

		if (no == 2) 
		{
			objek1.SetActive(false);
			objek2.SetActive(true);
			objek3.SetActive(false);
			objek4.SetActive(false);
		}

		if (no == 3) 
		{
			objek1.SetActive(false);
			objek2.SetActive(false);
			objek3.SetActive(true);
			objek4.SetActive(false);
		}

		if (no == 4) 
		{
			objek1.SetActive(false);
			objek2.SetActive(false);
			objek3.SetActive(false);
			objek4.SetActive(true);
		}
	}


}