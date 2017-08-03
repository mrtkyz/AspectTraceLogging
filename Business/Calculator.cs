using System;
using AOPVSMSample.Aspects;

namespace AOPVSMSample
{
    public class Hesaplama
    {
        [Log]
        public Hesaplama()
        {
            throw new Exception("hata fırladı...");
        }

        [Log]
        public double Bol(int x, int y)
        {
            return x / y;
        }


        [Log]
        public double Ekle(int x, int y)
        {

            throw new Exception("hata fırladı...");
            return x + y;
        }
    }
}
