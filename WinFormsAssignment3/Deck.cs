using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAssignment3
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        private readonly ImageList imageList;

        public Deck(ImageList imageList)
        {
            this.imageList = imageList;
            Shuffle();
        }

        public int Count => cards.Count;

        public void Shuffle()
        {
            cards.Clear();
            for (int i = 0; i < imageList.Images.Count; i++)
            {
                cards.Add(new Card(i, imageList.Images[i], imageList.Images.Keys[i]));
            }

            Random rng = new Random();
            cards = cards.OrderBy(_ => rng.Next()).ToList();
        }

        public Card DealCard()
        {
            if (cards.Count == 0) return Card.NoCard;
            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public bool SaveHand(string filename, Card[] hand)
        {
            try
            {
                using (StreamWriter writer = new(filename))
                {
                    foreach (var card in hand)
                    {
                        writer.WriteLine(card.Id);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving hand: " + ex.Message);
                return false;
            }
        }

        public bool LoadHand(string filename, Card[] hand)
        {
            try
            {
                using (StreamReader reader = new(filename))
                {
                    for (int i = 0; i < hand.Length; i++)
                    {
                        string? line = reader.ReadLine();
                        if (int.TryParse(line, out int cardId) && cardId >= 0 && cardId < imageList.Images.Count)
                        {
                            hand[i] = new Card(cardId, imageList.Images[cardId], imageList.Images.Keys[cardId]);
                        }
                        else
                        {
                            hand[i] = Card.NoCard;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading hand: " + ex.Message);
                return false;
            }
        }

        public Card GetCard(int index)
        {
            return index >= 0 && index < cards.Count ? cards[index] : Card.NoCard;
        }


        public void SwapCards(int index1, int index2)
        {
            if (index1 >= 0 && index1 < cards.Count && index2 >= 0 && index2 < cards.Count)
            {
                (cards[index1], cards[index2]) = (cards[index2], cards[index1]);
            }
        }

    }
}
