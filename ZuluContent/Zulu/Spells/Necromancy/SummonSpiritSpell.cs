using System;
using System.Threading.Tasks;
using Server.Mobiles;
using Scripts.Zulu.Engines.Classes;
using Server;
using Server.Spells;

namespace Scripts.Zulu.Spells.Necromancy
{
    public class SummonSpiritSpell : NecromancerSpell, IAsyncSpell
    {
        public SummonSpiritSpell(Mobile caster, Item spellItem) : base(caster, spellItem) { }
        
        public async Task CastAsync()
        {
            var bonus = Caster.GetClassBonus(SkillName.Magery) > 1.0 ? 2 : 0;
            var amount = Utility.Dice(2, 2, bonus);

            for (var i = 0; i < amount; i++)
            {
                var choice = Utility.Dice(1, 8, bonus);

                BaseCreature creature = choice switch
                {
                    <= 4 => new Shade(),
                    <= 7 => new Liche(),
                    <= 9 => new LicheLord(),
                    _ => new Dracoliche()
                };

                SpellHelper.Summon(creature, Caster, 0x22A, null, false);
            }
        }
    }
}