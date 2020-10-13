using System;
using System.Reflection;
using emmVRC;
using emmVRC.Managers;
using emmVRC.Menus;
using emmVRC.Network;
using MelonLoader;
using UnityEngine.UI;

namespace emmVRCCustom
{
	// Token: 0x0200000B RID: 11
	public static class Patcher
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00002FCC File Offset: 0x000011CC
		public static void PatchEmm()
		{
			MelonLogger.Log("Patching EMMVRC URL's -- ERROR#0418");
			try
			{
				FieldInfo field = typeof(NetworkClient).GetField("BaseAddress", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
				field.SetValue(typeof(NetworkClient), "http://127.0.0.1");
				MelonLogger.Log("Base Address: " + field.GetValue(null));
				MelonLogger.Log("Base URL: " + NetworkClient.baseURL);
				MelonLogger.Log("Patching Complete!");
			}
			catch (Exception)
			{
				MelonLogger.Log("Patching Failed! New version changed addresses?");
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003064 File Offset: 0x00001264
		public static void PatchRiskyFuncs()
		{
			try
			{
				if (!RiskyFunctionsManager.RiskyFunctionsAllowed)
				{
					MelonLogger.Log("Patching EMMVRC RiskyFuncs -- ERROR#0418");
					Configuration.JSONConfig.RiskyFunctionsEnabled = false;
					MelonLogger.Log("Have stopped checks? maybe?");
					RiskyFunctionsManager.RiskyFunctionsChecked = true;
					MelonLogger.Log("Risky funcs are " + (RiskyFunctionsManager.RiskyFunctionsAllowed ? "Allowed" : "Denied"));
					MelonLogger.Log("Patching... ");
					typeof(RiskyFunctionsManager).GetField("<RiskyFunctionsAllowed>k__BackingField", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).SetValue(typeof(RiskyFunctionsManager), true);
					MelonLogger.Log("Risky funcs are now " + (RiskyFunctionsManager.RiskyFunctionsAllowed ? "Allowed" : "Denied"));
					PlayerTweaksMenu.WaypointMenu.getGameObject().GetComponent<Button>().enabled = true;
					PlayerTweaksMenu.FlightToggle.getGameObject().GetComponent<Button>().enabled = true;
					PlayerTweaksMenu.NoclipToggle.getGameObject().GetComponent<Button>().enabled = true;
					PlayerTweaksMenu.SpeedToggle.getGameObject().GetComponent<Button>().enabled = true;
					PlayerTweaksMenu.ESPToggle.getGameObject().GetComponent<Button>().enabled = true;
					PlayerTweaksMenu.SpeedSlider.slider.GetComponent<Slider>().enabled = true;
					PlayerTweaksMenu.SpeedText.GetComponent<Text>().text = "Speed: Disabled";
					PlayerTweaksMenu.EnableJumpButton.getGameObject().GetComponent<Button>().enabled = true;
				}
			}
			catch (Exception)
			{
				MelonLogger.Log("Patching Failed! New version changed addresses?");
			}
		}
	}
}
