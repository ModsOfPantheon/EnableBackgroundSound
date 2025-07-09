using HarmonyLib;
using Il2Cpp;

namespace EnableBackgroundSound.Hooks;

[HarmonyPatch(typeof(AkSoundEngine), nameof(AkSoundEngine.Suspend))]
public class AkSoundEngineHook
{
    private static bool Prefix(AkSoundEngine __instance, ref bool in_bRenderAnyway)
    {
        return !ModMain.EnableSoundInBackground.Value;
    }
}