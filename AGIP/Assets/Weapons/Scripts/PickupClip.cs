using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]

public class PickupClip : MonoBehaviour {

	//public AudioClip pickupClip_SFX;
	
	void OnTriggerEnter (Collider pickup) {
		pickupClip(pickup);
	}

	void OnTriggerStay (Collider pickup) {
		pickupClip(pickup);
	}

	void pickupClip (Collider pickup) {
		// pistol clip pickup
		if(pickup.CompareTag("Pistol_Clip")) {

			// Can't have more than 3 clips in pocket (1 loaded, 3 in pocket)
			if (PlayerManager.currWeaponType == WeaponManager.WeaponType.pistol && 
			    PlayerManager.currNumOfClips < WeaponManager.pistol_MaxClips) {
				
				PlayerManager.currNumOfClips = PlayerManager.currNumOfClips + 1;
				ammoClipReceived(pickup);

			}
			else if (PlayerManager.weaponSlot_1_weaponType == WeaponManager.WeaponType.pistol && 
			    PlayerManager.weaponSlot_1_NumOfClips < WeaponManager.pistol_MaxClips) {

				PlayerManager.weaponSlot_1_NumOfClips = PlayerManager.weaponSlot_1_NumOfClips + 1;
				ammoClipReceived(pickup);
			
			}
			else if (PlayerManager.weaponSlot_2_weaponType == WeaponManager.WeaponType.pistol && 
			         PlayerManager.weaponSlot_2_NumOfClips < WeaponManager.pistol_MaxClips) {

				PlayerManager.weaponSlot_2_NumOfClips = PlayerManager.weaponSlot_2_NumOfClips + 1;
				ammoClipReceived(pickup);
			
			}
		} // end pistol clip pickup
	}

	// sets the collider and renderer of the ammo clip object to false
	void ammoClipReceived (Collider pickup) {

		Debug.Log("Pick up pistol clip.");
		//audio.PlayOneShot(pickupClip_SFX);
		
		pickup.renderer.enabled = false;
		pickup.collider.enabled = false;
		StartCoroutine(respawnClip(pickup));

	}

	// after the clip respawn time expires the ammo clip is visable and able to be pickup again.
	IEnumerator respawnClip(Collider pickup) {

		yield return new WaitForSeconds(WeaponManager.clipRespawnTime);
		pickup.renderer.enabled = true;
		pickup.collider.enabled = true;

	}
}
