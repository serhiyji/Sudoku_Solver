using SudokuSloverHendler.BetterMatrix;
using SudokuSloverHendler.Collections;
using SudokuSloverHendler.Coordinates;
using SudokuSloverHendler.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSloverHendler
{
    public class SudokuSlover
    {
        public SudokuSloverHendler.BetterMatrix.BetterMatrix matrix { get; set; }
        public SudokuSlover(ref SudokuSloverHendler.BetterMatrix.BetterMatrix matrix)
        {
            this.matrix = matrix;
            this.matrix.SetPossibleValues();
        }
        private void SetValue(PosPoint pos_p, byte value)
        {
            this.matrix.SetValue(pos_p, value);
        }

        private bool IsPosPointsInHorizontalLine(Arrange<PosPoint> arr)
        {
            bool total_i = true;
            for (int i = 0; i < arr.Count() - 1; i++)
            {
                total_i = ((arr[i].i == arr[i + 1].i) && total_i);
            }
            return total_i;
        }
        private bool IsPosPointsInVerticalLine(Arrange<PosPoint> arr)
        {
            bool total_j = true;
            for (int i = 0; i < arr.Count() - 1; i++)
            {
                total_j = ((arr[i].j == arr[i + 1].j) && total_j);
            }
            return total_j;
        }
        private bool IsOneSquareInArrPospoint(Arrange<PosPoint> arr)
        {
            bool total = true;
            for (int i = 0; i < arr.Count() - 1; i++)
            {
                total = (new PosSquare(arr[i]) == new PosSquare(arr[i + 1])) && total;
            }
            return total;
        }

        private bool Intersections_Handler(Intersections inter, bool pos, bool sq, bool lh, bool lv)
        {
            bool total = false;
            if (pos)
            {
                for (int i = 0; i < inter.PosPoints.Count(); i++)
                {
                    total = this.matrix.ClearValuesInSetInPosPoint(inter.PosPoints[i], this.matrix.GetPossValueInPosPoint(inter.PosPoints[i]) - inter.values) || total;
                }
            }
            total = (sq) ? (this.IsOneSquareInArrPospoint(inter.PosPoints)) ?
                this.matrix.ClearValuesInSetInSquare(new PosSquare(inter.PosPoints[0]), inter.values, inter.PosPoints) || total : total : total;
            total = (lh) ? (this.IsPosPointsInHorizontalLine(inter.PosPoints)) ?
                this.matrix.ClearValuesInSetInHorizontalLine(inter.PosPoints[0].i, inter.values, inter.PosPoints) || total : total : total;
            total = (lv) ? (this.IsPosPointsInVerticalLine(inter.PosPoints)) ?
                this.matrix.ClearValuesInSetInVerticalLine(inter.PosPoints[0].j, inter.values, inter.PosPoints) || total : total : total;
            return total;
        }

        private bool Full_House()
        {
            // Horizontal Line
            for (int i = 0; i < 9; i++)
            {
                if (this.matrix.IsOneNullInHorizontalLine(i))
                {
                    PosPoint pos_p = this.matrix.GetPosPointNullHorizontalLine(i);
                    this.SetValue(pos_p, this.matrix.GetFirstValueSetInPosPoint(pos_p));
                    return true;
                }
            }
            // Verticall Line
            for (int i = 0; i < 9; i++)
            {
                if (this.matrix.IsOneNullInVerticallLine(i))
                {
                    PosPoint pos_p = this.matrix.GetPosPointNullVerticalLine(i);
                    this.SetValue(pos_p, this.matrix.GetFirstValueSetInPosPoint(pos_p));
                    return true;
                }
            }
            // Square
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PosSquare pos_s = new PosSquare(i, j);
                    if (this.matrix.IsOneNullInSquare(pos_s))
                    {
                        PosPoint pos_p = this.matrix.GetPosPointNullSquare(pos_s);
                        this.SetValue(pos_p, this.matrix.GetFirstValueSetInPosPoint(pos_p));
                        return true;
                    }
                }
            }
            return false;
        }
        private bool Naked_Single()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (this.matrix.IsNullInPosPoint(new PosPoint(i, j)))
                    {
                        if (this.matrix.IsOnePossibleValueInPosPoint(new PosPoint(i, j)))
                        {
                            this.SetValue(new PosPoint(i, j), this.matrix.GetFirstValueSetInPosPoint(new PosPoint(i, j)));
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool Hidden_Single()
        {
            for (byte value = 1; value < 10; value++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (this.matrix.GetCountPossiblePosPointInHorizontalLine(i, value) == 1)
                    {
                        this.SetValue(this.matrix.GetFirstPossiblePosPointInHorizontalLine(i, value), value);
                        return true;
                    }
                }
                for (int i = 0; i < 9; i++)
                {
                    if (this.matrix.GetCountPossiblePosPointInVerticalLine(i, value) == 1)
                    {
                        this.SetValue(this.matrix.GetFirstPossiblePosPointInVerticalLine(i, value), value);
                        return true;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (this.matrix.GetCountPossiblePosPointInSquare(new PosSquare(i, j), value) == 1)
                        {
                            this.SetValue(this.matrix.GetFirstPossiblePosPointInSquare(new PosSquare(i, j), value), value);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool Clear_Singles()
        {
            bool total = false;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    PosPoint pos = new PosPoint(i, j);
                    if (this.matrix.IsNullInPosPoint(pos))
                    {
                        if (this.matrix.IsOnePossibleValueInPosPoint(pos))
                        {
                            total = this.matrix.ClearValueInSetInSquare(new PosSquare(pos), this.matrix.GetFirstValueSetInPosPoint(pos), new Arrange<PosPoint>(pos)) || total;
                            total = this.matrix.ClearValueInSetInHorizontalLine(i, this.matrix.GetFirstValueSetInPosPoint(pos), new Arrange<PosPoint>(pos)) || total;
                            total = this.matrix.ClearValueInSetInVerticalLine(j, this.matrix.GetFirstValueSetInPosPoint(pos), new Arrange<PosPoint>(pos)) || total;
                        }
                    }
                }
            }
            return total;
        }
        private bool Locked_Pair()
        {
            bool total = false;
            for (int si = 0; si < 3; si++)
            {
                for (int sj = 0; sj < 3; sj++)
                {
                    PosSquare pos_s = new PosSquare(si, sj);
                    Arrange<Intersections> pairs = this.matrix.GetLockedPairInSquare(pos_s);
                    for (int i = 0; i < pairs.Count(); i++)
                    {
                        total = this.Intersections_Handler(pairs[i], false, true, false, false);
                    }
                }
            }
            return total;
        }
        private bool Locked_Triple()
        {
            bool total = false;
            for (int si = 0; si < 3; si++)
            {
                for (int sj = 0; sj < 3; sj++)
                {
                    PosSquare pos_s = new PosSquare(si, sj);
                    Arrange<Intersections> tripls = this.matrix.GetLockedTripleInSquare(pos_s);
                    for (int i = 0; i < tripls.Count(); i++)
                    {
                        total = this.Intersections_Handler(tripls[i], false, true, false, false) || total;
                    }
                }
            }
            return total;
        }
        private bool Locked_Candidates_Type_Pointing()
        {
            bool total = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PosSquare pos_s = new PosSquare(i, j);
                    for (byte value = 1; value < 10; value++)
                    {
                        int size_ = this.matrix.GetCountPossiblePosPointInSquare(pos_s, value);
                        if (size_ == 3 || size_ == 2)
                        {
                            Arrange<PosPoint> arr = this.matrix.GetPossPosPointsInSquare(pos_s, value);
                            bool t_i = this.IsPosPointsInHorizontalLine(arr), t_j = this.IsPosPointsInVerticalLine(arr);
                            total = (t_i) ? this.matrix.ClearValueInSetInHorizontalLine(arr[0].i, value, arr) || total :
                                    (t_j) ? this.matrix.ClearValueInSetInVerticalLine(arr[0].j, value, arr) || total : total;
                        }
                    }
                }
            }
            return total;
        }
        private bool Locked_Candidates_Type_Claiming()
        {
            bool total = false;
            for (byte value = 1; value < 10; value++)
            {
                for (int i = 0; i < 9; i++)
                {
                    int count_h = this.matrix.GetCountPossiblePosPointInHorizontalLine(i, value);
                    if (count_h <= 3 && count_h >= 2)
                    {
                        Arrange<PosPoint> arr = this.matrix.GetPossPosPointsInHorizontalLine(i, value);
                        total = (this.IsOneSquareInArrPospoint(arr)) ? this.matrix.ClearValueInSetInSquare(new PosSquare(arr[0]), value, arr) || total : total;
                    }
                    int count_v = this.matrix.GetCountPossiblePosPointInVerticalLine(i, value);
                    if (count_v <= 3 && count_v >= 2)
                    {
                        Arrange<PosPoint> arr = this.matrix.GetPossPosPointsInVerticalLine(i, value);
                        total = (this.IsOneSquareInArrPospoint(arr)) ? this.matrix.ClearValueInSetInSquare(new PosSquare(arr[0]), value, arr) || total : total;
                    }
                }
            }
            return total;
        }
        private bool Naked_Pair()
        {
            bool total = false;
            for (int i = 0; i < 9; i++)
            {
                Arrange<Intersections> pairs_h = this.matrix.GetLockedPairInHorizontalLine(i);
                for (int j = 0; j < pairs_h.Count(); j++)
                {
                    total = this.Intersections_Handler(pairs_h[j], false, false, true, false) || total;
                }
                Arrange<Intersections> pairs_v = this.matrix.GetLockedPairInVerticalLine(i);
                for (int j = 0; j < pairs_v.Count(); j++)
                {
                    total = this.Intersections_Handler(pairs_v[j], false, false, false, true) || total;
                }
            }
            return total;
        }
        private bool Naked_Triple()
        {
            bool total = false;
            for (int i = 0; i < 9; i++)
            {
                Arrange<Intersections> triples_h = this.matrix.GetLockedTripleInHorizontalLine(i);
                for (int j = 0; j < triples_h.Count(); j++)
                {
                    total = this.Intersections_Handler(triples_h[j], false, false, true, false) || total;
                }
                Arrange<Intersections> triples_v = this.matrix.GetLockedTripleInVerticalLine(i);
                for (int j = 0; j < triples_v.Count(); j++)
                {
                    total = this.Intersections_Handler(triples_v[j], false, false, false, true) || total;
                }
            }
            return total;
        }
        private bool Naked_Quadruple()
        {
            bool total = false;
            for (int i = 0; i < 9; i++)
            {
                Arrange<Intersections> quadruple_h = this.matrix.GetNakedQuadrupleInHorizontalLine(i);
                for (int j = 0; j < quadruple_h.Count(); j++)
                {
                    total = this.Intersections_Handler(quadruple_h[j], false, false, true, false) || total;
                }
                Arrange<Intersections> quadruple_v = this.matrix.GetNakedQuadrupleInVerticalLine(i);
                for (int j = 0; j < quadruple_v.Count(); j++)
                {
                    total = this.Intersections_Handler(quadruple_v[j], false, false, false, true) || total;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Arrange<Intersections> quadruple_s = this.matrix.GetNakedQuadrupleInSquare(new PosSquare(i, j));
                    for (int x = 0; x < quadruple_s.Count(); x++)
                    {
                        total = this.Intersections_Handler(quadruple_s[x], false, true, false, false) || total;
                    }
                }
            }
            return total;
        }
        private bool Hidden_Pair()
        {
            bool total = false;
            for (int i = 0; i < 9; i++)
            {
                Arrange<Intersections> pairs_h = this.matrix.GetHiddenPairInHorizontalLine(i);
                for (int j = 0; j < pairs_h.Count(); j++)
                {
                    total = this.Intersections_Handler(pairs_h[j], true, false, true, false) || total;
                }
                Arrange<Intersections> pairs_v = this.matrix.GetHiddenPairInVerticalLine(i);
                for (int j = 0; j < pairs_v.Count(); j++)
                {
                    total = this.Intersections_Handler(pairs_v[j], true, false, false, true) || total;
                }
            }
            for (int si = 0; si < 3; si++)
            {
                for (int sj = 0; sj < 3; sj++)
                {
                    Arrange<Intersections> pairs = this.matrix.GetHiddenPairInSquare(new PosSquare(si, sj));
                    for (int i = 0; i < pairs.Count(); i++)
                    {
                        total = this.Intersections_Handler(pairs[i], true, true, false, false) || total;
                    }
                }
            }
            return total;
        }
        private bool Hidden_Triple()
        {
            bool total = false;
            for (int i = 0; i < 9; i++)
            {
                Arrange<Intersections> triples_h = this.matrix.GetHiddenTripleInHorizontalLine(i);
                for (int j = 0; j < triples_h.Count(); j++)
                {
                    total = this.Intersections_Handler(triples_h[j], true, false, false, false) || total;
                }
                Arrange<Intersections> triples_v = this.matrix.GetHiddenTripleInVerticalLine(i);
                for (int j = 0; j < triples_v.Count(); j++)
                {
                    total = this.Intersections_Handler(triples_v[j], true, false, false, false) || total;
                }
            }
            for (int si = 0; si < 3; si++)
            {
                for (int sj = 0; sj < 3; sj++)
                {
                    Arrange<Intersections> triples = this.matrix.GetHiddenTripleInSquare(new PosSquare(si, sj));
                    for (int j = 0; j < triples.Count(); j++)
                    {
                        total = this.Intersections_Handler(triples[j], true, false, false, false) || total;
                    }
                }
            }
            return total;
        }
        private bool Hidden_Quadruple()
        {
            bool total = false;
            for (int i = 0; i < 9; i++)
            {
                Arrange<Intersections> quadruple_h = this.matrix.GetHiddenQuadrupleInHorizontalLine(i);
                for (int j = 0; j < quadruple_h.Count(); j++)
                {
                    total = this.Intersections_Handler(quadruple_h[j], true, false, false, false) || total;
                }
                Arrange<Intersections> quadruple_v = this.matrix.GetHiddenQuadrupleInVerticalLine(i);
                for (int j = 0; j < quadruple_v.Count(); j++)
                {
                    total = this.Intersections_Handler(quadruple_v[j], true, false, false, false) || total;
                }
            }
            for (int si = 0; si < 3; si++)
            {
                for (int sj = 0; sj < 3; sj++)
                {
                    Arrange<Intersections> quadruple_s = this.matrix.GetHiddenQuadrupleInSquare(new PosSquare(si, sj));
                    for (int j = 0; j < quadruple_s.Count(); j++)
                    {
                        total = this.Intersections_Handler(quadruple_s[j], true, false, false, false) || total;
                    }
                }
            }
            return total;
        }
        public bool loop()
        {
            while (true)
            {
                if (this.Full_House()) { return true; }
                else if (this.Naked_Single()) { return true; }
                else if (this.Hidden_Single()) { return true; }
                //else if (this.Clear_Singles()) { continue; }
                else if (this.Locked_Pair()) { continue; }
                else if (this.Locked_Triple()) { return true; }
                else if (this.Locked_Candidates_Type_Pointing()) { continue; }
                else if (this.Locked_Candidates_Type_Claiming()) { continue; }
                else if (this.Naked_Pair()) { continue; }
                else if (this.Naked_Triple()) { continue; }
                else if (this.Naked_Quadruple()) { continue; }
                else if (this.Hidden_Pair()) { continue; }
                else if (this.Hidden_Triple()) { continue; }
                else if (this.Hidden_Quadruple()) { continue; }
                else { return false; }
            }
            return false;
        }
    }
}
