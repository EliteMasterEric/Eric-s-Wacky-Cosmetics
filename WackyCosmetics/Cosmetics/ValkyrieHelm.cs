using MoreCompany.Cosmetics;

namespace WackyCosmetics.Cosmetics
{
    public class ValkyrieHelm : WackyCosmeticGeneric
    {
        public override string gameObjectPath => "assets/WackyCosmetics/ValkyrieHelm/ValkyrieHelm.prefab";
        public override string cosmeticId => "wackycosmetics.valkyriehelm";
        public override string textureIconPath => "assets/WackyCosmetics/ValkyrieHelm/ValkyrieHelm_Icon.png";
        public override string cosmeticName => "ValkyrieHelm";
        
        public override CosmeticType cosmeticType => CosmeticType.HAT;
    }
}