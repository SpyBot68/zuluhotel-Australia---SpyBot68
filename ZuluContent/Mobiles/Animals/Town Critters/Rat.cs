using Server.Scripts.Engines.Loot;

namespace Server.Mobiles
{
    [CorpseName( "a rat corpse" )]
	public class Rat : BaseCreature
	{

		[Constructible]
public Rat() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a rat";
			Body = 238;
			BaseSoundID = 0xCC;

			SetStr( 9 );
			SetDex( 35 );
			SetInt( 5 );

			SetHits( 6 );
			SetMana( 0 );

			SetDamage( 1, 2 );

			SetSkill( SkillName.MagicResist, 4.0 );
			SetSkill( SkillName.Tactics, 4.0 );
			SetSkill( SkillName.Wrestling, 4.0 );

			Fame = 150;
			Karma = -150;

			VirtualArmor = 6;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = -0.9;
		}

		public override void GenerateLoot()
		{
			AddLoot(LootTable.Table1);
		}

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish | FoodType.Eggs | FoodType.GrainsAndHay; } }

		[Constructible]
public Rat(Serial serial) : base(serial)
		{
		}

		public override void Serialize(IGenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(IGenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
