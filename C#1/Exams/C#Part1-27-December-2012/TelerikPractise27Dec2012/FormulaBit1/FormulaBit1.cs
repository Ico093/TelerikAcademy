using System;

class FormulaBit1
{
    static void Main()
    {
        int[,] track = new int[8, 8];
        int number;

        for (int row = 0; row < 8; row++)
        {
            number = int.Parse(Console.ReadLine());
            for (int col = 7; col >= 0; col--)
            {
                track[row, col] = number % 2;
                number >>= 1;
            }
        }
        
        bool moreTrack = true;
        bool isSooner = false;
        int heading = 1;
        int lastHeading = 1;
        int Row = 0;
        int Col = 7;
        int count = 0;
        int corners = 0;

        if (track[Row, Col] == 1)
        {
            moreTrack = false;
            isSooner = true;
        }
        else
        {
            count++;
            if (!CheckDown(track, ref Row, Col, ref count))
            {
                moreTrack = false;
                isSooner = true;
            }
        }
        while (moreTrack)
        {
            switch (heading)
            {
                case 1:
                    {
                        int location = 0;
                        DeterminLocation(Row, Col, ref location);
                        if (location == 2)
                        {
                            if (CheckLeft(track, Row, ref Col, ref count))
                            {
                                heading = 2;
                                lastHeading = 1;
                                corners++;
                            }
                            else
                            {
                                isSooner = true;
                                moreTrack = false;
                            }
                        }

                        else if (location == 3)
                        {
                            moreTrack = false;
                        }

                        else if (location == 6)
                        {
                            if (!CheckDown(track, ref Row, Col, ref count))
                            {
                                if (CheckLeft(track, Row, ref Col, ref count))
                                {
                                    heading = 2;
                                    lastHeading = 1;
                                    corners++;
                                }
                                else
                                {
                                    isSooner = true;
                                    moreTrack = false;
                                }
                            }
                        }

                        else if (location == 7)
                        {
                            if (CheckLeft(track, Row, ref Col, ref count))
                            {
                                heading = 2;
                                lastHeading = 1;
                                corners++;
                            }
                            else
                            {
                                isSooner = true;
                                moreTrack = false;
                            }
                        }

                        else if (location == 8)
                        {
                            if (!CheckDown(track, ref Row, Col, ref count))
                            {
                                isSooner = true;
                                moreTrack = false;
                            }
                        }

                        else if (location == 9)
                        {
                            if (!CheckDown(track, ref Row, Col, ref count))
                            {
                                if (CheckLeft(track, Row, ref Col, ref count))
                                {
                                    heading = 2;
                                    lastHeading = 1;
                                    corners++;
                                }
                                else
                                {
                                    isSooner = true;
                                    moreTrack = false;
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        int location = 0;
                        DeterminLocation(Row, Col, ref location);
                        if (location == 3)
                        {
                            moreTrack = false;
                        }
                        else if (location == 4)
                        {
                            if (CheckDown(track, ref Row, Col, ref count))
                            {
                                heading = 1;
                                lastHeading = 2;
                                corners++;
                            }
                            else
                            {
                                isSooner = true;
                                moreTrack = false;
                            }
                        }
                        else if (location == 5)
                        {
                            if (!CheckLeft(track, Row, ref Col, ref count))
                            {
                                if (CheckDown(track, ref Row, Col, ref count))
                                {
                                    heading = 1;
                                    lastHeading = 2;
                                    corners++;
                                }
                                else
                                {
                                    isSooner = true;
                                    moreTrack = false;
                                }
                            }
                        }
                        else if (location == 7)
                        {
                            if (!CheckLeft(track, Row, ref Col, ref count))
                            {
                                if (CheckUp(track, ref Row, Col, ref count))
                                {
                                    heading = 3;
                                    lastHeading = 2;
                                    corners++;
                                }
                                else
                                {
                                    isSooner = true;
                                    moreTrack = false;
                                }
                            }
                        }
                        else if (location == 8)
                        {
                            if (lastHeading == 1)
                            {
                                if (CheckUp(track, ref Row, Col, ref count))
                                {
                                    heading = 3;
                                    lastHeading = 2;
                                    corners++;
                                }
                                else
                                {
                                    isSooner = true;
                                    moreTrack = false;
                                }
                            }
                            else
                            {
                                if (CheckDown(track, ref Row, Col, ref count))
                                {
                                    heading = 1;
                                    lastHeading = 2;
                                    corners++;
                                }
                                else
                                {
                                    isSooner = true;
                                    moreTrack = false;
                                }
                            }
                        }
                        else
                        {
                            if (!CheckLeft(track, Row, ref Col, ref count))
                            {
                                if (lastHeading == 1)
                            {
                                if (CheckUp(track, ref Row, Col, ref count))
                                {
                                    heading = 3;
                                    lastHeading = 2;
                                    corners++;
                                }
                                else
                                {
                                    isSooner = true;
                                    moreTrack = false;
                                }
                            }
                            else
                            {
                                if (CheckDown(track, ref Row, Col, ref count))
                                {
                                    heading = 1;
                                    lastHeading = 2;
                                    corners++;
                                }
                                else
                                {
                                    isSooner = true;
                                    moreTrack = false;
                                }
                            }
                            }
                        }
                    }
                    break;
                case 3:
                    {
                        int location = 0;
                        DeterminLocation(Row, Col, ref location);
                        if (location == 4)
                        {
                            isSooner = true;
                            moreTrack = false;
                        }
                        else if (location == 5)
                        {
                            if (CheckLeft(track, Row, ref Col, ref count))
                            {
                                heading = 2;
                                lastHeading = 3;
                                corners++;
                            }
                            else
                            {
                                isSooner = true;
                                moreTrack = false;
                            }
                        }
                        else if (location == 8)
                        {
                            if (!CheckUp(track, ref Row, Col, ref count))
                            {
                                isSooner = true;
                                moreTrack = false;
                            }
                        }
                        else
                        {
                            if (!CheckUp(track, ref Row, Col, ref count))
                            {
                                if (CheckLeft(track, Row, ref Col, ref count))
                                {
                                    heading = 2;
                                    lastHeading = 3;
                                    corners++;
                                }
                                else
                                {
                                    isSooner = true;
                                    moreTrack = false;
                                }
                            }
                        }
                    }
                    break;
            }
        }

        if (isSooner)
            Console.WriteLine("No {0}", count);
        else
            Console.WriteLine("{0} {1}", count, corners);
    }

    private static void PrintTrack(int[,] track)
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                Console.Write(track[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    private static void DeterminLocation(int row, int col, ref int location)
    {
        if (row == 0 && col == 0)
        {
            location = 4;
        }
        else if (row == 0 && col == 7)
        {
            location = 1;
        }
        else if (row == 7 && col == 0)
        {
            location = 3;
        }
        else if (row == 7 && col == 7)
        {
            location = 2;
        }
        else if (row == 0)
        {
            location = 5;
        }
        else if (row == 7)
        {
            location = 7;
        }
        else if (col == 0)
        {
            location = 8;
        }
        else if (col == 7)
        {
            location = 6;
        }
        else
        {
            location = 9;
        }

    }

    private static bool CheckLeft(int[,] track, int Row, ref int Col, ref int count)
    {
        if (track[Row, Col - 1] == 0)
        {
            Col--;
            count++;
            return true;
        }
        else
            return false;
    }
    private static bool CheckDown(int[,] track, ref int Row, int Col, ref int count)
    {
        if (track[Row + 1, Col] == 0)
        {
            Row++;
            count++;
            return true;
        }
        else
            return false;
    }
    private static bool CheckUp(int[,] track, ref int Row, int Col, ref int count)
    {
        if (track[Row - 1, Col] == 0)
        {
            Row--;
            count++;
            return true;
        }
        else
            return false;
    }
}

