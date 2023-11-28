using MoreCompany.Cosmetics;

namespace WackyCosmetics.Cosmetics
{
    public class BurningFlamesTeamCaptain : WackyCosmeticGeneric
    {
        public override string gameObjectPath => "assets/WackyCosmetics/BurningFlamesTeamCaptain/BurningFlamesTeamCaptain.prefab";
        public override string cosmeticId => "wackycosmetics.burningflamesteamcaptain";
        public override string textureIconPath => "assets/WackyCosmetics/BurningFlamesTeamCaptain/BurningFlamesTeamCaptain_Icon.png";
        public override string cosmeticName => "Burning Flames Team Captain";

        public override CosmeticType cosmeticType => CosmeticType.HAT;
    }
}