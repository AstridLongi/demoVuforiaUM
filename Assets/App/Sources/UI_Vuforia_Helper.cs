using UnityEngine;
using System.Collections;
using Vuforia;

public class UI_Vuforia_Helper : MonoBehaviour, ITrackableEventHandler {
	private TrackableBehaviour mTrackableBehaviour;
	public GameObject target;
	public GameObject texture;
	void OnEnable () {
		Debug.Log ("OnEnable");
		mTrackableBehaviour = target.GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			Debug.Log ("Lo encontro");
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}

	}
	void OnDisable () {
		Debug.Log ("OnDisable");

	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
		UITexture _texture = texture.GetComponent<UITexture> ();
		_texture.alpha = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		Debug.Log ("Status Change");
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			texture.SetActive (false);
		}
		else
		{
			texture.SetActive (true);
		}
	}
}
