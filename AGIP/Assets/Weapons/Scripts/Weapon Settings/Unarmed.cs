using UnityEngine;
using System.Collections;

public class Unarmed : MonoBehaviour {

	public GameObject unarmed;
	
	// Update is called once per frame
	void Update () {

		if (PlayerManager.currWeaponType == WeaponManager.WeaponType.unarmed) {
			unarmed.renderer.enabled = true;
		}
		else {
			unarmed.renderer.enabled = false;
		}
	
	}
}
