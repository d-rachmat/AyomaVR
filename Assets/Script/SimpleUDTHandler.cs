using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Vuforia;

public class SimpleUDTHandler : MonoBehaviour , IUserDefinedTargetEventHandler{

	private UserDefinedTargetBuildingBehaviour mTargetBuildingBehaviour;
	private ObjectTracker mImageTracker;
	private DataSet mBuiltDataSet;

	//objek 3d yang akan diubah - ubah texturenya
	public GameObject objek3d;

	//newTexture adalah kondisi apakah sebuah objek kaleng akan diubah texturenya atau tidak
	// jika diubah maka nilai newTexture = true

	//newTarget adalah kondisi dimana saat kita telah mengcapture sebuah gambar/marker, maka akan dikenali sebagai Marker Aplikasi
	// jika kita melakukan capture gambar dan gambar dikenali, maka gambar akan digunakan sebagai marker (newTarget=true)
	public bool newTexture, newTarget = false;
	
	private bool mUdtInitialized = false;
	private ImageTargetBuilder.FrameQuality mFrameQuality = ImageTargetBuilder.FrameQuality.FRAME_QUALITY_NONE;
	
	public ImageTargetBehaviour ImageTargetTemplate;
	
	void Start() {
		mTargetBuildingBehaviour = GetComponent<UserDefinedTargetBuildingBehaviour>();
		if (mTargetBuildingBehaviour) {
			mTargetBuildingBehaviour.RegisterEventHandler(this);
		}
	}

	public void OnInitialized() {
		// look up the ImageTracker once and store a reference
		mImageTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
		
		if (mImageTracker != null) {
			// create a new dataset
			mBuiltDataSet = mImageTracker.CreateDataSet();
			mImageTracker.ActivateDataSet(mBuiltDataSet);
			
			// remember that the component has been initialized
			mUdtInitialized = true;
		}
	}

	public void OnFrameQualityChanged(ImageTargetBuilder.FrameQuality frameQuality) {
		mFrameQuality = frameQuality;
	}

	public void OnNewTrackableSource(TrackableSource trackableSource) {
		// deactivates the dataset first
		mImageTracker.DeactivateDataSet(mBuiltDataSet);
		
		// Destroy the oldest target if the dataset is full
		if (mBuiltDataSet.HasReachedTrackableLimit()) {
			IEnumerable<Trackable> trackables = mBuiltDataSet.GetTrackables();
			Trackable oldest = null;
			foreach (Trackable trackable in trackables)
				if (oldest == null || trackable.ID < oldest.ID)
					oldest = trackable;
			
			if (oldest != null) {
				mBuiltDataSet.Destroy(oldest, true);
			}
		}
		
		// get predefined trackable (template) and instantiate it
		ImageTargetBehaviour imageTargetCopy = (ImageTargetBehaviour)Instantiate(ImageTargetTemplate);
		
		// add the trackable to the data set and activate it
		mBuiltDataSet.CreateTrackable(trackableSource, imageTargetCopy.gameObject);
		
		// Re-activate the dataset
		mImageTracker.ActivateDataSet(mBuiltDataSet);
	}

	void OnGUI() {
		if (!mUdtInitialized) return;
		
		// If Frame Quality is medium / high => show Button to build target
		// jika kamera mendeteksi sebuah gambar yang memiliki tingkat detail pola dan warna yang sedang (MEDIUM) atau (TINGGI)
		// maka gambar dapat di capture dan dikenali sebagai marker
		if (mFrameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_MEDIUM ||
		    mFrameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_HIGH) {


			// jika sebuah gambar memiliki kualitas MEDIUM atau HIGH akan muncul button untuk melakukan Capture terhadap gambar
			if (GUI.Button(new Rect(200, Screen.height - 100, 200, 90), "Render")) {
				// jika button Render ditekan maka akan melakukan capture pada gambar dan disimpan dengan nama gambar.png
				// gambar hasil capture ini disimpan pada SDCard sehingga write Access harus diubah ke External (SDCard)
				Application.CaptureScreenshot("gambar.png");
				// jika gambar sudah di capture maka lakukan perubahan / penggantian texture pada objek kaleng
				newTarget=true;

			}
			if(newTexture==true){
				// jika proses pergantian texture selesai, maka gambar akan dikenali sebagai marker
				BuildNewTarget();
				// setelah proses pengenalan gambar sebagai marker selesai maka kondisi newTexture bernilai false dan semua kembali ke nilai awal
				newTexture = false;
			}
		}
	}

	private void BuildNewTarget() {
		string newTargetName = "MyUserDefinedTarget";
		mTargetBuildingBehaviour.BuildNewTarget(newTargetName, ImageTargetTemplate.GetSize().x);
	}

	void Update(){

		if (newTarget == true) {
			// jika newTarget bernilai true (objek akan di ganti texture)

			// file gambar yang ada di SDCard akan dibaca terlebih dahulu
			var fileName = Application.persistentDataPath + "/" + "gambar.png";

			// kemudian gambar dibaca per byte sebelum dikembalikan ke dalam bentuk 2D
			var bytes = File.ReadAllBytes (fileName);

			// setelah terbaca akan dikembalikan ke bentuk 2D
			var texture = new Texture2D (73, 73);
			// selanjutnya gambar akan di load
			texture.LoadImage (bytes);
			// hasil load gambar akan disimpan dan akan digunakan untuk mengganti texture objek kaleng
			//objek3d.renderer.material.mainTexture = texture;
			objek3d.GetComponent<Renderer> ().material.mainTexture = texture;
			// setelah texture objek telah terganti dengan gambar hasil capture maka status newTarget kembali menjadi "false"
			newTarget=false;

			//ketika proses perubahan texture selesai maka gambar akan dikenali sebagai Marker aplikasi (newTexture = true)
			newTexture = true;
		}
	}
}
