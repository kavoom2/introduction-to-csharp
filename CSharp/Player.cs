namespace CSharp
{
    public enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3
    }

    class Player : Creature
    {
        protected PlayerType _playerType = PlayerType.None;

        protected Player(PlayerType playerType)
            : base(CreatureType.Player)
        {
            _playerType = playerType;
        }

        public PlayerType GetPlayerType()
        {
            return _playerType;
        }
    }

    class Knight : Player
    {
        public Knight()
            : base(PlayerType.Knight)
        {
            SetInfo(100, 10);
        }
    }

    class Archer : Player
    {
        public Archer()
            : base(PlayerType.Archer)
        {
            SetInfo(75, 12);
        }
    }

    class Mage : Player
    {
        public Mage()
            : base(PlayerType.Mage)
        {
            SetInfo(50, 15);
        }
    }
}
