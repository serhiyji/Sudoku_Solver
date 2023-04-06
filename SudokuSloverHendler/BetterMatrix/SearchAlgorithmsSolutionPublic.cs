using SudokuSloverHendler.Collections;
using SudokuSloverHendler.Coordinates;
using SudokuSloverHendler.Matrix;
using SudokuSloverHendler.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSloverHendler.BetterMatrix
{
    public partial class BetterMatrix : Matrix<Point>
    {
        public Arrange<Intersections> GetLockedPairInHorizontalLine(int index)
        { return this.GetLockedPairInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public Arrange<Intersections> GetLockedPairInVerticalLine(int index)
        { return this.GetLockedPairInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public Arrange<Intersections> GetLockedPairInSquare(PosSquare pos_s)
        { return this.GetLockedPairInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
        // Locked Triple
        public Arrange<Intersections> GetLockedTripleInHorizontalLine(int index)
        { return this.GetLockedTripleInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public Arrange<Intersections> GetLockedTripleInVerticalLine(int index)
        { return this.GetLockedTripleInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public Arrange<Intersections> GetLockedTripleInSquare(PosSquare pos_s)
        { return this.GetLockedTripleInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
        // Hiden pair
        public Arrange<Intersections> GetHiddenPairInHorizontalLine(int index)
        { return this.GetHiddenPairInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public Arrange<Intersections> GetHiddenPairInVerticalLine(int index)
        { return this.GetHiddenPairInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public Arrange<Intersections> GetHiddenPairInSquare(PosSquare pos_s)
        { return this.GetHiddenPairInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
        // Hiden Truple
        public Arrange<Intersections> GetHiddenTripleInHorizontalLine(int index)
        { return this.GetHiddenTripleInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public Arrange<Intersections> GetHiddenTripleInVerticalLine(int index)
        { return this.GetHiddenTripleInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public Arrange<Intersections> GetHiddenTripleInSquare(PosSquare pos_s)
        { return this.GetHiddenTripleInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
        // Naked Quadruple
        public Arrange<Intersections> GetNakedQuadrupleInHorizontalLine(int index)
        { return this.GetNakedQuadrupleInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public Arrange<Intersections> GetNakedQuadrupleInVerticalLine(int index)
        { return this.GetNakedQuadrupleInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public Arrange<Intersections> GetNakedQuadrupleInSquare(PosSquare pos_s)
        { return this.GetNakedQuadrupleInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
        // Hiden Quadruple
        public Arrange<Intersections> GetHiddenQuadrupleInHorizontalLine(int index)
        { return this.GetHiddenQuadrupleInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        public Arrange<Intersections> GetHiddenQuadrupleInVerticalLine(int index)
        { return this.GetHiddenQuadrupleInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        public Arrange<Intersections> GetHiddenQuadrupleInSquare(PosSquare pos_s)
        { return this.GetHiddenQuadrupleInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
    }
}
