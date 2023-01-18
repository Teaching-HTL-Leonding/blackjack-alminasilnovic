//der spieler hat am anfang 100 euro
//der spieler hat gewonnen wenn: der computer card value grösser als 21 ist oder spieler card value grösser als computer card value ist
//der computer hat gewonnen wenn: der spieler card value grösser als 21 ist oder computer card value grösser als spieler card value ist
//handoutrandomcard hört auf wenn cardvalue grösser als 21 ist oder er freiwillig sagt dass er aufhören möchte
//computerrandomcard hört auf wenn computercardvalue grösser als 16 ist
//


Console.Clear();

string card = "0";
int cardvalue = 0;
int playermoney = 100;
bool ContinuePlaying = true;
int bet = 0;
string input;
int dealercardvalue = 0;
string dealercard = "0";
int oldcardvalue = 0;
int olddealercardvalue;
bool PlayerWins = false;
bool DealerWins = true;
const int MINIMUM_BET = 10;
bool MoneyDoubled = false;
int round = 0;

void NewRound()
{
    round++;
}
void PrintWelcome()
{
    System.Console.WriteLine("*** WELCOME TO BLACKJACK ***");
    System.Console.WriteLine();
    System.Console.WriteLine("You have 100€ in your pocket. Try to double it!");
    System.Console.WriteLine("You will lose if you have no money left");
    System.Console.WriteLine();
}
void PrintRound()
{
    System.Console.WriteLine($"*** ROUND {round}, you have {playermoney}$ left. ***");
    System.Console.WriteLine();

}
void HandoutRandomPlayerCard()
{
    if (ContinuePlaying)
    {
        oldcardvalue = cardvalue;
        cardvalue = Random.Shared.Next(1, 14);
        switch (cardvalue)
        {
            case 1:
                card = "Ace";
                break;
            case 2:
                card = "2";
                break;
            case 3:
                card = "3";
                break;
            case 4:
                card = "4";
                break;
            case 5:
                card = "5";
                break;
            case 6:
                card = "6";
                break;
            case 7:
                card = "7";
                break;
            case 8:
                card = "8";
                break;
            case 9:
                card = "9";
                break;
            case 10:
                card = "10";
                break;
            case 11:
                card = "Jack";
                break;
            case 12:
                card = "Queen";
                break;
            case 13:
                card = "King";
                break;
            default:
                break;
        }
    }
    cardvalue += oldcardvalue;
}
void HandoutRandomDealerCard()
{
    olddealercardvalue = dealercardvalue;
    dealercardvalue = Random.Shared.Next(1, 14);
    switch (dealercardvalue)
    {
        case 1:
            dealercard = "Ace";
            break;
        case 2:
            dealercard = "2";
            break;
        case 3:
            dealercard = "3";
            break;
        case 4:
            dealercard = "4";
            break;
        case 5:
            dealercard = "5";
            break;
        case 6:
            dealercard = "6";
            break;
        case 7:
            dealercard = "7";
            break;
        case 8:
            dealercard = "8";
            break;
        case 9:
            dealercard = "9";
            break;
        case 10:
            dealercard = "10";
            break;
        case 11:
            dealercard = "Jack";
            break;
        case 12:
            dealercard = "Queen";
            break;
        case 13:
            dealercard = "King";
            break;
        default:
            break;
    }
    dealercardvalue += olddealercardvalue;
}
void PrintCard()
{
    System.Console.WriteLine($"You have {card}, hand value is {cardvalue}.");
}
void PrintDealerCard()
{
    System.Console.WriteLine($"Dealer has {dealercard}, hand value is {dealercardvalue}.");
}
void AskForBet()
{
    do
    {
        System.Console.Write($"How much do you want to bet? Bet must be >= 10€ and <= {playermoney}€. Press Enter for minimal bet. ");
        bet = int.Parse(Console.ReadLine()!);
        if (bet < MINIMUM_BET)
        {
            System.Console.WriteLine("The minimum bet is 10$. Try again.");
        }
        if (bet > playermoney)
        {
            System.Console.WriteLine($"The maximum bet is {playermoney}$. Try again.");
        }
    }
    while (bet < MINIMUM_BET || bet > playermoney);
    playermoney -= bet;
}
void AskUserForAnotherCard()
{
    int temp = 0;
    do
    {
        System.Console.Write("Do you want another card? (y/n): ");
        input = Console.ReadLine()!;
        if (input == "y")
        {
            ContinuePlaying = true;
            temp = 0;
        }
        else if (input == "n")
        {
            temp = 0;
        }
        else
        {
            temp = 1;
        }
    }
    while (temp == 1);
}
void DetermineWinner()
{
    if (cardvalue > 21)
    {
        DealerWins = true;
        if (DealerWins)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("You busted, Dealer won!");
        }
    }
    else if (dealercardvalue > 21)
    {
        PlayerWins = true;
        playermoney += 2 * bet;
        if (PlayerWins)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Dealer busted, You won!");
        }
    }
    else if (dealercardvalue > cardvalue)
    {
        DealerWins = true;
        if (DealerWins)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("You busted, Dealer won!");
        }
    }
    else if (cardvalue > dealercardvalue)
    {
        PlayerWins = true;
        playermoney += 2 * bet;
        if (PlayerWins)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Dealer busted, You won!");
        }
    }
    else
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Standoff");
        playermoney += bet;
    }

}
void CheckIfMoneyDoubled()
{
    if (playermoney >= 200)
    {
        MoneyDoubled = true;
    }
}


void GameLogic()
{
    HandoutRandomPlayerCard();
    PrintCard();
}
PrintWelcome();
do
{
    NewRound();
    PrintRound();

    GameLogic();
    AskForBet();
    GameLogic();
    AskUserForAnotherCard();
    if (input == "y")
    {
        GameLogic();
    }
    if (cardvalue < 22)
    {
        System.Console.WriteLine("Dealer's turn...");
        do
        {
            HandoutRandomDealerCard();
            PrintDealerCard();
        }
        while (dealercardvalue < 17);
    }
    DetermineWinner();
    CheckIfMoneyDoubled();
    dealercardvalue = 0;
    cardvalue = 0;
}
while (MoneyDoubled == false && playermoney > 0);


if (MoneyDoubled)
{
    System.Console.WriteLine($"You have at least doubled your money, you now have {playermoney}!");
}
else
{
    System.Console.WriteLine("You lost!");
}