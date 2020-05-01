﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game2048
{
    class Map
    // не забыть проинициализировать плашки 
    {
                
        int[,] map;
        public int size { get; private set; }


        public Map(int size)
        {
            this.size = size;
            map = new int[size, size];
            
        }
        
        public int Get(int x, int y)
            
        {
            if (OnMap(x, y))
                return map[x, y];
            return -1;
        }
        public void Set(int x, int y, int number)
        {
            if (OnMap(x, y))
                map[x, y] = number;
            
        }

     



        public bool OnMap(int x, int y)
        {
            return x >= 0 && x < size &&
                   y >= 0 && y < size;
        }
    }
}

