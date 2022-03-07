using JsonDiffProgram.Entity;

namespace JsonDiffProgram.Dto
{
    //Input DTO for SetLeft, SetRight
    public class DiffDtos
    {
        public string Data { get; set; }
    }

    //Output DTO for GetItem DIFF
    public class DiffResultDto
    {
        public string DiffResultType { get; set; }
        public List<DiffItemDifference> Diffs { get; set; }
    }
}
