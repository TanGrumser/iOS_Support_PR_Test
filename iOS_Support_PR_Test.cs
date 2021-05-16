using UnityEngine;

#if UNITY_IOS
using Unity.Advertisement.IosSupport;
using UnityEngine.iOS;
#endif


public class iOS_Support_PR_Test : MonoBehaviour {

#if UNITY_IOS

    private const string CALLBACK_RECEIVED = "Callback was received.";
    private const string CALLBACK_PENDING = "Waiting for Callback.";

    private string statusText = CALLBACK_PENDING;

    private void Awake() {
        if(ATTrackingStatusBinding.GetAuthorizationTrackingStatus() == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED) {
            ATTrackingStatusBinding.RequestAuthorizationTracking(CallbackReceived);
        }
    }

    private void CallbackReceived() {
        statusText = CALLBACK_RECEIVED;
    }

    private void OnGUI() {
		GUIStyle style = new GUIStyle();
        
		Rect rect = new Rect(20, Screen.height - 70, Screen.width, 20);
		style.alignment = TextAnchor.UpperLeft;
        style.fontSize = 50;
		style.normal.textColor = Color.white;

		GUI.Label(rect, statusText, style);
    }

#endif

}
