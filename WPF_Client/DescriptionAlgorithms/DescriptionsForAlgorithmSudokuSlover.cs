using SudokuSloverHendler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client.DescriptionAlgorithms
{
    public class DescriptionsForAlgorithmSudokuSlover : Expansion.SingletonClass<DescriptionsForAlgorithmSudokuSlover>
    {
        
        public Dictionary<AlgorithmSudokuSlover, string> Descriptions { get; set; }
        public DescriptionsForAlgorithmSudokuSlover()
        {
            this.Descriptions = new Dictionary<AlgorithmSudokuSlover, string>();
            this.Descriptions.Add(AlgorithmSudokuSlover.None, Description.Instance.None);
            this.Descriptions.Add(AlgorithmSudokuSlover.Full_House, Description.Instance.Full_House);
            this.Descriptions.Add(AlgorithmSudokuSlover.Naked_Single, Description.Instance.Naked_Single);
            this.Descriptions.Add(AlgorithmSudokuSlover.Hidden_Single, Description.Instance.Hidden_Single);
            this.Descriptions.Add(AlgorithmSudokuSlover.Locked_Pair, Description.Instance.Locked_Pair);
            this.Descriptions.Add(AlgorithmSudokuSlover.Locked_Triple, Description.Instance.Locked_Triple);
            this.Descriptions.Add(AlgorithmSudokuSlover.Locked_Candidates_Type_Pointing, Description.Instance.Locked_Candidates_Type_Pointing);
            this.Descriptions.Add(AlgorithmSudokuSlover.Locked_Candidates_Type_Claiming, Description.Instance.Locked_Candidates_Type_Claiming);
            this.Descriptions.Add(AlgorithmSudokuSlover.Naked_Pair, Description.Instance.Naked_Pair);
            this.Descriptions.Add(AlgorithmSudokuSlover.Naked_Triple, Description.Instance.Naked_Triple);
            this.Descriptions.Add(AlgorithmSudokuSlover.Naked_Quadruple, Description.Instance.Naked_Quadruple);
            this.Descriptions.Add(AlgorithmSudokuSlover.Hidden_Pair, Description.Instance.Hidden_Pair);
            this.Descriptions.Add(AlgorithmSudokuSlover.Hidden_Triple, Description.Instance.Hidden_Triple);
            this.Descriptions.Add(AlgorithmSudokuSlover.Hidden_Quadruple, Description.Instance.Hidden_Quadruple);
        }
        public string GetDescription(AlgorithmSudokuSlover al)
        {
            return this.Descriptions.TryGetValue(al, out string description) ? description : string.Empty;
        }
    }
    internal class Description : Expansion.SingletonClass<Description>
    {
        public string None = @"";
        public string Full_House = @"";
        public string Naked_Single = @"";
        public string Hidden_Single = @"";
        public string Locked_Pair = @"";
        public string Locked_Triple = @"";
        public string Locked_Candidates_Type_Pointing = @"";
        public string Locked_Candidates_Type_Claiming = @"";
        public string Naked_Pair = @"";
        public string Naked_Triple = @"";
        public string Naked_Quadruple = @"";
        public string Hidden_Pair = @"";
        public string Hidden_Triple = @"";
        public string Hidden_Quadruple = @"";
    }
}
