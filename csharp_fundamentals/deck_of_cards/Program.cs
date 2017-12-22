using System;
using System.Collections.Generic;


namespace deck_of_cards
{
    public enum Suits { Clubs, Spades, Hearts, Diamonds }

    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Console.WriteLine(deck.GetTopCard());
        }
    }

    class Player
    {
        public string Name;
        public List<Card> Hand;

        public Card Draw(Deck deck)
        {
            Card card = deck.GetTopCard();
            Hand.Add(card);
            return card;
        }

        public Card Discard(int idx)
        {
            if (idx >= Hand.Count)
            {
                Card card = Hand[idx];
                Hand.RemoveAt(idx);
                return card;
            }
            return null;
        }
    }

    class Card
    {
        string stringVal;
        Suits suit;
        int val;
        
        public override string ToString()
        {
            return $"{stringVal} of {suit.ToString()}";
        }

        public Card(string stringVal, Suits suit, int val)
        {
            this.stringVal = stringVal;
            this.suit = suit;
            this.val = val;
        }

    }

    class Deck
    {
        public List<Card> Cards;
        Suits[] suits = { Suits.Clubs, Suits.Spades, Suits.Hearts, Suits.Diamonds };
        string[] stringVals = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        void CreateDeck()
        {
            Cards = new List<Card>();
            foreach (Suits suit in suits)
            {
                for (int i = 0; i < stringVals.Length;i++)
                {
                    Cards.Add(new Card(stringVals[i], suit, i + 1));
                }
            }
        }

        void ShuffleDeck()
        {
            Random random = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int swapIdx = random.Next(Cards.Count);
                Card swapCard = Cards[swapIdx];
                Cards[swapIdx] = Cards[i];
                Cards[i] = swapCard;
            }
        }

        public Card GetTopCard()
        {
            Card card = Cards[0];
            Cards.Remove(card);
            return card;
        }

        public Deck()
        {
            CreateDeck();
            ShuffleDeck();
        }
    }
}
