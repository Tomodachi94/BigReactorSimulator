using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BigReactorSimulator.Tiles;

namespace BigReactorSimulator.Resources
{
    public static class TextureHelper
    {
        private static Dictionary<TileType, ImageSource> Textures;

        static TextureHelper()
        {
            Textures = new Dictionary<TileType, ImageSource>(11);
        }

        public static string GetPathInBlocks(string directoryInBlocks)
        {
            string blocksDirectory = ResourceLocator.GetInResource(Path.Combine("Textures", "Blocks"));
            return Path.Combine(blocksDirectory, directoryInBlocks);
        }

        public static string GetPathInLiquid(string pathInLiquid)
        {
            string liquidDirectory = ResourceLocator.GetInResource(Path.Combine("Textures", "Liquids"));
            return Path.Combine(liquidDirectory, pathInLiquid);
        }

        public static string GetConductor(TileType type)
        {
            return Path.Combine(GetPathInBlocks("Conductors"), GetFileName(type.GetConductorName()));
        }

        public static string GetReactor(TileType type)
        {
            return Path.Combine(GetPathInBlocks("Reactor"), GetFileName(type.GetReactorName()));
        }

        public static string GetLiquid(TileType type)
        {
            return GetPathInLiquid(GetFileName(type.GetLiquidName()));
        }

        private static string GetFileName(string file)
        {
            return file + ".png";
        }

        public static void LoadTextures()
        {
            Textures.Add(TileType.BlockReactorCaseCorner,       new BitmapImage(new Uri(GetReactor(TileType.BlockReactorCaseCorner))));
            Textures.Add(TileType.BlockReactorCaseHorizontal,   new BitmapImage(new Uri(GetReactor(TileType.BlockReactorCaseHorizontal))));
            Textures.Add(TileType.BlockReactorCaseVertical,     new BitmapImage(new Uri(GetReactor(TileType.BlockReactorCaseVertical))));
            Textures.Add(TileType.BlockReactorControlRod,       new BitmapImage(new Uri(GetReactor(TileType.BlockReactorControlRod))));
            Textures.Add(TileType.BlockConductorDiamond,        new BitmapImage(new Uri(GetConductor(TileType.BlockConductorDiamond))));
            Textures.Add(TileType.BlockConductorGold,           new BitmapImage(new Uri(GetConductor(TileType.BlockConductorGold))));
            Textures.Add(TileType.BlockConductorGraphite,       new BitmapImage(new Uri(GetConductor(TileType.BlockConductorGraphite))));
            Textures.Add(TileType.BlockConductorAir,            new BitmapImage(new Uri(GetConductor(TileType.BlockConductorAir))));
            Textures.Add(TileType.LiquidCryotheum,              new BitmapImage(new Uri(GetLiquid(TileType.LiquidCryotheum))));
            Textures.Add(TileType.LiquidEnder,                  new BitmapImage(new Uri(GetLiquid(TileType.LiquidEnder))));
            Textures.Add(TileType.LiquidRedstone,               new BitmapImage(new Uri(GetLiquid(TileType.LiquidRedstone))));
        }

        public static ImageSource GetTileTexture(TileType type)
        {
            switch (type)
            {
                // Reactor
                case TileType.BlockReactorCaseCorner:
                case TileType.BlockReactorCaseHorizontal:
                case TileType.BlockReactorCaseVertical:
                case TileType.BlockReactorControlRod:
                    if (!Textures.ContainsKey(type))
                        Textures.Add(type, new BitmapImage(new Uri(GetReactor(type))));
                    return Textures[type];

                // Conductors
                case TileType.BlockConductorDiamond:
                case TileType.BlockConductorGold:
                case TileType.BlockConductorGraphite:
                case TileType.BlockConductorAir:
                    if (!Textures.ContainsKey(type))
                        Textures.Add(type, new BitmapImage(new Uri(GetConductor(type))));
                    return Textures[type];

                // Liquids
                case TileType.LiquidCryotheum:
                case TileType.LiquidEnder:
                case TileType.LiquidRedstone:
                    if (!Textures.ContainsKey(type))
                        Textures.Add(type, new BitmapImage(new Uri(GetLiquid(type))));
                    return Textures[type];
            }

            return null;
        }
    }
}
