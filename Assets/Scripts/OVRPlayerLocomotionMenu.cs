// Purpose: Allows the user to toggle locomotion on and off. This script is attached to the OVRPlayerControllerWithHandPoses prefab.
// Original code created by Dilmer Valecillos on Github: https://github.com/dilmerv/MetaInteractionSDKDemos/blob/master/Assets/Scripts/OVRPlayerLocomotionMenu.cs

using Oculus.Interaction; 
using TMPro;            // For TextMeshProUGUI, which is used to display the current gesture
using UnityEngine;

[RequireComponent(typeof(OVRPlayerControllerWithHandPoses))]
public class OVRPlayerLocomotionMenu : MonoBehaviour
{
    [SerializeField]
    private OVRCameraRig cameraRig;

    [SerializeField]
    private GameObject targetHand;

    [SerializeField]
    private GameObject locomotionMenu;

    [SerializeField]
    private Vector3 offsetFromHand = new Vector3(0.5f, 0.5f, 0.5f);

    private OVRPlayerControllerWithHandPoses playerControllerWithHandPoses;

    // menuState
    [SerializeField]
    private InteractableUnityEventWrapper onLocomotionAction;
    private bool locomotionOn = true;

    private void Awake()
    {
        playerControllerWithHandPoses = GetComponent<OVRPlayerControllerWithHandPoses>();

        onLocomotionAction.WhenSelect.AddListener(() =>
        {
            locomotionOn = !locomotionOn;
            var locomotionMenuOption = onLocomotionAction.GetComponentInChildren<TextMeshPro>();
            var locomotionMenuState = locomotionOn ? "ON" : "OFF";
            locomotionMenuOption.text = $"LOCOMOTION {locomotionMenuState}";
            playerControllerWithHandPoses.EnableLinearMovement = locomotionOn;

            Logger.Instance.LogInfo($"Locomotion state changed to: {locomotionMenuState}");
        });
    }

    public void LocomotionVisibility(bool state)
    {
        locomotionMenu.SetActive(state);
    }

    private void Update()
    {
        locomotionMenu.transform.position = targetHand.transform.position + offsetFromHand;
        locomotionMenu.transform.rotation = Quaternion.LookRotation(locomotionMenu.transform.position - cameraRig.centerEyeAnchor.transform.position, Vector3.up);
    }

}