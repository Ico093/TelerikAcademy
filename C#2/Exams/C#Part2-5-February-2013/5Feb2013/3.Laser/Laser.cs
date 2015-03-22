using System;
using System.Collections.Generic;

class Laser
{
    static int W, H, D;

    static void Main()
    {
        string[] cubeSizes = Console.ReadLine().Split(' ');

        W = int.Parse(cubeSizes[0]);
        H = int.Parse(cubeSizes[1]);
        D = int.Parse(cubeSizes[2]);

        int[, ,] cube = new int[W, H, D];

        for (int height = 0; height < H; height++)
        {
            for (int depth = 0; depth < D; depth++)
            {
                for (int width = 0; width < W; width++)
                {
                    cube[width, height, depth] = 1;
                }
            }
        }

        for (int width = 0; width < W; width++)
        {
            cube[width, 0, 0] = 0;
            cube[width, 0, D - 1] = 0;
            cube[width, H - 1, 0] = 0;
            cube[width, H - 1, D - 1] = 0;
        }

        for (int height = 0; height < H; height++)
        {
            cube[0, height, 0] = 0;
            cube[W - 1, height, 0] = 0;
            cube[0, height, D - 1] = 0;
            cube[W - 1, height, D - 1] = 0;
        }

        for (int depth = 0; depth < D; depth++)
        {
            cube[0, 0, depth] = 0;
            cube[W - 1, 0, depth] = 0;
            cube[0, H - 1, depth] = 0;
            cube[W - 1, H - 1, depth] = 0;
        }
        //Macking the cube

        string[] starCoordinates = Console.ReadLine().Split(' ');
        int starWidth = int.Parse(starCoordinates[0])-1;
        int starHeight = int.Parse(starCoordinates[1])-1;
        int starDepth = int.Parse(starCoordinates[2])-1;

        string[] laserShot = Console.ReadLine().Split(' ');
        int laserWidth = int.Parse(laserShot[0]);
        int laserHeight = int.Parse(laserShot[1]);
        int laserDepth = int.Parse(laserShot[2]);

        Shoot(cube, starWidth, starHeight, starDepth, laserWidth, laserHeight, laserDepth);
    }

    static void Shoot(int[, ,] cube, int starW, int starH, int starD, int laserW, int laserH, int laserD)
    {
        bool empty = false;
        int lastW, lastH, lastD;
       

        while (!empty)
        {
            cube[starW, starH, starD] = 0;

            lastW = starW;
            lastH = starH;
            lastD = starD;

            if (starW + laserW ==W || starW + laserW == -1 || starH + laserH == H || starH + laserH == -1 || starD + laserD == D || starD + laserD == -1)
            {
                if (starW == 0 || starW == W-1 )
                {
                    laserW *= (-1);
                }
                if (starH == H-1 || starH == 0)
                {
                    laserH *= (-1);
                }
                if (starD == D-1 || starD == 0)
                {
                    laserD *= (-1);
                }

                starW += laserW;
                starH += laserH;
                starD += laserD;
                if (cube[starW, starH, starD] == 0)
                {
                    empty = true;
                    Console.WriteLine("{0} {1} {2}", lastW+1, lastH+1, lastD+1);
                }
            }
            else
            {
                starW += laserW;
                starH += laserH;
                starD += laserD;
                if (cube[starW, starH, starD] == 0)
                {
                    empty = true;
                    Console.WriteLine("{0} {1} {2}", lastW+1, lastH+1, lastD+1);
                }
            }
        }
    }
}
