using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Classes
{
    public class Projection
    {
        private Halls hall;
        private String projectionHour;
        //List of reserved places
        private List<int> reservedPlaces;

        public List<int> ReservedPlaces
        {
            get { return this.reservedPlaces; }
            set { this.reservedPlaces = value; }
        }

        public Halls Hall
        {
            get { return this.hall; }
            set { this.hall = value; }
        }

        public String ProjectionHour
        {
            get { return this.projectionHour; }
            set { this.projectionHour = value; }
        }

        public Projection(Halls hall, String projectionHour)
        {
            Hall = hall;
            ProjectionHour = projectionHour;
            reservedPlaces = new List<int>();
        }

        public int GetPlace(int index)
        {
            if (index < 0 || index > this.reservedPlaces.Count - 1)
            {
                //WrongPLaceException
            }
            return reservedPlaces[index];
        }
        public void ReservePlace(int value)
        {
            this.reservedPlaces.Add(value);
        }
    }
}
