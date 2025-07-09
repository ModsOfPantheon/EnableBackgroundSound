using HarmonyLib;
using Il2Cpp;
using Il2CppTMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace EnableBackgroundSound.Hooks;

[HarmonyPatch(typeof(UISettings), nameof(UISettings.Awake))]
public class UISettingsHooks
{
    public static void Postfix(UISettings __instance)
    {
        if (__instance.transform.childCount < 8)
        {
            return;
        }
        
        var graphicsPage = __instance.transform.GetChild(6).GetChild(0);
        var audioPage = __instance.transform.GetChild(5).GetChild(0);
        var toggle = graphicsPage.GetComponentInChildren<Toggle>(true);

        var copy = Object.Instantiate(toggle, toggle.transform.position, toggle.transform.rotation,
            audioPage.transform);
        
        Object.Destroy(copy.GetComponent<UISettings_ConfigBool>());

        var copyToggle = copy.GetComponent<Toggle>();

        copyToggle.isOn = ModMain.EnableSoundInBackground.Value;
        copyToggle.onValueChanged = new Toggle.ToggleEvent();
        copyToggle.onValueChanged.AddCall(new InvokableCall(new Action(() => ModMain.ToggleChanged(copyToggle.isOn))));

        var text = copyToggle.transform.GetChild(0);
        text.GetComponent<TextMeshProUGUI>().text = "Enable Sound In Background";
    }
}