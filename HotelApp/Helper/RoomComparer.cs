using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp.Helper
{
    class RoomComparer : IComparer<Accomodation.Room>
    {
        public int Compare(Accomodation.Room x, Accomodation.Room y)
        {
            return x.Rate == y.Rate ? 0 : (x.Rate < y.Rate ? -1 : 1);
        }
    }
}
