using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public class Game
    {
        public void Start()
        {
            GetMode();
            InitPlayers();
            PrepareBoard();
            while ( true )
            {
                CallJudge();
                EndGame();
                Console.WriteLine( "The Score is" );
                Console.WriteLine( $"{player_1?.Name}({_score1}) : {player_2?.Name}({_score2})" );
                Console.WriteLine( "Press (y) to play again" );
                char stroke = Console.ReadKey().KeyChar;
                if ( stroke != 'y' )
                {
                    break;
                }
            }
        }

        public Game()
        {
            Console.WriteLine( "The Game is about to start ." );
        }

        int _mode = 0;
        int _dim = 0;
        int _score1 = 0;
        int _score2 = 0;


        Player? player_1;
        Player? player_2;
        Board? myBoard;
        Judge? ourJudge;
        public int Dim
        {
            get => _dim;
            set
            {
                if ( value > 2 && value < 7 )
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
            Console.WriteLine( "choose mode : " );
            Console.WriteLine( "1. play a friend " );
            Console.WriteLine( "2. play pc  " );
            while ( _mode == 0 )
            {
                string choice = Console.ReadLine() ?? "0";
                if ( int.TryParse( choice , out int ch ) )
                {
                    Mode = ch;
                }
                else
                { Console.WriteLine( "not a number try again" ); }
            }
            Console.WriteLine( "choose board dimensions" );
            while ( _dim == 0 )
            {
                Console.WriteLine( "pick a numper from 3->6" );
                string choice = Console.ReadLine() ?? "0";

                if ( int.TryParse( choice , out int valid ) )

                    Dim = valid;
                else
                    Console.WriteLine( "invalid input" );
            }
        }

        public void PrepareBoard()
        {

            myBoard = new Board( Dim );
            myBoard.PrintBoard();
        }

        public void InitPlayers()
        {
            player_1 = new Player();

            if ( _mode == 1 )
            {
                player_2 = new Player();
            }
            else
            {
                //yet to implement the pc player class  
                player_2 = new Player();
            }
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

        }

        public void CallJudge()
        {
            if ( player_1 != null && player_2 != null && myBoard != null )
            {
                ourJudge = new Judge( player_1 , player_2 , myBoard );
            }
            else
            {
                Console.WriteLine( "some error has occured " );
            }

        }

        public void EndGame()
        {
            string winner = ( ourJudge?.Decision ) == "ONE" ? player_1?.Name ?? "one" : player_2?.Name ?? "two";
            if ( ( ourJudge?.Decision ) == "ONE" )
                _score1++;
            else
                _score2++;
            Console.WriteLine( $"player {ourJudge?.Decision ?? "WTF!"} won" );
            Console.WriteLine( $"CONGRATS {winner} " );


        }
    }
}
