using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public class Game
    {
        public Game()
        {
            Console.WriteLine( "The Game Started ." );
        }

        int _mode = 0;
        int _dim = 0;
        public int Dim
        {
            get => _dim;
            set
            {
                if ( value > 0 && value < 7 )
                    _dim = value;
                else
                    Console.WriteLine( "invalid Dimension" );
            }
        }

        public int Mode
        {
            get => _mode;
            set
            {
                if ( value < 1 || value > 2 )
                {
                    Console.WriteLine( "invalid option try again " );
                    return;
                }
                _mode = value;
            }
        }

        void GetMode()
        {
            Console.WriteLine( " choose mode : " );
            Console.WriteLine( "  1. play a friend " );
            Console.WriteLine( "  2. play pc  " );
            while ( _mode == 0 )
            {
                string choice = Console.ReadLine() ?? "0";
                if ( int.TryParse( choice , out int ch ) )
                {
                    Console.WriteLine( $"you choosed {ch} " );
                    Mode = ch;
                }
                else
                { Console.WriteLine( "not a number try again" ); }
            }
            Console.WriteLine( "choose board dimensions" );
            while ( _dim == 0 )
            {
                Console.WriteLine( "pick a numper from 1->6" );
                string choice = Console.ReadLine() ?? "0";

                if ( int.TryParse( choice , out int valid ) )

                    Dim = valid;
                else
                    Console.WriteLine( "invalid input" );
            }
        }

        public void Start()
        {
            GetMode();
            Player player_1 = new Player();
            //Player player_2 = new Player( "PC" , '~' );
            Player player_2 = new Player();

            while ( player_1.Sign == player_2.Sign )
            {
                Console.WriteLine( "Cannot use the same sign for both players" );

                if ( player_2.Name != "PC" )
                    player_2.ChangeSign();
                else
                    player_1.ChangeSign();
            }
           
            Console.WriteLine( "LET'S START" );
            Console.WriteLine( $" {player_1.Name}({player_1.Sign})  VS  {player_2.Name}({player_2.Sign}) " );

            Board board_1 = new Board( Dim );
            board_1.PrintBoard();

/// trivial solution VS ==> event driven implementaion <==




        }
    }
}
