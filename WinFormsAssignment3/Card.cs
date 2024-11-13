using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinFormsAssignment3
{
    public class Card
    {
        public int Id { get; }
        public Image? CardImage { get; }
        public string Name { get; }

        public static readonly Card NoCard = new Card(-1, null, "No Card");

        public Card(int id, Image? image, string name)
        {
            Id = id;
            CardImage = image;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}