using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	// Weapon types
	public enum WeaponType {
		unarmed = 0, 
		pistol = 1 
	};

	// -- Set Weapon Objects -------------------------------------------------------------
//	public static GameObject unarmed;
//	public static GameObject pistol;

//	public GameObject _unarmed;
//	public GameObject _pistol;

//	void Awake () {
//		unarmed 	= _unarmed;
//		pistol 		= _pistol;
//	}

	// -- Generic Configurations ---------------------------------------------------------
	public static bool canFire 					= false;
	public static bool isAiming 				= false;
	public static float currAimDistance 		= pistol_UnaimedDistance; // set as default pistols aim distance

	public static float clipRespawnTime			= 60.0F;

	// -- Pistol Configurations ----------------------------------------------------------
	public static float GunRateOfFire_pistol 	= 0.5F; // rate of fire in seconds
	public static int pistol_ClipSize 			= 8;
	public static int pistol_MaxClips 			= 2;	// 1 clip loaded in gun, 2 clips reserved : 8+16
	public static int pistol_ProjectileSpeed 	= 1000;
	public static float pistol_UnaimedDistance 	= 4.0F;
	public static float pistol_AimDistance 		= 6.0F;
	

	// -- Unarmed Configurations ---------------------------------------------------------
	public static float GunRateOfFire_unarmed 		= 0.0F; // rate of fire in seconds
	public static int unarmed_ClipSize 				= 0;
	public static int unarmed_MaxClips 				= 0;
	public static int unarmed_ProjectileSpeed 		= 0;
	public static float unarmed_UnaimedDistance 	= 0.0F;
	public static float unarmed_AimDistance 		= 0.0F;

} // end class
