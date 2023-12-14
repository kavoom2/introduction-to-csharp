namespace CSharp
{
    public enum CreatureType
    {
        None = 0,
        Player = 1,
        Monster = 2
    }

    class Creature
    {
        protected CreatureType _creatureType = CreatureType.None;
        protected int _hp;
        protected int _attack;

        protected Creature(CreatureType creatureType)
        {
            _creatureType = creatureType;
        }

        public void SetInfo(int hp, int attack)
        {
            _hp = hp;
            _attack = attack;
        }

        public CreatureType GetCreatureType()
        {
            return _creatureType;
        }

        public int GetHp()
        {
            return _hp;
        }

        public int GetAttack()
        {
            return _attack;
        }

        public bool IsDead()
        {
            return _hp == 0;
        }

        public void OnDamaged(int damage)
        {
            _hp -= damage;
            if (_hp < 0)
                _hp = 0;
        }
    }
}
