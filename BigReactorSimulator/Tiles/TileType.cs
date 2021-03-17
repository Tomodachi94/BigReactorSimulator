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
        public static string GetReactorName(this TileType type)
        {
            switch (type)
            {
                case TileType.BlockReactorCaseCorner:
                    return "CaseConnectedCorner";
                case TileType.BlockReactorCaseHorizontal:
                    return "CaseConnectedHorizontal";
                case TileType.BlockReactorCaseVertical:
                    return "CaseConnectedVertical";
                case TileType.BlockReactorControlRod:
                    return "CaseControlRod";
            }
            return null;
        }

        public static string GetConductorName(this TileType type)
        {
            switch (type)
            {
                case TileType.BlockConductorDiamond:
                    return "BlockDiamond";
                case TileType.BlockConductorGold:
                    return "BlockGold";
                case TileType.BlockConductorGraphite:
                    return "BlockGraphite";
                case TileType.BlockConductorAir:
                    return "BlockAir";
            }
            return null;
        }

        public static string GetLiquidName(this TileType type)
        {
            switch (type)
            {
                case TileType.LiquidCryotheum:
                    return "LiquidCryotheum";
                case TileType.LiquidEnder:
                    return "LiquidEnder";
                case TileType.LiquidRedstone:
                    return "LiquidRedstone";
            }
            return null;
        }
    }
}
