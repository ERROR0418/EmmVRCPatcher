using System;
using System.IO;
using System.Reflection;
using emmVRC;
using emmVRC.Libraries;
using emmVRC.Managers;
using emmVRC.Menus;
using emmVRC.Network;
using EmmVRCCustom;
using Harmony;
using MelonLoader;
using UnityEngine.UI;
using VRC.Core;

namespace emmVRCCustom
{
	// Token: 0x0200000B RID: 11
	public static class Patcher
	{

		public static void HideButton()
		{
			//MelonLogger.Log("Hiding button ;)");
			UnityEngine.Object.Destroy(QuickMenuUtils.GetQuickMenuInstance().transform.Find("ShortcutMenu/ReportWorldButton").gameObject);
			FunctionsMenu.baseMenu.menuName = "Report World";
			FunctionsMenu.baseMenu.menuEntryButton.setButtonText("Report\nWorld");
			FunctionsMenu.baseMenu.menuEntryButton.setToolTip("Report Issues with this World");
			FunctionsMenu.baseMenu.menuEntryButton.setLocation(1, -1);
		}

        public static void PatchURL()
        {
			MelonLogger.Log("Patching baseURL");
			try
			{
				HarmonyInstance harmony = HarmonyInstance.Create("CustomPatch.baseURL");
				MethodInfo original = typeof(emmVRC.Network.NetworkClient).GetMethod("get_baseURL");
				MethodInfo patch = typeof(HarmonyPatches).GetMethod("get_baseURL");
				harmony.Patch(original, prefix: new HarmonyMethod(patch));
			}
			catch (Exception)
			{
				MelonLogger.Log("Patching Failed! New version changed addresses?");
			}
		}

        // Token: 0x0600003E RID: 62 RVA: 0x00002FCC File Offset: 0x000011CC
        public static void PatchEmm()
		{
			MelonLogger.Log("Patching AvatarProcess()");
            try
            {
				HarmonyInstance harmony = HarmonyInstance.Create("CustomPatch.Avatars");
				MethodInfo original = typeof(emmVRC.Managers.AvatarPermissionManager).GetMethod("ProcessAvatar");
				MethodInfo patch = typeof(HarmonyPatches).GetMethod("ProcessAvatar");
				harmony.Patch(original, postfix: new HarmonyMethod(patch));
			}
			catch(Exception ex)
            {
				MelonLogger.LogError(ex.ToString());
            }
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003064 File Offset: 0x00001264
		public static void PatchRiskyFuncs()
		{
			MelonLogger.Log("Patching SetRiskyFunctions()");
			try
			{
				HarmonyInstance harmony = HarmonyInstance.Create("CustomPatch.Risky");
				MethodInfo original = typeof(emmVRC.Menus.PlayerTweaksMenu).GetMethod("SetRiskyFunctions");
				MethodInfo patch = typeof(HarmonyPatches).GetMethod("SetRiskyFunctions");
				harmony.Patch(original, prefix: new HarmonyMethod(patch));
			}
			catch (Exception)
			{
				MelonLogger.Log("Patching Failed! New version changed addresses?");
			}
		}
	}
}
