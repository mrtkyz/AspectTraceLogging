using Data;
using System;

namespace Business
{
    public class Hesaplama
    {
        public Hesaplama()
        {
            throw new Exception("hata fırladı...");
        }
        
        public double Bol(int x, int y)
        {
            DataRepository data = new DataRepository();
            int z = data.GetCarpan(DateTime.Now);

            return x / y;
        }
        
        public double Ekle(int x, int y)
        {
            throw new Exception("hata fırladı...");
            return x + y;
        }
    }
}
