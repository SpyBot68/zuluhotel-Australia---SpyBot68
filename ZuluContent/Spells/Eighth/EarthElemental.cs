using System.Threading.Tasks;
using Server.Mobiles;

namespace Server.Spells.Eighth
{
    public class EarthElementalSpell : MagerySpell, IAsyncSpell
    {
        public EarthElementalSpell(Mobile caster, Item spellItem) : base(caster, spellItem) { }

        public async Task CastAsync()
        {
            SpellHelper.Summon(new EarthElemental(), Caster, 0x217);
        }
    }
}