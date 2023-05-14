using System;
using System.Reflection;
using System.Security.Permissions;
using BepInEx;
using IdolShowdown;
using MonoMod.RuntimeDetour.HookGen;

#pragma warning disable CS0618
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618

namespace Tomat.IdolShowdown.WidescreenFix;

[BepInPlugin("dev.tomat.idolshowdown.widescreenfix", "Platforms", "1.0.0")]
public sealed class WidescreenFixPlugin : BaseUnityPlugin {
    private void Awake() {
        HookEndpointManager.Add(
            typeof(SettingsGraphicsHelper).GetMethod(
                nameof(SettingsGraphicsHelper.FigureOutOnWhatScreenResolutionWeAreCurrentlyIn),
                BindingFlags.NonPublic | BindingFlags.Instance
            ),
            AssumeGreatestResolution
        );
    }

    private static void AssumeGreatestResolution(Action<SettingsGraphicsHelper> orig, SettingsGraphicsHelper self) {
        var val = self.resolutionSwitch.GetValue();
        orig(self);

        // We can assume a resolution was found if the value changed.
        if (val != self.resolutionSwitch.GetValue())
            return;

        // Otherwise, assume the greatest resolution.
        // TODO: Search collection for greatest resolution instead of assuming
        // last.
        self.resolutionSwitch.SetValue(self.resolutions.Count - 1);
        self.resolutionSwitch.UpdateOptionLabel();
    }
}
