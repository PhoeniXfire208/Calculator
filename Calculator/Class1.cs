using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum MeasureType {ml,l,m3,bar};

    public class Length
    {
        private double value;
        private MeasureType type;

        public Length(double value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }

        public static Length operator +(Length instance, double number)
        {
            var newValue = instance.value + number;

            var length = new Length(newValue, instance.type);

            return length;
        }

        public static Length operator +(double number, Length instance)
        {
            return instance + number;
        }

        public static Length operator *(Length instance, double number)
        {
            return new Length(instance.value * number, instance.type); ;
        }

        public static Length operator *(double number, Length instance)
        {
            return instance * number;
        }

        // вычитание
        public static Length operator -(Length instance, double number)
        {
            return new Length(instance.value - number, instance.type); ;
        }

        public static Length operator -(double number, Length instance)
        {
            return instance - number;
        }

        // деление
        public static Length operator /(Length instance, double number)
        {
            return new Length(instance.value / number, instance.type); ;
        }

        public static Length operator /(double number, Length instance)
        {
            return instance / number;
        }

        public Length To(MeasureType newType)
        {
            
            var newValue = this.value;
            
            if (this.type == MeasureType.ml)
            {
                switch (newType)
                {
                    case MeasureType.ml:
                        newValue = this.value;
                        break;
                    // если в литры
                    case MeasureType.l:
                        newValue = this.value / 1000;
                        break;
                    // если в м3
                    case MeasureType.m3:
                        newValue = this.value / 1000000;
                        break;
                    // если в баррели
                    case MeasureType.bar:
                        newValue = this.value / 158987.294928;
                        break;
                }
            }

            else if (newType == MeasureType.ml)
            {
                switch (this.type)
                {
                    case MeasureType.ml:
                        newValue = this.value;
                        break;
                    case MeasureType.l:
                        newValue = this.value * 1000;
                        break;
                    case MeasureType.m3:
                        newValue = this.value * 1000000;
                        break;
                    case MeasureType.bar:
                        newValue = this.value * 158987.294928;
                        break;
                }
            }

            else
            {
                newValue = this.To(MeasureType.ml).To(newType).value;
            }
            return new Length(newValue, newType);
        }

        public string Verbose()
        {
            string typeVerbose = "";
            
            switch (type)
            {
                case MeasureType.ml:
                    typeVerbose = "Мл.";
                    break;
                case MeasureType.l:
                    typeVerbose = "Л.";
                    break;
                case MeasureType.m3:
                    typeVerbose = "м3.";
                    break;
                case MeasureType.bar:
                    typeVerbose = "Баррел.";
                    break;
            }
            return $"{this.value} {typeVerbose}";
        }

        public static Length operator +(Length instance1, Length instance2)
        {
            return instance1 + instance2.To(instance1.type).value;
        }

        public static Length operator -(Length instance1, Length instance2)
        {
            return instance1 - instance2.To(instance1.type).value;
        }
    }
}
