using System.Collections.Generic;

namespace BigReactorSimulator.Tiles
{
    public enum TileType
    {
        // Case textures
        BlockReactorCaseCorner = 1,
        BlockReactorCaseHorizontal = 2,
        BlockReactorCaseVertical = 3,
        BlockReactorControlRod = 4,

        // Conductors
        BlockConductorDiamond = 11,
        BlockConductorGold = 12,
        BlockConductorGraphite = 13,
        BlockConductorAir = 14,

        // Liquids
        LiquidCryotheum = 21,
        LiquidEnder = 22,
        LiquidRedstone = 23
    }

    public static class TileTypeHelper
    {
        private static Dictionary<TileType, string> TypeFileNames;
        private static Dictionary<TileType, string> TypeDisplayNames;

        static TileTypeHelper()
        {
            TypeFileNames = new Dictionary<TileType, string>();

            // Reactor
            TypeFileNames.Add(TileType.BlockReactorCaseCorner, "CaseConnectedCorner.png");
            TypeFileNames.Add(TileType.BlockReactorCaseHorizontal, "CaseConnectedHorizontal.png");
            TypeFileNames.Add(TileType.BlockReactorCaseVertical, "CaseConnectedVertical.png");
            TypeFileNames.Add(TileType.BlockReactorControlRod, "CaseControlRod.png");
            // Conductors
            TypeFileNames.Add(TileType.BlockConductorDiamond, "BlockDiamond.png");
            TypeFileNames.Add(TileType.BlockConductorGold, "BlockGold.png");
            TypeFileNames.Add(TileType.BlockConductorGraphite, "BlockGraphite.png");
            TypeFileNames.Add(TileType.BlockConductorAir, "BlockAir.png");
            // Liquids
            TypeFileNames.Add(TileType.LiquidCryotheum, "LiquidCryotheum.png");
            TypeFileNames.Add(TileType.LiquidEnder, "LiquidEnder.png");
            TypeFileNames.Add(TileType.LiquidRedstone, "LiquidRedstone.png");

            TypeDisplayNames = new Dictionary<TileType, string>();

            // Reactor
            TypeDisplayNames.Add(TileType.BlockReactorCaseCorner, "Connected Case (Corner)");
            TypeDisplayNames.Add(TileType.BlockReactorCaseHorizontal, "Connected Case (Horizontal)");
            TypeDisplayNames.Add(TileType.BlockReactorCaseVertical, "Connected Case (Vertical)");
            TypeDisplayNames.Add(TileType.BlockReactorControlRod, "Control Rod");
            // Conductors
            TypeDisplayNames.Add(TileType.BlockConductorDiamond, "Block of Diamond");
            TypeDisplayNames.Add(TileType.BlockConductorGold, "Block of Gold");
            TypeDisplayNames.Add(TileType.BlockConductorGraphite, "Block of Graphite");
            TypeDisplayNames.Add(TileType.BlockConductorAir, "Air");
            // Liquids
            TypeDisplayNames.Add(TileType.LiquidCryotheum, "Liquid Cryotheum");
            TypeDisplayNames.Add(TileType.LiquidEnder, "Liquid Ender");
            TypeDisplayNames.Add(TileType.LiquidRedstone, "Destabilized Redstone");
        }

        public static string GetFileName(this TileType type)
        {
            return TypeFileNames[type];
        }

        public static string GetReadableName(this TileType type)
        {
            return TypeDisplayNames[type];
        }
    }
}
