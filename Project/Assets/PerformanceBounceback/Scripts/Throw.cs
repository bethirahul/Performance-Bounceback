using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    public float throwForce = 2f;
    public GameManager GM;

	//   S T A R T																										
    void Start()
    {
        ///trackedObj = GetComponent<SteamVR_TrackedObject>();
		device = SteamVR_Controller.Input((int)trackedObj.index);
    }

	/*//   U P D A T E																									
    void Update()
    {
        
    }*/

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
				GM.Debug_Log("You have released the trigger");

                //Multi Throwing
                col.transform.SetParent(null);
                Rigidbody rigidBody = col.GetComponent<Rigidbody>();
                rigidBody.isKinematic = false;

                rigidBody.velocity = device.velocity * throwForce;
                rigidBody.angularVelocity = device.angularVelocity;
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
				GM.Debug_Log("You are touching down the trigger on an object");
                col.GetComponent<Rigidbody>().isKinematic = true;
                col.transform.SetParent(gameObject.transform);

                device.TriggerHapticPulse(2000);
            }
        }
    }
}
