using MoreCompany.Cosmetics;

namespace WackyCosmetics.Cosmetics
{
    public class ToweringPillarOfHats : WackyCosmeticGeneric
    {
        public override string gameObjectPath => "assets/WackyCosmetics/ToweringPillarOfHats/ToweringPillarOfHats.prefab";
        public override string cosmeticId => "wackycosmetics.toweringpillarofhats";
        public override string textureIconPath => "assets/WackyCosmetics/ToweringPillarOfHats/ToweringPillarOfHats_Icon.png";
        public override string cosmeticName => "Towering Pillar of Hats";
        
        public override CosmeticType cosmeticType => CosmeticType.HAT;
    }
}