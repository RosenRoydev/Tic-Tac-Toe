using System.Data;
using System.Runtime.CompilerServices;

char[,] ticTacToe = new char[,]
{
  {'_','_','_' },
  {'_','_','_' },
  {'_','_','_' }
};
PrintTicTacToe(ticTacToe);

int player = 1;

while (true)
{
    Console.WriteLine($"Player {(player == 1? 'X' :'O')} is on move: ");
    Console.Write("ROW: (only one digit form 0-9)");
    int row = int.Parse(Console.ReadLine());
    

    Console.Write("COL: (only one digit form 0-9)");
    int col = int.Parse(Console.ReadLine());
    

    if (row < 0 || row >= ticTacToe.GetLength(0) || col < 0 || col > ticTacToe.GetLength(1) || ticTacToe[row,col] !='_')
    {
        Console.WriteLine("INVALID COORDINATES");
        continue;
    }

    char symbol = 'X';
    if (player == -1)
    {
        symbol = 'O';
    }
    
    ticTacToe[row, col] = symbol;
    Console.Clear();
    PrintTicTacToe(ticTacToe);
    
    if (CheckDiagonals(ticTacToe,symbol) || CheckHorizontals (ticTacToe,symbol) || CheckVerticals(ticTacToe,symbol) )
    {
        Console.WriteLine($"Player {symbol} won the game");
        Console.WriteLine("Congatulations!!!");
        break;
    }

    player *= -1 ;

}

static void PrintTicTacToe(char[,] ticTacToe)
{
    Console.WriteLine("You play Tic-Tac-Toe");
    for (int row = 0; row < ticTacToe.GetLength(0); row++)
    {
        for (int col = 0; col < ticTacToe.GetLength(1); col++)
        {
            Console.Write($"{ticTacToe[row, col]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

 static bool CheckHorizontals(char[,] ticTacToe, char symbol)
{
    for (int row = 0; row < ticTacToe.GetLength(0); row++)
    {
        bool isWinner = true;
        for (int col = 0; col < ticTacToe.GetLength(1); col++)
        {
            if (ticTacToe[row,col]!= symbol)
            {
                return false;
                break;
            }
            
        }
        if (isWinner == true)
        {
            return true;
        }   
        
    }
    return false;

}

static bool CheckVerticals(char[,] ticTacToe, char symbol)
{
    for (int col = 0; col < ticTacToe.GetLength(0); col++)
    {
        bool isWinner = true;
        for (int row = 0; row < ticTacToe.GetLength(1); row++)
        {
            if (ticTacToe[row, col] != symbol)
            {
                return false;
                break;
            }

        }
        if (isWinner == true)
        {
            return true;
        }

    }
    return false;

}
static bool CheckDiagonals(char[,] ticTacToe , char symbol)
{
    bool isWinner = true;
    for (int row = 0; row < ticTacToe.GetLength(0); row++)
    {
        
        if (ticTacToe[row,row] != symbol)
        {
            isWinner = false;
            break;
        }
    }
    if (isWinner)
    {
        return true;
    }
    return false;
    isWinner = true;
    for (int row = 0; row < ticTacToe.GetLength(0); row++)
    {

        if (ticTacToe[ticTacToe.GetLength(0) - row  -  1, row] != symbol)
        {
            isWinner = false;
            break;
        }
    }
    return isWinner;

}