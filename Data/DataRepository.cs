using System;

namespace Data
{
    public class DataRepository
    {
        public int GetCarpan(DateTime now)
        {
            return now.Minute;
        }
    }
}
