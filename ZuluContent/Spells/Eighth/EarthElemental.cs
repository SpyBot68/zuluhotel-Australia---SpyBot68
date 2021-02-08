using System;
using Server.Mobiles;

namespace Server.Spells.Eighth
{
    public class EarthElementalSpell : MagerySpell
    {
        public EarthElementalSpell(Mobile caster, Item scroll) : base(caster, scroll)
        {
        }

        public override bool CheckCast()
        {
            if (!base.CheckCast())
                return false;

            return true;
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                var duration = TimeSpan.FromSeconds(2 * Caster.Skills.Magery.Fixed / 5);

                SpellHelper.Summon(new EarthElemental(), Caster, 0x217, duration, false, false);
            }

            FinishSequence();
        }
    }
}