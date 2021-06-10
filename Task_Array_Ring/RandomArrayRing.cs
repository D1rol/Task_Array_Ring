using System;
using System.Collections.Generic;    
using System.Collections;           // IEnumerable
using System.Drawing;
using System.Windows.Forms;

namespace classRing
{
    class RandomArrayRing : IEnumerable
    {
        List<Ring> listRing;
        Random obj = new Random();

        public int Count { get { return listRing.Count;  } }
        public RandomArrayRing(int count)
        {
            listRing = new List<Ring>(count);
        }

        public void Initialize()
        {
            for (int i = 0; i < listRing.Capacity; i++)
            {
                int radius = obj.Next(10, 51);

                Color color = Color.FromArgb(obj.Next(0, 252), obj.Next(0, 252), obj.Next(0, 252));

                listRing.Add(new Ring(radius, color));

            }
        }

        public void Sort()
        {
            listRing.Sort(); 
        }

        public void Reverse()
        {
            listRing.Reverse();
        }

        public void Clear()
        {
            listRing.Clear();

            for (int i = 0; i < listRing.Capacity; i++)
            {
                listRing.Add(new Ring());
            }
        }

        public IEnumerator GetEnumerator()
        {
            return listRing.GetEnumerator();
        } 
    }
}