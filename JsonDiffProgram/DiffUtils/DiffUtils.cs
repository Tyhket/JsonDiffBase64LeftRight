using JsonDiffProgram.Entity;

namespace JsonDiffProgram.DiffUtils
{
    public static class DiffUtils
    {
        //Returns true if Base64 decoded value are equal size
        public static bool IsEqualSize(string leftBase64, string rightBase64)
        {
            var left = Convert.FromBase64String(leftBase64);
            var right = Convert.FromBase64String(rightBase64);

            return left.Length == right.Length;
        }

        //Returns true if array lengths are equal
        public static bool IsEqualSize(byte[] left, byte[] right)
        {
            return left.Length == right.Length;
        }

        //Returns a list of all diffrences by array position
        public static List<DiffItemDifference> GetDifferences(string leftBase64, string rightBase64)
        {
            var result = new List<DiffItemDifference>();

            var left = Convert.FromBase64String(leftBase64);
            var right = Convert.FromBase64String(rightBase64);

            if (!IsEqualSize(left, right) || left.Length == 0)
            {
                return result;
            }

            var isEqual = true;
            var notEqualIndex = 0;
            for (int i = 0; i < left.Length; i++)
            {
                var nextIsEqual = left[i] == right[i];

                if (isEqual && !nextIsEqual)
                {
                    notEqualIndex = i;
                    isEqual = false;
                }
                else if (!isEqual && nextIsEqual)
                {
                    isEqual = true;
                    result.Add(new DiffItemDifference
                    {
                        Offset = notEqualIndex,
                        Length = i - notEqualIndex,
                    });
                }
            }
            //check if last byte(s) is not equal and add to result
            if (!isEqual)
            {
                result.Add(new DiffItemDifference
                {
                    Offset = notEqualIndex,
                    Length = left.Length - notEqualIndex,
                });
            }
            return result;
        }
    }
}
