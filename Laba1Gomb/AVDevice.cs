using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1Gomb
{
    public class AVDevice
    {
        protected string firm;
        protected float price;

        public AVDevice()
        {
            Firm = Constants.DefaultFirm;
            Price = Constants.DefaultPrice;
        }

        public AVDevice(string firm, float price)
        {
            Firm = firm;
            Price = price;
        }

        public string Firm
        {
            get => firm;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Название фирмы не может быть пустым");
                if (value.Length > Constants.MAX_LEN)
                    throw new ArgumentOutOfRangeException($"Название фирмы слишком длинное. Максимальная длина: {Constants.MAX_LEN}");
                firm = value;
            }
        }

        public float Price
        {
            get => price;
            protected set
            {
                if (value <= 0.0f)
                    throw new ArgumentOutOfRangeException("Цена устройства не может быть отрицательной или нулевой.");
                if (value > Constants.MAX_PRICE)
                    throw new ArgumentOutOfRangeException($"Цена устройства слишком большая. Максимальная цена: {Constants.MAX_PRICE}");
                price = value;
            }
        }
        virtual public string Print()
        {
            return $"Фирма: {firm}\nЦена: {price} \n";
        }

    }
}