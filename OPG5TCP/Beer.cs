using System;
using System.Collections.Generic;
using System.Text;

namespace OPG5TCP
{
    public class Beer
    {
        // 4 ins
        private string _name;
        private int _id;
        private double _price;
        private double _adv;

        // 4 props
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 4) throw new ArgumentException();
                _name = value;
            }
        }

        public int ID
        {
            get => _id;
            set { _id = value; }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException();
                _price = value;
            }
        }

        public double Adv
        {
            get => _adv;
            set
            {
                if (value >= 100 || value <= 0) throw new ArgumentOutOfRangeException();
                _adv = value;
            }
        }

        // Constructor for 4 props
        public Beer(string name, int id, double price, double adv)
        {
            Name = name;
            ID = id;
            Price = price;
            Adv = adv;
        }
        // Const for server
        public Beer() { }
        // og en ToString til at get by id:
        public override string ToString()
        {
            return "Name: " + Name + " Id: " + ID + " Price: " + Price + " %: " + Adv;
        }
    }
}
