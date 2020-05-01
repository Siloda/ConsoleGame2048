using System;


namespace Game2048
{
    public class Model
    {
        Map map;
        public bool isGameOver;
        static Random random = new Random();
        public int size { get { return map.size; }}        

        public Model(int size)
        {
            map = new Map(size);
        }

        public void Start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map.Set(x, y, 0);
            

            AddRandomNumber();
                      
                
        }

        private void AddRandomNumber()
        {
            for (int j = 0; j < 100; j++)
            {
                if (isGameOver) return;
                int x = random.Next(0, map.size);
                int y = random.Next(0, map.size);

                if (map.Get(x, y) == 0)
                {
                    map.Set(x, y, random.Next(1, 3) * 2);
                    return;
                }
            }
        }
        private void AddIsland()
        {
            for (int j = 0; j < 100; j++)
            {
                if (isGameOver) return;
                int x = random.Next(0, map.size);
                int y = random.Next(0, map.size);

                if (map.Get(x, y) == 0)
                {
                    map.Set(x, y, 5);
                    return;
                }
            }
        }
        void Lift (int x, int y, int sx, int sy)
        {

            if (map.Get(x, y) > 5)

                while (map.Get(x + sx, y + sy) == 5)
                {

                    map.Set(x + sx, y + sy, map.Get(x, y));
                    map.Set(x, y, 0);

                    x = sx;
                    y = sy;
                }
            if (map.Get(x, y) > 0)

                while (map.Get(x + sx, y + sy) == 0)
                {

                    map.Set(x + sx, y + sy, map.Get(x, y));
                   

                    x += sx;
                    y += sy;
                }



        }

        void Join() {
        }

        public void Left()
        {
            for (int y = 0; y < map.size; y++)
                for (int x = 1; x < map.size; x++)
                    Lift(x, y, - 1, 0);
            AddRandomNumber();
        }

        public void Right()
        {
            for (int y = 0; y < map.size; y++)
                for (int x = map.size -2; x >=0; x--)
                    Lift(x, y, +1, 0);
            AddRandomNumber();
        }

        public void Up()
        {
            for (int x = 0; x < map.size; x++)
                for (int y = 1; y <map.size; y++)
                    Lift(x, y, 0, -1);
            AddRandomNumber();

        }

        public void Down()
        {
            for (int x = 0; x < map.size; x++)
                for (int y = map.size - 2; y >= 0; y--)
                    Lift(x, y, 0, +1);
            AddRandomNumber();
        }

        public int GetMap(int x, int y)
        {
            return map.Get(x,y);
        }

      public bool IsGameOver()
        {
            return isGameOver;
        }
    }
}
