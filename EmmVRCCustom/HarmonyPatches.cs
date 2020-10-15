using emmVRC.Menus;
using emmVRC.Network;
using EMMVRCCustomMod;
using Harmony;
using Il2CppSystem;
using MelonLoader;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRC.SDKBase;

namespace EmmVRCCustom
{
    class HarmonyPatches
    {
        [HarmonyPrefix]
        public static bool SetRiskyFunctions()
        {
                PlayerTweaksMenu.WaypointMenu.getGameObject().GetComponent<Button>().enabled = true;
                PlayerTweaksMenu.FlightToggle.getGameObject().GetComponent<Button>().enabled = true;
                PlayerTweaksMenu.NoclipToggle.getGameObject().GetComponent<Button>().enabled = true;
                PlayerTweaksMenu.SpeedToggle.getGameObject().GetComponent<Button>().enabled = true;
                PlayerTweaksMenu.ESPToggle.getGameObject().GetComponent<Button>().enabled = true;
                PlayerTweaksMenu.SpeedSlider.slider.GetComponent<Slider>().enabled = true;
                PlayerTweaksMenu.SpeedText.GetComponent<Text>().text = "Speed: Disabled";
                PlayerTweaksMenu.EnableJumpButton.getGameObject().GetComponent<Button>().enabled = true;
            return false;
        }

        [HarmonyPrefix]
        public static bool get_baseURL(ref string __result)
        {
            __result = EMMVRCCustomMod.EMMVRCCustomMod.BaseURL;
            MelonLogger.Log("Base URL requested, patched into " + __result);
            return false;
        }

        [HarmonyPostfix]
        public static void ProcessAvatar(GameObject avatarObject, VRC_AvatarDescriptor avatarDescriptor)
        {
            try 
            {

                

            }
            catch (System.Exception ex) {
                MelonLogger.LogError(ex.ToString());
            }

        }
    }
}
