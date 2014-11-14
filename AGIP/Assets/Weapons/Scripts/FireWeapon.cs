using UnityEngine;
using System.Collections;

public class FireWeapon : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		// if player has no ammo in their current clip, set canFire to false
		if (PlayerManager.currAmmo <= 0) {
			Debug.Log("Player out of ammo, cannot fire current weapon.");
			WeaponManager.canFire = false;
		}
		else if (PlayerManager.currAmmo > 0 ) {
			WeaponManager.canFire = true;
		}

		// Check if player has a gun that they can fire, when trigger is intialized
		if (WeaponManager.canFire && PlayerManager.hasWeapon && Input.GetButtonDown("Fire1")) {

			switch (PlayerManager.currWeaponType) {

				case WeaponManager.WeaponType.unarmed:
					// do nothing
					break;

				case WeaponManager.WeaponType.pistol:
					// pistol
					StartCoroutine(delayWeaponFire(WeaponManager.GunRateOfFire_pistol));
					break;

				default:
					// If player does not have a current weapon, assign none as current weapon
					PlayerManager.currWeaponType = WeaponManager.WeaponType.unarmed;
					// do nothing
					break;

			} // end switch
		}

	}

	// Used for implementing the fire rate of current weapon
	IEnumerator delayWeaponFire(float rateOfFire) {

		initProjectile();
		WeaponManager.canFire = false;
		yield return new WaitForSeconds(rateOfFire);
		WeaponManager.canFire = true;

	}

	// Fires a projectile using raycasting
	void initProjectile() {
	
		int layerMask = (1 << 8); // 1 << 8 = player layer mask. 
		RaycastHit hit;

		// Subtract fired projectile from currAmmo
		PlayerManager.currAmmo = PlayerManager.currAmmo - 1;
		Debug.Log("Projectile Fired - current ammo: " + PlayerManager.currAmmo + "/" + PlayerManager.currNumOfClips);

		// Ray Hit player
		if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out hit, Mathf.Infinity, layerMask)) {
			Debug.DrawRay(transform.position, transform.TransformDirection (Vector3.forward) * hit.distance, Color.yellow);

			// Checks the range of the weapon being fired
			if (hit.distance <= WeaponManager.currAimDistance) {
				Debug.Log("Player Hit \t Distance: " + hit.distance + " Current Aim Distance:  " + WeaponManager.currAimDistance);
			}
		}
		// Does the ray intersect any objects excluding the player layer
		else {
			Debug.DrawRay(transform.position, transform.TransformDirection (Vector3.forward) * 1000, Color.white);

			if (hit.distance <= WeaponManager.currAimDistance) {
				Debug.Log("Object Hit \t Distance: " + hit.distance + " Current Aim Distance:  " + WeaponManager.currAimDistance);
		
			}
		}
	}

} // end class
