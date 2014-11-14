using UnityEngine;
using System.Collections;

public class ReloadWeapon : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown("Reload_1") && PlayerManager.currNumOfClips > 0) {

			Debug.Log("Weapon reloaded.");
			setCurrAmmo();
			PlayerManager.currNumOfClips = PlayerManager.currNumOfClips - 1;

		}
	
	}

	void setCurrAmmo () {
			
		switch (PlayerManager.currWeaponType) {
			
			case WeaponManager.WeaponType.unarmed:
				// do nothing
				PlayerManager.currAmmo = WeaponManager.unarmed_ClipSize;
				break;
				
			case WeaponManager.WeaponType.pistol:
				// pistol
				PlayerManager.currAmmo = WeaponManager.pistol_ClipSize;
				break;
				
			default:
				// do nothing
				break;
			
		} // end switch
			
	}
}
