using JsonDiffProgram.Entity;

namespace JsonDiffProgram.DiffStorage
{
    public class DiffStorage : IDiffStorage
    {
        public Dictionary<int, DiffItem> Data { get; set; } = new Dictionary<int, DiffItem>();

        //Validate that PUT (left, right) is not empty or invalid Base64 string
        private void ValidateInput(int id, string data)
        {
            if (id <= 0)
            {
                throw new System.ArgumentException("");
            }
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new System.ArgumentException("");
            }

            // check if data is correctly Base64 encoded
            var bytes = System.Convert.FromBase64String(data);
            if (bytes == null || bytes.Length == 0)
            {
                throw new System.ArgumentException("");
            }
        }

        //Get item's left & right diffrences if item exists
        public async Task<DiffResult> GetDiff(int id)
        {
            if (!Data.TryGetValue(id, out var item))
            {
                throw new System.InvalidOperationException("");
            }
            if (string.IsNullOrWhiteSpace(item.Left))
            {
                throw new System.InvalidOperationException("");
            }
            if (string.IsNullOrWhiteSpace(item.Right))
            {
                throw new System.InvalidOperationException("");
            }

            //if left Base64 equals right Base64 then data is also equal
            if (item.Left == item.Right)
            {
                item.Result.ResultCode = DiffResultsEnum.Equal;
            }
            //if Base64 lengths are not equal then data lenghts are also not equal
            else if (item.Left.Length != item.Right.Length)
            {
                item.Result.ResultCode = DiffResultsEnum.SizeDoNotMatch;
            }
            //if Base64 lengts are equal then data lenghts are not necessarily not equal
            else if (!DiffUtils.DiffUtils.IsEqualSize(item.Left, item.Right))
            {
                item.Result.ResultCode = DiffResultsEnum.SizeDoNotMatch;
            }
            //lenghts are equal, but values are not equal
            else
            {
                item.Result.ResultCode = DiffResultsEnum.ContentDoNotMatch;
                item.Result.Diffs = DiffUtils.DiffUtils.GetDifferences(item.Left, item.Right);
            }

            return item.Result;
        }

        //Remove an item from storage
        public async Task<bool> Remove(int id)
        {
            return Data.Remove(id);
        }

        //Set item's left value and add item to storage if it does not exist yet
        public async Task SetLeft(int id, string data)
        {
            ValidateInput(id, data);

            if (!Data.TryGetValue(id, out var item))
            {
                item = new DiffItem
                {
                    Id = id,
                    Left = data,
                };
                Data[id] = item;
            }
            else
            {
                item.Left = data;
            }
        }

        //Set item's right value and add item to storage if it does not exist yet
        public async Task SetRight(int id, string data)
        {
            ValidateInput(id, data);

            if (!Data.TryGetValue(id, out var item))
            {
                item = new DiffItem
                {
                    Id = id,
                    Right = data,
                };
                Data[id] = item;
            }
            else
            {
                item.Right = data;
            }
        }
    }
}

