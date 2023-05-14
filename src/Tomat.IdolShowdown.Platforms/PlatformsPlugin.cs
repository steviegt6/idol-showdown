using System.Security.Permissions;
using BepInEx;
using MonoMod.RuntimeDetour.HookGen;

#pragma warning disable CS0618
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618

namespace Tomat.IdolShowdown.Platforms;

[BepInPlugin("dev.tomat.idolshowdown.platforms", "Platforms", "1.0.0")]
public sealed class PlatformsPlugin : BaseUnityPlugin {
    private void Awake() {
    }
}
