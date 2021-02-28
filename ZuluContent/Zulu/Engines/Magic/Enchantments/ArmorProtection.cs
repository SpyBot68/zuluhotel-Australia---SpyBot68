using System;
using MessagePack;
using Server.Items;
using ZuluContent.Zulu.Engines.Magic.Enums;

namespace ZuluContent.Zulu.Engines.Magic.Enchantments
{
    [MessagePackObject]
    public class ArmorProtection : Enchantment<ArmorProtectionInfo>
    {
        [IgnoreMember]
        private ArmorProtectionLevel m_Value = ArmorProtectionLevel.Regular;

        [IgnoreMember] 
        public override string AffixName => EnchantmentInfo.GetName(Value, Cursed, CurseLevel);

        [Key(1)] 
        public ArmorProtectionLevel Value
        {
            get => Cursed ? (ArmorProtectionLevel)(ArmorProtectionLevel.Regular - m_Value) : m_Value;
            set => m_Value = value;
        }
        
        public override int CompareTo(object obj) => obj switch
        {
            ArmorProtection other => ReferenceEquals(this, other) ? 0 : m_Value.CompareTo(other.m_Value),
            null => 1,
            _ => throw new ArgumentException($"Object must be of type {GetType().FullName}")
        };
    }
    
    public class ArmorProtectionInfo : EnchantmentInfo
    {
        public override string Description { get; protected set; } = "Armor Protection";
        public override EnchantNameType Place { get; protected set; } = EnchantNameType.Suffix;
        public override int Hue { get; protected set; } = 0;
        public override int CursedHue { get; protected set; } = 0;
        public override string[,] Names { get; protected set; } = new[,]
        {
            {string.Empty, string.Empty},
            {"Defense", "Penetration"},
            {"Guarding", "Vulnerability"},
            {"Hardening", "Disharmony"},
            {"Fortification", "Distress"},
            {"Invulnerability", "Disaster"},
            {"Invincibility", "Catastrophe"},
        };
    }
    

}