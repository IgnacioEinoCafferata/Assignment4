using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAssignment3
{
    public partial class DeckForm : Form
    {
        private Deck deck;

        public DeckForm(Deck deck)
        {
            InitializeComponent();
            this.deck = deck;
            UpdateDeck();
        }

        public void UpdateDeck()
        {
            deckListBox.Items.Clear();
            for (int i = 0; i < deck.Count; i++)
            {
                Card card = deck.GetCard(i);
                deckListBox.Items.Add(card);
            }
        }

        private void DeckForm_Load(object sender, EventArgs e)
        {
            UpdateDeck();
        }

        private void deckListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deckListBox.SelectedItem is Card selectedCard)
            {
                cardPictureBox.Image = selectedCard.CardImage;
            }
        }

        private void MoveSelectedCard(int direction)
        {
            int selectedIndex = deckListBox.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < deckListBox.Items.Count)
            {
                int newIndex = selectedIndex + direction;
                if (newIndex >= 0 && newIndex < deckListBox.Items.Count)
                {
                    deck.SwapCards(selectedIndex, newIndex);

                    UpdateDeck();

                    deckListBox.SelectedIndex = newIndex;
                }
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            MoveSelectedCard(-1);
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            MoveSelectedCard(1);
        }
    }
}
