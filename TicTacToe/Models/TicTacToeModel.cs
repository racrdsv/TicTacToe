namespace TicTacToe.Models
{
    public class TicTacToeModel
    {
        public char[,] Board { get; set; }
        public char CurrentPlayer { get; set; }

        public char OtherPlayer { get; set; }

        public TicTacToeModel()
        {
            Board = new char[3, 3];
            CurrentPlayer = 'X';
            OtherPlayer = 'O';

        }
        
        public bool MakeMove (int row, int column)
        {
            if (Board[row, column] != 'O')
            {
                return false;
            }
            Board[row, column] = CurrentPlayer;

            if (IsGameOver(out char winner))
            {
                OtherPlayer = winner;
                return true;
            }
            CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
            return true;
            
        }
        public bool IsGameOver (out char winner)
        {
            winner = 'O';

            //check rows
            for (int i = 0; i < 3; i++)
            {
                if (Board[i,0] != 'O' && Board[i, 0] == Board[i,1] && Board[i, 1] == Board[i, 2])
                {
                    winner = Board[i,0];
                    return true;
                }
            }
            //check columns
            for (int j = 0; j < 3; j++)
            {
                if (Board[0,j]!='O' && Board[0, j] == Board[1,j] && Board[1,j]== Board[2,j])
                {
                    winner = Board[0, j];
                    return true;
                }
            }

            //check diagonals
            if (Board[0,0]!='O' && Board[0, 0] == Board[1,1] && Board[1, 1] == Board[2,2])
            {
                winner = Board[0, 0];
                return true;
            }

            if (Board[0,2]!='O' && Board[0, 2] == Board[1,1] && Board[1, 1] == Board[2,0])
            {
                winner = Board[0, 2];
                return true;
            }

            //check tie game
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i,j]=='O')
                    {
                        return false;
                    }
                }
            }

            
            return true;
        }
    }
}
