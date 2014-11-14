using UnityEngine;
using System.Collections;

public class Pistol : MonoBehaviour {

	public GameObject pistol;

	// Update is called once per frame
	void Update () {

		if (PlayerManager.currWeaponType == WeaponManager.WeaponType.pistol) {
			pistol.renderer.enabled = true;
			pistol.collider.enabled = true;
		}
		else {
			pistol.renderer.enabled = false;
			pistol.collider.enabled = false;
		}
	
	}
}
