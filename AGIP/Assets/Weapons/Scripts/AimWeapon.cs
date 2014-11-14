using UnityEngine;
using System.Collections;

public class AimWeapon : MonoBehaviour {

	Vector3 fwd;
	LineRenderer lineOfSight;

	void Awake () {
		lineOfSight = GetComponent<LineRenderer>();
		lineOfSight.enabled = false;
		lineOfSight.SetVertexCount(2);
		lineOfSight.SetWidth(0.07F, 0.07F);
	}

	// Update is called once per frame
	void Update () {

		fwd = transform.TransformDirection (Vector3.forward * WeaponManager.currAimDistance);

		// Check if player has a gun that they can fire, when trigger is intialized
		if (PlayerManager.hasWeapon && Input.GetButtonDown("Fire3")) {
			
			WeaponManager.isAiming = true;

			switch (PlayerManager.currWeaponType) {
				
				case WeaponManager.WeaponType.unarmed:
					// none
					WeaponManager.currAimDistance = WeaponManager.unarmed_AimDistance;
					break;
					
				case WeaponManager.WeaponType.pistol:
					// pistol
					WeaponManager.currAimDistance = WeaponManager.pistol_AimDistance;
					break;
					
				default:
					// If player does not have a current weapon, assign none as current weapon
					PlayerManager.currWeaponType = WeaponManager.WeaponType.unarmed;
					WeaponManager.currAimDistance = WeaponManager.unarmed_AimDistance;
					// do nothing
					break;
				
			} // end switch

			Debug.Log("Aim Distance - Aimed: " + WeaponManager.currAimDistance);
		}
		// If player releases aim button - set range to unaimed distance for the weapon
		else if (PlayerManager.hasWeapon && Input.GetButtonUp("Fire3")) {

			WeaponManager.isAiming = false;

			switch (PlayerManager.currWeaponType) {
				
				case WeaponManager.WeaponType.unarmed:
					// none
					WeaponManager .currAimDistance = WeaponManager.unarmed_UnaimedDistance;
					break;
					
				case WeaponManager.WeaponType.pistol:
					// pistol
					WeaponManager.currAimDistance = WeaponManager.pistol_UnaimedDistance;
					break;
					
				default:
					// If player does not have a current weapon, assign none as current weapon
					PlayerManager.currWeaponType = 0;
					WeaponManager .currAimDistance = WeaponManager.unarmed_UnaimedDistance;
					break;

			} // end switch

			Debug.Log("Aim Distance - Unaimed: " + WeaponManager.currAimDistance);
		}

		// If player is aiming - draw line of sight
		if (WeaponManager.isAiming) {
			drawLineOfSight();
		}
		// if player isn't pressing the aim button - hide line of sight aim
		else {
			lineOfSight.enabled = false;
		}

	}

	// draws the line of sight for the players aim
	void drawLineOfSight () {

		lineOfSight.SetPosition(0, transform.position); 
		fwd.Normalize();
		lineOfSight.SetPosition(1, transform.position + fwd * WeaponManager.currAimDistance);
		lineOfSight.enabled = true;

	}
}
