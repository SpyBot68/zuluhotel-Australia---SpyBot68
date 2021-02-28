using System;
using MessagePack;
using ZuluContent.Zulu.Engines.Magic.Enums;

namespace ZuluContent.Zulu.Engines.Magic.Enchantments
{
    [MessagePackObject]
    public class ItemQuality : Enchantment<ItemQualityInfo>
    {
        [IgnoreMember] private double m_Value = 0;

        [IgnoreMember] public override string AffixName => string.Empty;

        [Key(1)]
        public double Value
        {
            get => Cursed ? -m_Value : m_Value;
            set => m_Value = value;
        }
        
        public override int CompareTo(object obj) => obj switch
        {
            ItemQuality other => ReferenceEquals(this, other) ? 0 : Value.CompareTo(other.Value),
            null => 1,
            _ => throw new ArgumentException($"Object must be of type {GetType().FullName}")
        };
    }

    public class ItemQualityInfo : EnchantmentInfo
    {
        public override string Description { get; protected set; } = "Quality";
        public override EnchantNameType Place { get; protected set; } = EnchantNameType.Prefix;
        public override int Hue { get; protected set; } = 0;
        public override int CursedHue { get; protected set; } = 0;

        public override string[,] Names { get; protected set; } = { };

        public override string GetName(int index, bool cursed = false, CurseLevelType curseLevel = CurseLevelType.None)
        {
            return string.Empty;
        }
    }
}