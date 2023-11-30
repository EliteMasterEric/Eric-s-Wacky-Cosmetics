using MoreCompany.Cosmetics;

namespace WackyCosmetics.Cosmetics
{
    public class OSCAR : WackyCosmeticGeneric
    {
        public override string gameObjectPath => "assets/WackyCosmetics/OSCAR/OSCAR.prefab";
        public override string cosmeticId => "wackycosmetics.oscar";
        public override string textureIconPath => "assets/WackyCosmetics/OSCAR/OSCAR_Icon.png";
        public override string cosmeticName => "OSCAR";
        public override string assetBundlePath => "WackyCosmetics.cosmetic_oscar";
        
        public override CosmeticType cosmeticType => CosmeticType.HAT;
    }
}