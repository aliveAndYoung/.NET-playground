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
        public Player( string _name , char _sign )
        {
            Name = _name ?? "noName?";
            Sign = _sign;
            Console.WriteLine( "Player cstor called" );
            Console.WriteLine( $"{Name} ==> {Sign} " );
        }
        public Player()
        {
            Console.WriteLine( "enter the player's name  :" );
            string _name = Console.ReadLine() ?? "noName?";
            if ( string.IsNullOrEmpty( _name ) )
                _name = "noName";
            Name = _name;


            ChangeSign();

            Console.WriteLine( "Player cstor called" );
            Console.WriteLine( $"{Name} ==> {Sign} " );
        }
        public void ChangeSign()
        {
            Console.WriteLine( $"enter {Name}'s used sign  :" );
            char _sign = Console.ReadKey().KeyChar;
            if ( _sign == '\r' )
                _sign = '~';
            //to skip the char line and move the cursor to the next
            Console.WriteLine();
            Sign = _sign;
        }
    }
}
