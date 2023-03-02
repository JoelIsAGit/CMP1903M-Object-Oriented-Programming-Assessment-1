using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        int Value { get; set; }
        int Suit { get; set; }

        public Card(int newValue, int newSuit) 
        {
            SetValue(newValue);
            SetSuit(newSuit);
        }

        public void SetValue(int newValue)
        {
            if (newValue > 13 || newValue < 1)
            {
                throw new ArgumentException(newValue.ToString());
            }
            Value = newValue;
        }
        public int GetValue() { return Value; }

        public void SetSuit(int newSuit) 
        {
            if (newSuit > 4 || newSuit < 1)
            {
                throw new ArgumentException(newSuit.ToString());
            }
            Suit = newSuit;
        }

        public int GetSuit() { return Suit; }
    }
}
