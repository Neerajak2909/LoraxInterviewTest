using System;
using Amazon.Runtime;
using InterviewTestQA.InterviewTestAutomation;
using Xunit;

namespace InterviewTestQA
{
    public class CalculatorTest
    {
        // Creating instance of Calculator class
        private Calculator _calculator;

        // Initializing using constructor
        public CalculatorTest()
        {
            _calculator = new Calculator();
        }

        // Testcase 1 : Addition of combinations of valid inputs of positive and negative numbers which returns the sum
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(6, 2, 8)]
        [InlineData(-6, -2, -8)]
        [InlineData(-6, 2, -4)]
        [InlineData(6, -2, 4)]
        [InlineData(6.5, 2, 8)]
        [InlineData(6, 2.5, 8)]
        [InlineData(99, 0, 99)]
        [InlineData(100, 0, 100)]
        public void AdditionTest_ValidInputs(int a, int b, int expectedResult)
        {
            int actualResult = _calculator.Add(a,b);
            Assert.Equal(expectedResult, actualResult);
        }

        // Testcase 2 : Subtraction of combinations of valid inputs of positive and negative numbers which returns the difference
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(6, 2, 4)]
        [InlineData(-6, -2, -4)]
        [InlineData(-6, 2, -8)]
        [InlineData(6, -2, 8)]
        [InlineData(6.5, 2, 4)]
        [InlineData(6, 2.5, 4)]
        [InlineData(99, 0, 99)]
        [InlineData(100, 0, 100)]
        public void SubtractionTest_ValidInputs(int a, int b, int expectedResult)
        {
            int actualResult = _calculator.Subtract(a, b);
            Assert.Equal(expectedResult, actualResult);
        }

        // Testcase 3 : Multiplication of combinations of valid inputs of positive and negative numbers which returns the product
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(6, 2, 12)]
        [InlineData(-6, -2, 12)]
        [InlineData(-6, 2, -12)]
        [InlineData(6, -2, -12)]
        [InlineData(6.5, 2, 12)]
        [InlineData(6, 2.5, 12)]
        [InlineData(99, 0, 0)]
        [InlineData(100, 0, 0)]
        public void MultiplicationTest_ValidInputs(int a, int b, int expectedResult)
        {
            int actualResult = _calculator.Multiply(a, b);
            Assert.Equal(expectedResult, actualResult);
        }

        // Testcase 4 : Division of combinations of valid inputs of positive and negative numbers which returns the quotient
        [Theory]
        [InlineData(0, 5, 0)]
        [InlineData(6, 2, 3)]
        [InlineData(-6, -2, 3)]
        [InlineData(-6, 2, -3)]
        [InlineData(6, -2, -3)]
        [InlineData(16, 3, 5)]
        [InlineData(6.5, 2, 3)]
        [InlineData(6, 2.5, 3)]
        [InlineData(0, 99, 0)]
        [InlineData(0, 100, 0)]
        public void DivisionTest_ValidInputs(int a, int b, int expectedResult)
        {
            int actualResult = _calculator.Divide(a, b);
            Assert.Equal(expectedResult, actualResult);
        }

        // Testcase 5 : Divide by zero invalid input which throws an exception
        [Fact]
        public void DivisionTest_DivideByZero()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Divide(100, 0));
        }

        // Testcase 6 : Square of valid inputs of positive and negative numbers which returns the square
        [Theory]
        [InlineData(0, 0)]
        [InlineData(6, 36)]
        [InlineData(-3, 9)]
        [InlineData(2.5, 4)]
        [InlineData(-2.5, 4)]
        public void SquareTest_ValidInputs(int a, int expectedResult)
        {
            int actualResult = _calculator.Square(a);
            Assert.Equal(expectedResult, actualResult);
        }

        // Testcase 7 : Square root of valid inputs of positive perfect square numbers which returns the square root
        [Theory]
        [InlineData(0, 0)]
        [InlineData(49, 7)]
        [InlineData(100, 10)]
        public void SquareRootTest_ValidInputs_PerfectSquares(int a, int expectedResult)
        {
            int actualResult = _calculator.SquareRoot(a);
            Assert.Equal(expectedResult, actualResult);
        }

        // Testcase 8 : Square root of valid inputs of positive non perfect square numbers which returns the square root
        [Theory]
        [InlineData(10, 3)]
        [InlineData(90, 9)]
        public void SquareRootTest_ValidInputs_NonPerfectSquares(int a, int expectedResult)
        {
            int actualResult = _calculator.SquareRoot(a);
            Assert.Equal(expectedResult, actualResult);
        }

        // Testcase 9 : Square root for invalid input of negative perfect square numbers which throws an exception
        [Fact]
        public void SquareRootTest_SqrtOfNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(-25));
        }
    }
}