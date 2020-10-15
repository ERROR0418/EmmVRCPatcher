using emmVRC.Network;
using emmVRCCustom;
using MelonLoader;
using System.Reflection;

namespace EMMVRCCustomMod
{
    public static class BuildInfo
    {
        public const string Name = "EMMVRCCustomMod"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Just Patching emm."; // Description for the Mod.  (Set as null if none)
        public const string Author = "ERROR#0418"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
        
    }

    public class EMMVRCCustomMod : MelonMod
    {
        public const string BaseURL = "http://127.0.0.1";
        public override void OnLevelIsLoading() // Runs when a Scene is Loading or when a Loading Screen is Shown. Currently only runs if the Mod is used in BONEWORKS.
        {
        }

        public override void OnLevelWasLoaded(int level) // Runs when a Scene has Loaded.
        {
            Patcher.PatchRiskyFuncs();
            // "STREAMER" MODE, need to add toggle in settings.
            //if (emmVRC.emmVRC.Initialized) { 
            //    Patcher.HideButton();
            //}
        }

        public override void OnLevelWasInitialized(int level) // Runs when a Scene has Initialized.
        {
        }

        public override void OnUpdate() // Runs once per frame.
        {
        }

        public override void OnFixedUpdate() // Can run multiple times per frame. Mostly used for Physics.
        {

        }

        public override void OnLateUpdate() // Runs once per frame after OnUpdate and OnFixedUpdate have finished.
        {

        }

        public override void OnGUI() // Can run multiple times per frame. Mostly used for Unity's IMGUI.
        {
        }

        public override void OnApplicationQuit() // Runs when the Game is told to Close.
        {
        }

        public override void OnModSettingsApplied() // Runs when Mod Preferences get saved to UserData/modprefs.ini.
        {
        }

        public override void VRChat_OnUiManagerInit() // Runs upon VRChat's UiManager Initialization. Only runs if the Mod is used in VRChat.
        {
            //Patcher.PatchEmm();
            Patcher.PatchURL();
            MelonLogger.Log(NetworkClient.baseURL);
        }
    }
}
