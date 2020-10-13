using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(EMMVRCCustomMod.BuildInfo.Description)]
[assembly: AssemblyDescription(EMMVRCCustomMod.BuildInfo.Description)]
[assembly: AssemblyCompany(EMMVRCCustomMod.BuildInfo.Company)]
[assembly: AssemblyProduct(EMMVRCCustomMod.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + EMMVRCCustomMod.BuildInfo.Author)]
[assembly: AssemblyTrademark(EMMVRCCustomMod.BuildInfo.Company)]
[assembly: AssemblyVersion(EMMVRCCustomMod.BuildInfo.Version)]
[assembly: AssemblyFileVersion(EMMVRCCustomMod.BuildInfo.Version)]
[assembly: MelonOptionalDependencies("emmVRC", "emmVRC.dll")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(EMMVRCCustomMod.EMMVRCCustomMod), EMMVRCCustomMod.BuildInfo.Name, EMMVRCCustomMod.BuildInfo.Version, EMMVRCCustomMod.BuildInfo.Author, EMMVRCCustomMod.BuildInfo.DownloadLink)]


// Create and Setup a MelonGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonGameAttribute is found or any of the Values for any MelonGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonMame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]