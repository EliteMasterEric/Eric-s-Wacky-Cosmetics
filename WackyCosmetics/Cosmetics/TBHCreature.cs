using MoreCompany.Cosmetics;

namespace WackyCosmetics.Cosmetics
{
    public class TBHCreature : WackyCosmeticGeneric
    {
        public override string gameObjectPath => "assets/WackyCosmetics/TBHCreature/TBHCreature.prefab";
        public override string cosmeticId => "wackycosmetics.tbhcreature";
        public override string textureIconPath => "assets/WackyCosmetics/TBHCreature/TBHCreature_Icon.png";
        public override string cosmeticName => "TBHCreature";
        public override string assetBundlePath => "WackyCosmetics.cosmetic_tbhcreature";
        
        public override CosmeticType cosmeticType => CosmeticType.HAT;
    }
}