using MoreCompany.Cosmetics;

namespace WackyCosmetics.Cosmetics
{
    public class Maxwell : WackyCosmeticGeneric
    {
        public override string gameObjectPath => "assets/WackyCosmetics/Maxwell/Maxwell.prefab";
        public override string cosmeticId => "wackycosmetics.maxwell";
        public override string textureIconPath => "assets/WackyCosmetics/Maxwell/Maxwell_Icon.png";
        public override string cosmeticName => "Maxwell";
        
        public override CosmeticType cosmeticType => CosmeticType.HAT;
    }
}