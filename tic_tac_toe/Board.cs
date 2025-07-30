using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    class Board
    {
        private int n;
        private char[] myBoard;

        public Board( int size = 3 )
        {
            n = size;
            myBoard = Enumerable.Range( 1 ,  n * n )
                            .Select( i => i <= 9 ? i.ToString()[ 0 ] : ( char )( 'A' + i - 10 ) )
                            .ToArray();
        }
        public void PrintBoard()
        {
            int cellWidth = ( n * n ).ToString().Length + 2; 

            // Print top border
            Console.WriteLine( new string( '-' , n * ( cellWidth + 1 ) + 1 ) );

            for ( int row = 0 ; row < n ; row++ )
            {
                Console.Write( "|" );
                for ( int col = 0 ; col < n ; col++ )
                {
                    int index = row * n + col;
                    // Center-align each cell with padding
                    Console.Write( $" {myBoard[ index ].ToString().PadRight( cellWidth - 1 )}|" );
                }
                Console.WriteLine();

                // Print row separator
                if ( row < n - 1 )
                {
                    Console.WriteLine( new string( '-' , n * ( cellWidth + 1 ) + 1 ) );
                }
            }

            // Print bottom border
            Console.WriteLine( new string( '-' , n * ( cellWidth + 1 ) + 1 ) );
        }
    

    
    }
}
