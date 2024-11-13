namespace WinFormsAssignment3
{
    partial class DeckForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            deckListBox = new ListBox();
            cardPictureBox = new PictureBox();
            deckBindingSource = new BindingSource(components);
            upButton = new Button();
            downButton = new Button();
            ((System.ComponentModel.ISupportInitialize)cardPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deckBindingSource).BeginInit();
            SuspendLayout();

            // deckListBox
            deckListBox.FormattingEnabled = true;
            deckListBox.Location = new Point(12, 50);
            deckListBox.Name = "deckListBox";
            deckListBox.Size = new Size(267, 344);
            deckListBox.TabIndex = 0;
            deckListBox.SelectedIndexChanged += deckListBox_SelectedIndexChanged;

            // cardPictureBox
            cardPictureBox.Location = new Point(511, 104);
            cardPictureBox.Name = "cardPictureBox";
            cardPictureBox.Size = new Size(206, 290);
            cardPictureBox.TabIndex = 1;
            cardPictureBox.TabStop = false;

            // upButton
            upButton.Location = new Point(346, 167);
            upButton.Name = "upButton";
            upButton.Size = new Size(109, 29);
            upButton.TabIndex = 2;
            upButton.Text = "&Up";
            upButton.UseVisualStyleBackColor = true;
            upButton.Click += upButton_Click;

            // downButton
            downButton.Location = new Point(346, 252);
            downButton.Name = "downButton";
            downButton.Size = new Size(109, 29);
            downButton.TabIndex = 3;
            downButton.Text = "&Down";
            downButton.UseVisualStyleBackColor = true;
            downButton.Click += downButton_Click;

            // DeckForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(downButton);
            Controls.Add(upButton);
            Controls.Add(cardPictureBox);
            Controls.Add(deckListBox);
            Name = "DeckForm";
            Text = "Poker Deck";
            Load += DeckForm_Load;
            ((System.ComponentModel.ISupportInitialize)cardPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)deckBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox deckListBox;
        private PictureBox cardPictureBox;
        private BindingSource deckBindingSource;
        private Button upButton;
        private Button downButton;
    }
}