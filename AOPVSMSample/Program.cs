namespace AOPVSMSample
{
    class Program
    {
        static void Main()
        {

            Hesaplama calc = new Hesaplama();

            double bolum = calc.Bol(100, 0);

            double toplam = calc.Ekle(1, 1);
        }
    }
}
