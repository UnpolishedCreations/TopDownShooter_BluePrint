using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	//--------- Survival variables ----------------------
	public static int lives = 0;
	public static int health = 0;
	public static int spirit = 0;

	//--------- Weapon variables ------------------------
	public static bool hasWeapon;
	public static WeaponManager.WeaponType currWeaponType;
	public static int currAmmo;
	public static int currNumOfClips;
	// Weapon slot 1
	public static WeaponManager.WeaponType weaponSlot_1_weaponType;	// Players first weapon
	public static int weaponSlot_1_Ammo;
	public static int weaponSlot_1_NumOfClips;
	// weapon slot 2
	public static WeaponManager.WeaponType weaponSlot_2_weaponType;	// Players second weapon
	public static int weaponSlot_2_Ammo;
	public static int weaponSlot_2_NumOfClips;

	//--------- Player position information -------------
	public static Vector3 forwardDirection; // stores the forward direction of the player

	//--------- Class Variables -------------------------
	private int forwardRaycastDistance = 10;

	// Initialization
	void Awake () {

		// Survival
		lives 	= 3;
		health 	= 100;
		spirit 	= 100;

		// Weapon - player starts with basic pistol
		WeaponManager.canFire	= true;
		hasWeapon 				= true;	
		currWeaponType 			= WeaponManager.WeaponType.pistol;
		currAmmo				= WeaponManager.pistol_ClipSize;
		currNumOfClips			= WeaponManager.pistol_MaxClips;
		// Weapon slot 1
		weaponSlot_1_weaponType = WeaponManager.WeaponType.pistol;
		weaponSlot_1_Ammo		= WeaponManager.pistol_ClipSize;
		weaponSlot_1_NumOfClips = WeaponManager.pistol_MaxClips;
		//Weapon slot 2
		weaponSlot_2_weaponType = WeaponManager.WeaponType.unarmed;
		weaponSlot_2_Ammo		= WeaponManager.unarmed_ClipSize;
		weaponSlot_2_NumOfClips	= WeaponManager.unarmed_MaxClips;


	}

	void Update () {

		// Gets (displays) the forward direction of the player
		forwardDirection = transform.TransformDirection (Vector3.forward * forwardRaycastDistance);
		Debug.DrawLine (transform.position, forwardDirection + transform.position);

	}

} // end class
