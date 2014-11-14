using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class WeaponSwitch : MonoBehaviour {

	// Holds list of weapon game objects -- cureently not used
//	private List<Transform> childsOfWeaponGameobject = new List<Transform>();
//
//	void Awake () {
//		foreach( Transform weapons in this.transform) {
//			Debug.Log(weapons); // weapons attached ot the player's weapon
//			childsOfWeaponGameobject.Add(weapons);
//		}
//	}

	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown("Weapon1")) {
			Debug.Log("Weapon 1 Selected");

			// save weapon 2 current parameters
			PlayerManager.weaponSlot_2_weaponType = PlayerManager.currWeaponType;
			PlayerManager.weaponSlot_2_Ammo = PlayerManager.currAmmo;
			PlayerManager.weaponSlot_2_NumOfClips = PlayerManager.currNumOfClips;

			PlayerManager.currWeaponType = PlayerManager.weaponSlot_1_weaponType;
			PlayerManager.currAmmo = PlayerManager.weaponSlot_1_Ammo;
			PlayerManager.currNumOfClips = PlayerManager.weaponSlot_1_NumOfClips;
			setUnaimedDistance();
		}

		else if (Input.GetButtonDown("Weapon2")) {
			Debug.Log("Weapon 2 Selected");

			// save weapon 1 current parameters
			PlayerManager.weaponSlot_1_weaponType = PlayerManager.currWeaponType;
			PlayerManager.weaponSlot_1_Ammo = PlayerManager.currAmmo;
			PlayerManager.weaponSlot_1_NumOfClips = PlayerManager.currNumOfClips;

			// set current wepaon parameters to weapon slot 2
			PlayerManager.currWeaponType = PlayerManager.weaponSlot_2_weaponType;
			PlayerManager.currAmmo = PlayerManager.weaponSlot_2_Ammo;
			PlayerManager.currNumOfClips = PlayerManager.weaponSlot_2_Ammo;
			setUnaimedDistance();
		}

	}

	void setUnaimedDistance () {

		switch (PlayerManager.currWeaponType) {
			
			case WeaponManager.WeaponType.unarmed:
				// do nothing
				WeaponManager.currAimDistance = WeaponManager.unarmed_UnaimedDistance;
				break;
				
			case WeaponManager.WeaponType.pistol:
				// pistol
				WeaponManager.currAimDistance = WeaponManager.pistol_UnaimedDistance;
				break;
				
			default:
				// If player does not have a current weapon, assign none as current weapon
				WeaponManager.currAimDistance = WeaponManager.unarmed_UnaimedDistance;
				// do nothing
				break;
			
		} // end switch

	}
	
}
