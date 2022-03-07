namespace JsonDiffProgram.Entity
{
    //Values diffrences list
    public class DiffItemDifference
    {
        public int Offset { get; set; }
        public int Length { get; set; }
    }

    //Item DIFF result
    public class DiffResult
    {
        public DiffResultsEnum ResultCode { get; set; } = DiffResultsEnum.Undefined;
        public List<DiffItemDifference> Diffs { get; set; }
    }

    //Item data and result
    public class DiffItem
    {
        public int Id { get; set; }
        public string Left { get; set; } = null;
        public string Right { get; set; } = null;
        public DiffResult Result { get; set; } = new DiffResult();
    }
}
