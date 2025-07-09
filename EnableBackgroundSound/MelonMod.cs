using MelonLoader;

namespace EnableBackgroundSound;

public class ModMain : MelonMod
{
    public static MelonPreferences_Entry<bool> EnableSoundInBackground;
    public const string PluginVersion = "1.0.0";

    public override void OnInitializeMelon()
    {
        var section = MelonPreferences.CreateCategory("EnableBackgroundSound");
        EnableSoundInBackground = section.CreateEntry("EnableSoundInBackground", true);

        section.SaveToFile(false);
    }

    public static void ToggleChanged(bool b)
    {
        EnableSoundInBackground.Value = b;

        EnableSoundInBackground.Category.SaveToFile(false);
    }
}