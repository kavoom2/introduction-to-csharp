namespace CSharp
{
    public enum MonsterType
    {
        None = 0,
        Slime = 1,
        Orc = 2,
        Skeleton = 3
    }

    class Monster : Creature
    {
        protected MonsterType _monsterType = MonsterType.None;

        protected Monster(MonsterType MonsterType)
            : base(CreatureType.Monster)
        {
            _monsterType = MonsterType;
        }

        public MonsterType GetMonsterType()
        {
            return _monsterType;
        }
    }

    class Slime : Monster
    {
        public Slime()
            : base(MonsterType.Slime)
        {
            SetInfo(10, 3);
        }
    }

    class Orc : Monster
    {
        public Orc()
            : base(MonsterType.Orc)
        {
            SetInfo(20, 6);
        }
    }

    class Skeleton : Monster
    {
        public Skeleton()
            : base(MonsterType.Skeleton)
        {
            SetInfo(15, 8);
        }
    }
}
