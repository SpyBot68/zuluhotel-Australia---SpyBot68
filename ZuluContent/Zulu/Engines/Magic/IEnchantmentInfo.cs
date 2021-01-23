using System;
using System.Collections.Generic;
using ZuluContent.Zulu.Engines.Magic.Enums;

namespace ZuluContent.Zulu.Engines.Magic
{
    public interface IEnchantmentInfo
    {
        public static readonly string[,] DefaultElementalProtectionNames =
        {
            {string.Empty, string.Empty},
            {"Bane", "Weakness"},
            {"Warding", "Vulnerability"},
            {"Protection", "Amplification"},
            {"Immunity", "Defenselessness"},
            {"Attunement", "Exposure"},
            {"Absorbsion", "Endangerment"},
        };

        string Description { get; }
        EnchantNameType Place { get; }
        string[,] Names { get; }
        int Hue { get; }
        int CursedHue { get; }
        string GetName(int index, bool cursed = false, CurseLevelType curseLevel = CurseLevelType.None);
        string GetName(Enum target, bool cursed = false, CurseLevelType curseLevel = CurseLevelType.None);
    }
}