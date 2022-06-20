using Xunit;

namespace Yatzy.Test
{
    public class YatzyTest
    {
        [Fact]
        public void Chance_scores_sum_of_all_dice()
        {
            var expected = 15;
            var actual = new Yatzy(2, 3, 4, 5, 1).Chance();
            Assert.Equal(expected, actual);
            Assert.Equal(16, new Yatzy(3, 3, 4, 5, 1).Chance());
        }

        [Fact]
        public void CheckForOnePair()
        {
            Assert.Equal(6, new Yatzy(3, 4, 3, 5, 6).ScorePair());
            Assert.Equal(10, new Yatzy(5, 3, 3, 3, 5).ScorePair());
            Assert.Equal(12, new Yatzy(5, 3, 6, 6, 5).ScorePair());
        }

        [Fact]
        public void CheckForTwoPairs()
        {
            Assert.Equal(16, new Yatzy(3, 3, 5, 4, 5).TwoPair());
            Assert.Equal(16, new Yatzy(3, 3, 5, 5, 5).TwoPair());
        }

        [Fact]
        public void SumOfAllOnesInDices()
        {
            Assert.True(new Yatzy(1, 2, 3, 4, 5).Ones() == 1);
            Assert.Equal(2, new Yatzy(1, 2, 1, 4, 5).Ones());
            Assert.Equal(0, new Yatzy(6, 2, 2, 4, 5).Ones());
            Assert.Equal(4, new Yatzy(1, 2, 1, 1, 1).Ones());
        }

        [Fact]
        public void SumOfAllTwosInDices()
        {
            Assert.Equal(4, new Yatzy(1, 2, 3, 2, 6).Twos());
            Assert.Equal(10, new Yatzy(2, 2, 2, 2, 2).Twos());
        }

        [Fact]
        public void SumOfAllThreesInDices()
        {
            Assert.Equal(6, new Yatzy(1, 2, 3, 2, 3).Threes());
            Assert.Equal(12, new Yatzy(2, 3, 3, 3, 3).Threes());
        }

        [Fact]
        public void SumOfAllFoursInDices()
        {
            Assert.Equal(12, new Yatzy(4, 4, 4, 5, 5).Fours());
            Assert.Equal(8, new Yatzy(4, 4, 5, 5, 5).Fours());
            Assert.Equal(4, new Yatzy(4, 5, 5, 5, 5).Fours());
        }
        [Fact]
        public void SumOfAllFivesInDices()
        {
            Assert.Equal(10, new Yatzy(4, 4, 4, 5, 5).Fives());
            Assert.Equal(15, new Yatzy(4, 4, 5, 5, 5).Fives());
            Assert.Equal(20, new Yatzy(4, 5, 5, 5, 5).Fives());
        }

        [Fact]
        public void SumOfAllSixesInDices()
        {
            Assert.Equal(0, new Yatzy(4, 4, 4, 5, 5).Sixes());
            Assert.Equal(6, new Yatzy(4, 4, 6, 5, 5).Sixes());
            Assert.Equal(18, new Yatzy(6, 5, 6, 6, 5).Sixes());
        }

        [Fact]
        public void CheckThreeOfAKind()
        {
            Assert.Equal(9, new Yatzy(3, 3, 3, 4, 5).ThreeOfAKind());
            Assert.Equal(15, new Yatzy(5, 3, 5, 4, 5).ThreeOfAKind());
            Assert.Equal(9, new Yatzy(3, 3, 3, 3, 5).ThreeOfAKind());
        }
        [Fact]
        public void CheckFourOfAKind()
        {
            Assert.Equal(12, new Yatzy(3, 3, 3, 3, 5).FourOfAKind());
            Assert.Equal(20, new Yatzy(5, 5, 5, 4, 5).FourOfAKind());
            Assert.Equal(12, new Yatzy(3, 3, 3, 3, 3).FourOfAKind());
        }

        [Fact]
        public void CheckForASmallStraight()
        {
            Assert.Equal(15, new Yatzy(1, 2, 3, 4, 5).SmallStraight());
            Assert.Equal(15, new Yatzy(2, 3, 4, 5, 1).SmallStraight());
            Assert.Equal(0, new Yatzy(1, 2, 2, 4, 5).SmallStraight());
        }

        [Fact]
        public void CheckForLargeStraight()
        {
            Assert.Equal(20, new Yatzy(6, 2, 3, 4, 5).LargeStraight());
            Assert.Equal(20, new Yatzy(2, 3, 4, 5, 6).LargeStraight());
            Assert.Equal(0, new Yatzy(1, 2, 2, 4, 5).LargeStraight());
        }
        [Fact]
        public void CheckForFullHouse()
        {
            Assert.Equal(18, new Yatzy(6, 2, 2, 2, 6).FullHouse());
            Assert.Equal(0, new Yatzy(2, 3, 4, 5, 6).FullHouse());
        }

        [Fact]
        public void CheckForYatzyToSum50Points()
        {
            var expected = 50;
            var actual = new Yatzy(4, 4, 4, 4, 4).CheckForYatzy();
            Assert.Equal(expected, actual);
            Assert.Equal(50, new Yatzy(6, 6, 6, 6, 6).CheckForYatzy());
            Assert.Equal(0, new Yatzy(6, 6, 6, 6, 3).CheckForYatzy());
        }
    }
}