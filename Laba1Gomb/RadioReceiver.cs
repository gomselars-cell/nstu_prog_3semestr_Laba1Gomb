using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1Gomb
{
    public enum TypeOfOperatingRanges
    {
        FM, AM, SW, DAB
    }
    public class RadioReceiver : AVDevice
    {
        protected string model;
        protected TypeOfOperatingRanges operatingRanges;

        public RadioReceiver(): base()
        {
            Model = Constants.DefaultModel;
            OperatingRanges = Constants.DefaultOperatingRanges;
        }

        public RadioReceiver(string firm, float price, string model, TypeOfOperatingRanges operatingRanges) :
            base(firm, price)
        {
            Model = model;
            OperatingRanges = operatingRanges;
        }

        public string Model
        {
            get => model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Название модели радиоприемника не может быть пустым.");
                if (value.Length > Constants.MAX_LEN)
                    throw new ArgumentOutOfRangeException($"Название модели радиоприемника слишком длинное. Максимальная длина: {Constants.MAX_LEN}");

                model = value;
            }
        }

        public TypeOfOperatingRanges OperatingRanges
        {
            get => operatingRanges;
            set
            {
                if (!Enum.IsDefined(typeof(TypeOfOperatingRanges), value))
                    throw new ArgumentOutOfRangeException("Недопустимый диапазон радиоприемника");
                operatingRanges = value;
            }
        }

        public override string Print()
        {
            return base.Print() + $"Модель радиоприемника: {model}\nДиапазон работы: {operatingRanges}\n";
        }
    }
}
