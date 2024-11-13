using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace WinFormsAssignment3
{
    public partial class MainForm : Form
    {
        private const string HANDS_FOLDER = @"C:\Users\nachi\source\repos\Assignemnt 4\HANDS\";
        private const string DEFAULT_EXT = "txt";

        private Deck deck;
        private Card[] hand = new Card[5];

        public MainForm()
        {
            InitializeComponent();
            deck = new Deck(cardsImageList);
            deck.Shuffle(); 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReshuffleDeck();
            for (int i = 0; i < hand.Length; i++)
            {
                DealCard(i);
            }
            UpdateHandPics();
        }

        private void showDeckButton_Click(object sender, EventArgs e)
        {
            using (DeckForm deckForm = new DeckForm(deck))
            {
                deckForm.ShowDialog(); 
            }
        }

        private void DealCard(int pos)
        {
            if (pos < 0 || pos >= hand.Length) return;
            hand[pos] = deck.DealCard();
        }

        private void ReshuffleDeck()
        {
            deck.Shuffle();
        }

        private void UpdateHandPics()
        {
            hand1PictureBox.Image = hand[0].CardImage;
            hand1PictureBox.BorderStyle = keep1CheckBox.Checked ? BorderStyle.Fixed3D : BorderStyle.None;

            hand2PictureBox.Image = hand[1].CardImage;
            hand2PictureBox.BorderStyle = keep2CheckBox.Checked ? BorderStyle.Fixed3D : BorderStyle.None;

            hand3PictureBox.Image = hand[2].CardImage;
            hand3PictureBox.BorderStyle = keep3CheckBox.Checked ? BorderStyle.Fixed3D : BorderStyle.None;

            hand4PictureBox.Image = hand[3].CardImage;
            hand4PictureBox.BorderStyle = keep4CheckBox.Checked ? BorderStyle.Fixed3D : BorderStyle.None;

            hand5PictureBox.Image = hand[4].CardImage;
            hand5PictureBox.BorderStyle = keep5CheckBox.Checked ? BorderStyle.Fixed3D : BorderStyle.None;
        }

        private bool IsRedraw()
        {
            return keep1CheckBox.Checked ||
                keep2CheckBox.Checked ||
                keep3CheckBox.Checked ||
                keep4CheckBox.Checked ||
                keep5CheckBox.Checked;
        }

        private void dealButton_Click(object sender, EventArgs e)
        {
            if (!IsRedraw())
            {
                ReshuffleDeck();
            }

            if (!keep1CheckBox.Checked) DealCard(0);
            if (!keep2CheckBox.Checked) DealCard(1);
            if (!keep3CheckBox.Checked) DealCard(2);
            if (!keep4CheckBox.Checked) DealCard(3);
            if (!keep5CheckBox.Checked) DealCard(4);

            UpdateHandPics();
            ResetKeepCheckboxes();
        }

        private void ResetKeepCheckboxes()
        {
            keep1CheckBox.Checked = false;
            keep2CheckBox.Checked = false;
            keep3CheckBox.Checked = false;
            keep4CheckBox.Checked = false;
            keep5CheckBox.Checked = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = HANDS_FOLDER;
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = DEFAULT_EXT;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            if (!deck.SaveHand(saveFileDialog.FileName, hand))
            {
                MessageBox.Show("Error saving hand.");
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = HANDS_FOLDER;
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            if (!deck.LoadHand(openFileDialog.FileName, hand))
            {
                MessageBox.Show("Error loading hand.");
            }
            UpdateHandPics();
        }

        private void hand1PictureBox_Click(object sender, EventArgs e)
        {
            keep1CheckBox.Checked = !keep1CheckBox.Checked;
            UpdateHandPics(); 
        }

        private void hand2PictureBox_Click(object sender, EventArgs e)
        {
            keep2CheckBox.Checked = !keep2CheckBox.Checked;
            UpdateHandPics();
        }

        private void hand3PictureBox_Click(object sender, EventArgs e)
        {
            keep3CheckBox.Checked = !keep3CheckBox.Checked;
            UpdateHandPics();
        }

        private void hand4PictureBox_Click(object sender, EventArgs e)
        {
            keep4CheckBox.Checked = !keep4CheckBox.Checked;
            UpdateHandPics();
        }

        private void hand5PictureBox_Click(object sender, EventArgs e)
        {
            keep5CheckBox.Checked = !keep5CheckBox.Checked;
            UpdateHandPics();
        }
    }
}