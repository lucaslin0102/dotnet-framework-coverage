using dotnet_framework2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dotnet_frameworktests.DateDiffTestData;
using Xunit;

namespace dotnet_frameworktests
{
    public class DateDiffTests
    {
        [Theory]
        [MemberData(nameof(InvalidInputs), MemberType = typeof(DateDiffTestData))]
        public void InvalidInput_ThrowException(DateTime fromDate, DateTime toDate)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DateDiff(fromDate, toDate));
            Assert.Equal("The birthday must be earlier than the selected date.", exception.Message);
        }

        [Theory]
        [MemberData(nameof(ValidInputs), MemberType = typeof(DateDiffTestData))]
        public void ValidInput_Successful(DateTime fromDate, DateTime toDate, DateDiffResult expected)
        {
            var dateDiff = new DateDiff(fromDate, toDate);

            Assert.Equal(expected.Years, dateDiff.Years);
            Assert.Equal(expected.Months, dateDiff.Months);
            Assert.Equal(expected.Days, dateDiff.Days);
            Assert.Equal(expected.Distances, dateDiff.Distances);
            Assert.Equal(expected.ToString(), dateDiff.ToString());
        }
    }
}
