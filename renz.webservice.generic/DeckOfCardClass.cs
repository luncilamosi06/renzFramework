using System;

public class DeckOfCards
{
    public class Cards : IComparable<Cards>
    {
        public int rank;
        public string suit;

        public Cards(int rank, string suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        //Alphabetic sort if rank is equal
        public int CompareTo(Cards other)
        {
            if (rank == other.rank)
            {
                return string.Compare(suit, other.suit, StringComparison.Ordinal);
            }
            return rank.CompareTo(other.rank);
        }

    }

    public Cards[] CardsArray;
    public List<string> Suit { get; }

    public DeckOfCards()
    {
        Suit = new List<string> { "Clubs", "Diamonds", "Hearts", "Spades" };
        CardsArray = new Cards[52];

        InitializeArray();
    }

    private void InitializeArray()
    {
        var idx = 0;
        foreach (var suit in Suit)
        {
            for (var rank = 1; rank <= 13; rank++)
            {
                CardsArray[idx++] = new Cards(rank, suit);
            }
        }
    }

    public Cards[] Shuffle()
    {
        var random = new Random();
        CardsArray = CardsArray.OrderBy(x => random.Next()).ToArray();
        return CardsArray;
    }

    public void Sort(string choice)
    {
        if (choice.ToLower() == "s")
        {
            SortBySuit();
        }
        if (choice.ToLower() == "r")
        {
            SortByRank();
        }
        if (choice.ToLower() == "b")
        {
            SortByRankThenSuit();
        }
    }

    private void SortByRank()
    {
        CardsArray = CardsArray.OrderBy(x => x.rank).ToArray();
    }

    private void SortBySuit()
    {
        CardsArray = CardsArray.OrderBy(x => x.suit).ToArray();
    }

    public void SortByRankThenSuit()
    {
        Array.Sort(CardsArray);
    }

}
