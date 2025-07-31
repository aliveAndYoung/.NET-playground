using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    internal class Judge
    {
        public string Decision { get; set; } = "NA";
        public delegate int myHandeler( int[] optionss );
        public event myHandeler _onesNotify;
        public event myHandeler _twosNotify;


        public Queue<int> _onesHistory = new Queue<int>();
        public Queue<int> _twosHistory = new Queue<int>();

        public Judge( Player _one , Player _two , Board _theBoard )
        {
            _onesNotify += _one.GetMove;
            _twosNotify += _two.GetMove;
            Begin( _theBoard , _one.Sign , _two.Sign );
        }
        void Begin( Board _b , char _1 , char _2 )
        {
            while ( true )
            {
                // player 1 turn
                int _1RES = _onesNotify.Invoke( _b.GetFreeNodes() );
                _b.PlaceMove( $"{_1}" , _1RES );
                _onesHistory.Enqueue( _1RES );
                if ( _onesHistory.Count > _b.n )
                {
                    int firstMove = _onesHistory.Dequeue();
                    _b.PlaceMove( $"{firstMove}" , firstMove );
                }
                if ( _b.IsFinished( $"{_1}" ) )
                {
                    Decision = "ONE";
                    break;
                }
                _b.PrintBoard();
                // player 2 turn


                int _2RES = _twosNotify.Invoke( _b.GetFreeNodes() );
                _b.PlaceMove( $"{_2}" , _2RES );
                _twosHistory.Enqueue( _2RES );
                if ( _twosHistory.Count > _b.n )
                {
                    int firstMove = _twosHistory.Dequeue();
                    _b.PlaceMove( $"{firstMove}" , firstMove );
                }
                if ( _b.IsFinished( $"{_2}" ) )
                {
                    Decision = "TWO";
                    break;
                }
                _b.PrintBoard();


            }
        }
    }
}
