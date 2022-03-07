using JsonDiffProgram.DiffUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JsonDiffProgramTest.Unit_Test
{
    public class DiffUtilsTest
    {
        [Fact]
        public static void IsEqualSize_Checks_If_Base64_Values_Are_Equal_Size()
        {
            string leftBase64 = "VGVzdDEyMw==";
            string rightBase64 = "VGVzdDEyMw==";
            Assert.Equal(true, DiffUtils.IsEqualSize(leftBase64, rightBase64));

        }
        [Fact]
        public static void IsEqualSize_Checks_If_Base64_Values_Are_Not_Equal()
        {
            string leftBase64 = "VGVzdDEyMw==";
            string rightBase64 = "VGVzdDEyMzEyMw==";
            Assert.NotEqual(true, DiffUtils.IsEqualSize(leftBase64, rightBase64));

        }
        [Fact]
        public static void IsEqualSize_Checks_If_Base64_ArraySizes_are_Equal()
        {
            byte[] left = Convert.FromBase64String("VGVzdDEyMw==");
            byte[] right = Convert.FromBase64String("VGVzdDEyMw==");
            Assert.Equal(true, DiffUtils.IsEqualSize(left, right));

        }
        [Fact]
        public static void IsEqualSize_Checks_If_Base64_ArraySizes_are_Not_Equal()
        {
            byte[] left = Convert.FromBase64String("VGVzdDEyMw==");
            byte[] right = Convert.FromBase64String("VGVzdDEyMzEyMw==");
            Assert.NotEqual(true, DiffUtils.IsEqualSize(left, right));

        }
    }
}
