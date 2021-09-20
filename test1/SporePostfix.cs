using HarmonyLib;
using UnityEngine;

namespace Randomizer
{
	[HarmonyPatch(typeof(PLInfectedSporeProj), "FixedUpdate")]
	internal class SporePatch
	{
		private static void Postfix(PLInfectedSporeProj __instance, ref Rigidbody ___MyRigidbody)
		{
			float d = 1f;
			if (PLEncounterManager.Instance.GetShipFromID(__instance.OwnerShipID).MyStats.Ship.TargetShip != null)
			{
				Vector3 normalized = (PLEncounterManager.Instance.GetShipFromID(__instance.OwnerShipID).MyStats.Ship.TargetShip.Exterior.transform.position - __instance.transform.position).normalized;
				Quaternion b = Quaternion.LookRotation(normalized);
				___MyRigidbody.rotation = b;
				float num = (PLEncounterManager.Instance.GetShipFromID(__instance.OwnerShipID).MyStats.Ship.TargetShip.Exterior.transform.position - __instance.transform.position).magnitude * 0.5f;
				float value = 0.5f;
				if (___MyRigidbody.velocity.sqrMagnitude > 1f)
				{
					value = Vector3.Dot(___MyRigidbody.velocity.normalized, normalized);
				}
				if (PLEncounterManager.Instance.GetShipFromID(__instance.OwnerShipID).MyStats.Ship.TargetShip.ExteriorRigidbody != null)
				{
					float min = Mathf.Max(8f, PLEncounterManager.Instance.GetShipFromID(__instance.OwnerShipID).MyStats.Ship.TargetShip.ExteriorRigidbody.velocity.magnitude * 1.1f);
					d = Mathf.Clamp(num * 0.005f * Mathf.Clamp(value, 0.5f, 1f), min, 600f);
				}
				else
				{
					d = Mathf.Clamp(num * 0.01f, 60f, 450f);
				}
			}
			___MyRigidbody.AddRelativeForce(Vector3.forward * d);
		}
	}
}


