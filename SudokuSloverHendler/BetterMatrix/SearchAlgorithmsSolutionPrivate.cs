﻿using System;
using SudokuSloverHendler.Collections;
using SudokuSloverHendler.Coordinates;
using SudokuSloverHendler.Matrix;
using SudokuSloverHendler.Points;
using System.Linq;

namespace SudokuSloverHendler.BetterMatrix
{
    public partial class BetterMatrix : Matrix<Point>
    {
        private Arrange<PosPoint> GetPosPointsInRange(PosPoint pos1, PosPoint pos2)
        {
            Arrange<PosPoint> arr = new Arrange<PosPoint>();
            for (int i = pos1.i; i <= pos2.i; i++)
            {
                for (int j = pos1.j; j <= pos2.j; j++)
                {
                    if (matrix[i, j].value == 0)
                    {
                        arr.Add(new PosPoint(i, j));
                    }
                }
            }
            return arr;
        }
        // Locked / Naked
        private Arrange<Intersections> GetLockedPairInRange(PosPoint pos1, PosPoint pos2)
        {
            Arrange<PosPoint> pos = this.GetPosPointsInRange(pos1, pos2);
            Arrange<Intersections> pairs = new Arrange<Intersections>();
            for (int i = 0; i < pos.Count(); i++)
            {
                for (int j = 0; j < pos.Count(); j++)
                {
                    if ((pos[i] != pos[j]) && (this.matrix[pos[i].i, pos[i].j].set == this.matrix[pos[j].i, pos[j].j].set) && (this.matrix[pos[i].i, pos[i].j].set.Count() == 2))
                    {
                        Intersections para = new Intersections(new Arrange<PosPoint>(pos[i], pos[j]), this.GetPossValueInPosPoint(pos[i]));
                        if (!pairs.Contains(para))
                        {
                            pairs.Add(para);
                        }
                    }
                }
            }
            return pairs;
        }
        private Arrange<Intersections> GetLockedTripleInRange(PosPoint pos1, PosPoint pos2)
        {
            Arrange<PosPoint> pos = this.GetPosPointsInRange(pos1, pos2);
            Arrange<Intersections> tripls = new Arrange<Intersections>();
            for (int i1 = 0; i1 < pos.Count(); i1++)
            {
                for (int i2 = 0; i2 < pos.Count(); i2++)
                {
                    for (int i3 = 0; i3 < pos.Count(); i3++)
                    {
                        if (pos[i1] != pos[i2] && pos[i2] != pos[i3] && pos[i1] != pos[i3])
                        {
                            Set<int> set1 = this.matrix[pos[i1].i, pos[i1].j].set;
                            Set<int> set2 = this.matrix[pos[i2].i, pos[i2].j].set;
                            Set<int> set3 = this.matrix[pos[i3].i, pos[i3].j].set;
                            Set<int> all = set1 + set2 + set3;
                            if ((set1.Count() >= 2 && set1.Count() <= 3) && (set2.Count() >= 2 && set2.Count() <= 3) && (set3.Count() >= 2 && set3.Count() <= 3) && all.Count() == 3)
                            {
                                Intersections triple = new Intersections(new Arrange<PosPoint>(pos[i1], pos[i2], pos[i3]), all);
                                if (!tripls.Contains(triple))
                                {
                                    tripls.Add(triple);
                                }
                            }
                        }
                    }
                }
            }
            return tripls;
        }
        // Naked
        private Arrange<Intersections> GetNakedQuadrupleInRange(PosPoint pos1, PosPoint pos2)
        {
            Arrange<PosPoint> pos = this.GetPosPointsInRange(pos1, pos2);
            Arrange<Intersections> quadruples = new Arrange<Intersections>();
            for (int i1 = 0; i1 < pos.Count(); i1++)
            {
                for (int i2 = 0; i2 < pos.Count(); i2++)
                {
                    for (int i3 = 0; i3 < pos.Count(); i3++)
                    {
                        for (int i4 = 0; i4 < pos.Count(); i4++)
                        {
                            if (pos[i1] != pos[i2] && pos[i2] != pos[i3] && pos[i1] != pos[i3]
                             && pos[i3] != pos[i4] && pos[i1] != pos[i4] && pos[i2] != pos[i4])
                            {
                                Set<int> set1 = this.matrix[pos[i1].i, pos[i1].j].set;
                                Set<int> set2 = this.matrix[pos[i2].i, pos[i2].j].set;
                                Set<int> set3 = this.matrix[pos[i3].i, pos[i3].j].set;
                                Set<int> set4 = this.matrix[pos[i4].i, pos[i4].j].set;
                                Set<int> all = set1 + set2 + set3 + set4;
                                if ((set1.Count() >= 2 && set1.Count() <= 4) && (set2.Count() >= 2 && set2.Count() <= 4)
                                 && (set3.Count() >= 2 && set3.Count() <= 4) && (set4.Count() >= 2 && set4.Count() <= 4) && all.Count() == 4)
                                {
                                    Intersections quadruple = new Intersections(new Arrange<PosPoint>(pos[i1], pos[i2], pos[i3], pos[i4]), all);
                                    if (!quadruples.Contains(quadruple))
                                    {
                                        quadruples.Add(quadruple);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return quadruples;
        }
        // Hidden
        private Arrange<Intersections> GetHiddenPairInRange(PosPoint pos1, PosPoint pos2)
        {
            Arrange<Intersections> pairs = new Arrange<Intersections>();
            for (int num1 = 0; num1 < 10; num1++)
            {
                for (int num2 = 1; num2 < 10; num2++)
                {
                    if (num1 != num2)
                    {
                        int count_num1 = this.GetCountPossiblePosPointInRange(pos1, pos2, num1), count_num2 = this.GetCountPossiblePosPointInRange(pos1, pos2, num2);
                        if (count_num1 == 2 && count_num2 == 2)
                        {
                            Arrange<PosPoint> arr1 = this.GetPossPosPointsInRange(pos1, pos2, num1), arr2 = this.GetPossPosPointsInRange(pos1, pos2, num2);
                            if (arr1 == arr2)
                            {
                                Intersections para = new Intersections(new Arrange<PosPoint>(arr1[0], arr1[1]), new Set<int>(num1, num2));
                                if (!pairs.Contains(para))
                                {
                                    pairs.Add(para);
                                }
                            }
                        }
                    }

                }
            }
            return pairs;
        }
        private Arrange<Intersections> GetHiddenTripleInRange(PosPoint pos1, PosPoint pos2)
        {
            Arrange<Intersections> triples = new Arrange<Intersections>();
            for (int num1 = 0; num1 < 10; num1++)
            {
                for (int num2 = 0; num2 < 10; num2++)
                {
                    for (int num3 = 0; num3 < 10; num3++)
                    {
                        int count_num1 = this.GetCountPossiblePosPointInRange(pos1, pos2, num1);
                        int count_num2 = this.GetCountPossiblePosPointInRange(pos1, pos2, num2);
                        int count_num3 = this.GetCountPossiblePosPointInRange(pos1, pos2, num3);
                        if (num1 != num2 && num2 != num3 && num1 != num3 && count_num1 <= 3 && count_num1 >= 2 && count_num2 <= 3 && count_num2 >= 2 && count_num3 <= 3 && count_num3 >= 2)
                        {
                            Set<PosPoint> poss_num = new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num1)) + new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num2)) + new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num3));
                            if (poss_num.Count() == 3)
                            {
                                Set<int> set_other = new Set<int>();
                                Set<int> values = new Set<int>();
                                for (int i = pos1.i; i <= pos2.i; i++)
                                {
                                    for (int j = pos1.j; j <= pos2.j; j++)
                                    {
                                        PosPoint pos = new PosPoint(i, j);
                                        if (this.matrix[i, j].value == 0 && !poss_num.Contains(pos))
                                        {
                                            set_other += this.matrix[i, j].set;
                                        }
                                        if (poss_num.Contains(pos))
                                        {
                                            values += this.matrix[i, j].set;
                                        }
                                    }
                                }
                                values = values - set_other;
                                if (values.Count() == 3)
                                {
                                    Intersections triple = new Intersections(poss_num, values);
                                    if (!triples.Contains(triple))
                                    {
                                        triples.Add(triple);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return triples;
        }
        private Arrange<Intersections> GetHiddenQuadrupleInRange(PosPoint pos1, PosPoint pos2)
        {
            Arrange<Intersections> quadruples = new Arrange<Intersections>();
            for (int num1 = 1; num1 < 10; num1++)
            {
                for (int num2 = 1; num2 < 10; num2++)
                {
                    for (int num3 = 1; num3 < 10; num3++)
                    {
                        for (int num4 = 1; num4 < 10; num4++)
                        {
                            int count_num1 = this.GetCountPossiblePosPointInRange(pos1, pos2, num1);
                            int count_num2 = this.GetCountPossiblePosPointInRange(pos1, pos2, num2);
                            int count_num3 = this.GetCountPossiblePosPointInRange(pos1, pos2, num3);
                            int count_num4 = this.GetCountPossiblePosPointInRange(pos1, pos2, num4);
                            if (num1 != num2 && num2 != num3 && num1 != num3 && num1 != num4 && num2 != num4 && num3 != num4
                                && count_num1 <= 4 && count_num1 >= 2 && count_num2 <= 4 && count_num2 >= 2
                                && count_num3 <= 4 && count_num3 >= 2 && count_num4 <= 4 && count_num4 >= 2)
                            {
                                Set<PosPoint> poss_num = new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num1)) + new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num2))
                                                       + new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num3)) + new Set<PosPoint>(this.GetPossPosPointsInRange(pos1, pos2, num4));
                                if (poss_num.Count() == 4)
                                {
                                    Set<int> set_other = new Set<int>();
                                    Set<int> values = new Set<int>();
                                    for (int i = pos1.i; i <= pos2.i; i++)
                                    {
                                        for (int j = pos1.j; j <= pos2.j; j++)
                                        {
                                            PosPoint pos = new PosPoint(i, j);
                                            if (this.matrix[i, j].value == 0 && !poss_num.Contains(pos))
                                            {
                                                set_other += this.matrix[i, j].set;
                                            }
                                            if (poss_num.Contains(pos))
                                            {
                                                values += this.matrix[i, j].set;
                                            }
                                        }
                                    }
                                    values = values - set_other;
                                    if (values.Count() == 4)
                                    {
                                        Intersections quadruple = new Intersections(poss_num, values);
                                        if (!quadruples.Contains(quadruple))
                                        {
                                            quadruples.Add(quadruple);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return quadruples;
        }
    }
}