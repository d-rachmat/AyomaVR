using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TeleportPlayer : MonoBehaviour{

	public GameObject[] Enables;
	public GameObject[] Disables;
	public Texture nextPlace;
	private GameObject  mod;
	public bool boel;
	public bool boels;
	public float countdown = 3;
	public float countdowns = 3;

	// Use this for initialization
	void Start () {
		mod = GameObject.Find ("bolas");
	}
	
	// Update is called once per frame
	void Update () {
		GvrViewer.Instance.UpdateState();
		if (GvrViewer.Instance.BackButtonPressed) {
			Application.LoadLevel("Scene_MainMenu");
		}

		if (Input.GetKey(KeyCode.Escape)) 
		{
			Application.LoadLevel ("Scene_MainMenu");
		}

		if (boel == true) {
			countdown -= Time.deltaTime;
		} else 
		{
			countdown = 3;
			boel = false;
		}

		if (boels == true) {
			countdowns -= Time.deltaTime;
		} else 
		{
			countdowns = 3;
			boels = false;
		}


		if (countdown <=0 ) 
		{
			for (int i = 0; i < Disables.Length; i++) {
				Disables [i].SetActive (false);
			}

			for (int i = 0; i < Enables.Length; i++) {
				Enables [i].SetActive (true);
			}

			countdown = 3;
			boel = false;
			mod.GetComponent<Renderer> ().material.mainTexture = nextPlace;
		}

		if (countdowns <= 0 ) {
			boels = false;
			Application.LoadLevel ("Scene_MainMenu");
		}
	}

	public void ToggleVRMode() {
		GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
	}

	public void ToggleDistortionCorrection() {
		GvrViewer.Instance.DistortionCorrectionEnabled =
			!GvrViewer.Instance.DistortionCorrectionEnabled;
	}

	#if !UNITY_HAS_GOOGLEVR || UNITY_EDITOR
	public void ToggleDirectRender() {
		GvrViewer.Controller.directRender = !GvrViewer.Controller.directRender;
	}
	#endif

	public void pindah()
	{
		for (int i = 0; i < Disables.Length; i++) {
			Disables [i].SetActive (false);
		}

		for (int i = 0; i < Enables.Length; i++) {
			Enables [i].SetActive (true);
		}
		countdown = 3;
		boel = false;
		mod.GetComponent<Renderer> ().material.mainTexture = nextPlace;
	}

	public void pindahauto()
	{
		boel = true;
	}

	public void gkjadipindah()
	{
		boel = false;
	}

	public void homes()
	{
		Application.LoadLevel ("Scene_MainMenu");
	}

	public void homesauto()
	{
		boels = true;
	}

	public void gkjadihome()
	{
		boels = false;
	}
}