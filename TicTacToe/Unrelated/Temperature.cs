using System;

namespace TicTacToe.Unrelated
{
    public class Temperature
    {
        // https://www.leifiphysik.de/waermelehre/temperatur-und-teilchenmodell/grundwissen/temperaturumrechnung

        public const float AbsoluteZero = -273.15f;

        public float Kelvin { get; set; }

        public float Fahrenheit
        {
            get => Celsius * (9f / 5f) + 32f;
            set => Celsius = (value - 32f) * (5f / 9f);
        }

        public float Celsius
        {
            get => Kelvin + AbsoluteZero;
            set => Kelvin = value - AbsoluteZero;
        }

        public float Parse(string s) => 0f;

        public bool TryParse(string s, out float result)
        {
            try
            {
                result = Parse(s);
                return true;
            }
            catch (ArgumentException ex)
            {
                result = default;
                return false;
            }
        }
    }
}