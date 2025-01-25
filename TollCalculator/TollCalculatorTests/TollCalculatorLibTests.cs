using TollCalculatorLib;
using TollCalculatorLib.Model;

namespace TollCalculatorTests
{
    [TestClass]
    public class TollCalculatorLibTests
    {

        private readonly IDictionary<DateTime, int> tollFeeWeekDay = new Dictionary<DateTime, int>
        {
            {new DateTime(2025, 1, 20, 6, 0, 0), 8},
            {new DateTime(2025, 1, 20, 6, 30, 0), 13},
            {new DateTime(2025, 1, 20, 7, 0, 0), 18},
            {new DateTime(2025, 1, 20, 8, 0, 0), 13},
            {new DateTime(2025, 1, 20, 8, 30, 0), 8},
            {new DateTime(2025, 1, 20, 15, 0, 0), 13},
            {new DateTime(2025, 1, 20, 15, 30, 0), 18},
            {new DateTime(2025, 1, 20, 17, 0, 0), 13},
            {new DateTime(2025, 1, 20, 18, 0, 0), 8},
            {new DateTime(2025, 1, 20, 18, 30, 0), 0}
        };

        private readonly IDictionary<DateTime, int> tollFeeWeekendDay = new Dictionary<DateTime, int>
        {
            {new DateTime(2025, 1, 25, 6, 0, 0), 0},
            {new DateTime(2025, 1, 25, 6, 30, 0), 0},
            {new DateTime(2025, 1, 25, 7, 0, 0), 0},
            {new DateTime(2025, 1, 25, 8, 0, 0), 0},
            {new DateTime(2025, 1, 25, 8, 30, 0), 0},
            {new DateTime(2025, 1, 25, 15, 0, 0), 0},
            {new DateTime(2025, 1, 25, 15, 30, 0), 0},
            {new DateTime(2025, 1, 25, 17, 0, 0), 0},
            {new DateTime(2025, 1, 25, 18, 0, 0), 0},
            {new DateTime(2025, 1, 25, 18, 30, 0), 0}
        };

        private readonly Car _car;
        private readonly Motorbike _motorbike;

        private TollCalculator _tollCalculator;

        public TollCalculatorLibTests()
        {
            _car = new Car();
            _motorbike = new Motorbike();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _tollCalculator = new TollCalculator();
        }


        [TestMethod]
        public void Test_GetTollFee_Array_SinglePassageAtDifferentTimes_WithCar_OnWeekDay()
        {            
            foreach (var tollFee in tollFeeWeekDay)
            {
                var fee = _tollCalculator.GetTollFee(_car, [tollFee.Key]);
                Assert.AreEqual(tollFee.Value, fee);
            }
        }

        [TestMethod]
        public void Test_GetTollFee_SingleDateTime_SinglePassageAtDifferentTimes_WithCar_OnWeekDay()
        {
            foreach (var tollFee in tollFeeWeekDay)
            {
                var fee = _tollCalculator.GetTollFee(tollFee.Key, _car);
                Assert.AreEqual(tollFee.Value, fee);
            }
        }


        [TestMethod]
        public void Test_GetTollFee_Array_SinglePassageAtDifferentTimes_WithCar_OnWeekendDay()
        {
            foreach (var tollFee in tollFeeWeekendDay)
            {
                var fee = _tollCalculator.GetTollFee(_car, [tollFee.Key]);
                Assert.AreEqual(tollFee.Value, fee);
            }
        }

        [TestMethod]
        public void Test_GetTollFee_SingleDateTime_SinglePassageAtDifferentTimes_WithCar_OnWeekendDay()
        {            
            foreach (var tollFee in tollFeeWeekendDay)
            {
                var fee = _tollCalculator.GetTollFee(tollFee.Key, _car);
                Assert.AreEqual(tollFee.Value, fee);
            }
        }




        [TestMethod]
        public void Test_GetTollFee_Array_SinglePassageAtDifferentTimes_WithMotorbike_OnWeekDay()
        {
            var expectedFee = 0;
            foreach (var tollFee in tollFeeWeekDay)
            {
                var fee = _tollCalculator.GetTollFee(_motorbike, [tollFee.Key]);
                Assert.AreEqual(expectedFee, fee);
            }
        }

        [TestMethod]
        public void Test_GetTollFee_SingleDateTime_SinglePassageAtDifferentTimes_WithMotorbike_OnWeekDay()
        {
            var expectedFee = 0;
            foreach (var tollFee in tollFeeWeekDay)
            {
                var fee = _tollCalculator.GetTollFee(tollFee.Key, _motorbike);
                Assert.AreEqual(expectedFee, fee);
            }
        }


        [TestMethod]
        public void Test_GetTollFee_Array_SinglePassageAtDifferentTimes_WithMotorbike_OnWeekendDay()
        {
            var expectedFee = 0;
            foreach (var tollFee in tollFeeWeekendDay)
            {
                var fee = _tollCalculator.GetTollFee(_motorbike, [tollFee.Key]);
                Assert.AreEqual(expectedFee, fee);
            }
        }

        [TestMethod]
        public void Test_GetTollFee_SingleDateTime_SinglePassageAtDifferentTimes_WithMotorbike_OnWeekendDay()
        {
            var expectedFee = 0;
            foreach (var tollFee in tollFeeWeekendDay)
            {
                var fee = _tollCalculator.GetTollFee(tollFee.Key, _motorbike);
                Assert.AreEqual(expectedFee, fee);
            }
        }

        [TestMethod]
        public void Test_GetTollFee_NoTollInJuly()
        {
            for(int i = 1; i < 31; i++){
                var date = new DateTime(2025, 7, i, 0, 0, 0);
                foreach(var interval in Constants.TollIntervals)
                {
                    var testDate = date.Add(interval.StartTime);
                    var fee = _tollCalculator.GetTollFee(testDate, _car);
                    Assert.AreEqual(0, fee);
                }                
            };
        }

        [TestMethod]
        public void Test_GetTollFee_NoTollDuringChristmas()
        {
            for (int i = 24; i < 26; i++)
            {
                var date = new DateTime(2025, 12, i, 0, 0, 0);
                foreach (var interval in Constants.TollIntervals)
                {
                    var testDate = date.Add(interval.StartTime);
                    var fee = _tollCalculator.GetTollFee(testDate, _car);
                    Assert.AreEqual(0, fee);
                }
            };
        }

        [TestMethod]
        public void Test_GetTollFee_NoTollFirstOfMayOrLastOfApril()
        {
            List<DateTime> dates = [new DateTime(2025, 4, 30, 0, 0, 0), new DateTime(2025, 5, 1, 0, 0, 0)];
            
            foreach (var date in dates)
            {
                foreach (var interval in Constants.TollIntervals)
                {
                    var testDate = date.Add(interval.StartTime);
                    var fee = _tollCalculator.GetTollFee(testDate, _car);
                    Assert.AreEqual(0, fee);
                }            
            }
        }
    }
}