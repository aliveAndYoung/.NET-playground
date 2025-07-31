using System;
using System.Linq;

namespace tic_tac_toe
{
    class Board
    {
        public int n;
        private string[] myBoard;

        public Board( int size = 3 )
        {
            n = size;
            myBoard = Enumerable.Range( 1 , n * n ).Select( i => i.ToString() ).ToArray();
        }

        public void PrintBoard()
        {
            int maxCellWidth = myBoard.Max( c => c.Length ) + 2;
            string horizontalBorder = "+" + string.Join( "+" , Enumerable.Repeat( new string( '-' , maxCellWidth ) , n ) ) + "+";

            Console.WriteLine( horizontalBorder );
            for ( int row = 0 ; row < n ; row++ )
            {
                Console.Write( "|" );
                for ( int col = 0 ; col < n ; col++ )
                {
                    string cell = $" {myBoard[ row * n + col ]} ";
                    Console.Write( cell.PadRight( maxCellWidth ) + "|" );
                }
                Console.WriteLine();
                Console.WriteLine( horizontalBorder );
            }
        }

        public bool IsFinished( string player )
        {
            return CheckRows( player ) || CheckColumns( player ) || CheckDiagonals( player );
        }

        public bool PlaceMove( string playerSymbol , int nodeNumber )
        {
            if ( nodeNumber < 1 || nodeNumber > n * n )
                return false;
            int index = nodeNumber - 1;
            //if ( myBoard[ index ] != ( index + 1 ).ToString() )
            //    return false;
            myBoard[ index ] = playerSymbol;
            return true;
        }

        public int[] GetFreeNodes()
        {
            return Enumerable.Range( 0 , n * n )
                           .Where( i => myBoard[ i ] == ( i + 1 ).ToString() )
                           .Select( i => i + 1 )
                           .ToArray();
        }

        private bool CheckRows( string player )
        {
            for ( int row = 0 ; row < n ; row++ )
                if ( Enumerable.Range( 0 , n ).All( col => myBoard[ row * n + col ] == player ) )
                    return true;
            return false;
        }

        private bool CheckColumns( string player )
        {
            for ( int col = 0 ; col < n ; col++ )
                if ( Enumerable.Range( 0 , n ).All( row => myBoard[ row * n + col ] == player ) )
                    return true;
            return false;
        }

        private bool CheckDiagonals( string player )
        {
            bool main = Enumerable.Range( 0 , n ).All( i => myBoard[ i * n + i ] == player );
            bool anti = Enumerable.Range( 0 , n ).All( i => myBoard[ i * n + ( n - 1 - i ) ] == player );
            return main || anti;
        }
    }
}