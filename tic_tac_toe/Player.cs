using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    public class Player
    {
        public string Name { get; set; }
        public char Sign { get; set; } = '~';
        
        
//to be used with PC player mode
        //public Player( string _name , char _sign )
        //{
        //    Name = _name ?? "noName?";
        //    Sign = _sign;
        //    Console.WriteLine( $"Player Ready : {Name} ==> {Sign} " );

        //}

        public Player()
        {
            Console.WriteLine( "enter the player's name  :" );
            string _name = Console.ReadLine() ?? "noName?";
            if ( string.IsNullOrEmpty( _name ) )
                _name = "noName";
            Name = _name;

            ChangeSign();
            Console.WriteLine( $"Player Ready : {Name} ==> {Sign} " );
        }

        public int GetMove( int[] options )
        {
            int Move = 0;
            Console.WriteLine( $"{Name}'s :" );
            Console.WriteLine( "available nodes :" );
            StringBuilder choices = new StringBuilder();
            foreach ( int choice in options )
                choices.Append( $"{choice} ," );
            choices.Remove( choices.Length - 1 , 1 );
            Console.WriteLine( choices.ToString() );
            string hisChoice = "NA";
            while ( hisChoice == "NA" )
            {
                string res = Console.ReadLine() ?? "";
                if ( int.TryParse( res , out int parsed ) )
                {
                    for ( int i = 0 ; i < options.Length ; i++ )
                    {
                        if ( options[ i ] == parsed )
                        {
                            Move = parsed;
                            hisChoice = "valid res";
                            break;
                        }
                    }
                    if ( hisChoice == "NA" )
                        Console.WriteLine( "    INVALID INPUT , try again" );
                }
            }
            return Move;
        }
        public void ChangeSign()
        {
            char _sign;
            bool validInput = false;

            do
            {
                Console.WriteLine( $"Enter {Name}'s sign (any non-number character):" );
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                _sign = keyInfo.KeyChar;

                validInput = !char.IsDigit( _sign ) && keyInfo.Key != ConsoleKey.Enter;

                if ( !validInput )
                {
                    Console.WriteLine( "\nInvalid input! Please use a non-number character." );
                }
                else
                {
                    Console.WriteLine(); // Move to next line after valid input
                }
            } while ( !validInput );

            Sign = _sign;
        }
    }
}
