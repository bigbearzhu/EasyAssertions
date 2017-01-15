﻿using NSubstitute;
using NUnit.Framework;

namespace EasyAssertions.UnitTests
{
    [TestFixture]
    public class NumberAssertionTests : AssertionTests
    {
        /* // None of the lines in the following method should compile 
        public void ShouldNotCompile()
        {
            new object().ShouldBe(1f);
            new object().ShouldBe(1f, "message");
            1f.ShouldBe(1f);
            1f.ShouldBe(1f, "message");
            new object().ShouldBe(1d);
            new object().ShouldBe(1d, "message");
            1d.ShouldBe(1d);
            1d.ShouldBe(1d, "message");
        }/**/

        [Test]
        public void ShouldBe_FloatsWithinDelta_ReturnsActualValue()
        {
            const float actual = 1f;
            Actual<float> result = actual.ShouldBe(1f, 1f);

            Assert.AreEqual(actual, result.And);
        }

        [Test]
        public void ShouldBe_FloatsWithinDoubleDelta_ReturnsActualValue()
        {
            const float actual = 1f;
            Actual<float> result = actual.ShouldBe(1f, 1d);

            Assert.AreEqual(actual, result.And);
        }

        [Test]
        public void ShouldBe_ActualNotAFloat_FailsWithTypesNotEqualMessage()
        {
            object actual = new object();
            MockFormatter.NotEqual(typeof(float), typeof(object), "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldBe(1f, 1f, "foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void ShouldBe_FloatsOutsideDelta_FailsWithObjectsNotEqualMessage()
        {
            const float expected = 10f;
            const float actual = 1f;
            MockFormatter.NotEqual(expected, actual, "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldBe(expected, 1f, "foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void ShouldBe_FloatsOutsideDoubleDelta_FailsWithObjectsNotEqualMessage()
        {
            const float expected = 10f;
            const float actual = 1f;
            MockFormatter.NotEqual(expected, actual, "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldBe(expected, 1d, "foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void ShouldBe_FloatsWithFloatDelta_CorrectlyRegistersAssertion()
        {
            const float actual = 1;
            const float expected = 1;

            actual.ShouldBe(expected, float.Epsilon);

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
            Assert.AreEqual(nameof(expected), TestExpression.GetExpected());
        }

        [Test]
        public void ShouldBe_FloatsWithDoubleDelta_CorrectlyRegistersAssertion()
        {
            const float actual = 1;
            const float expected = 1;

            actual.ShouldBe(expected, double.Epsilon);

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
            Assert.AreEqual(nameof(expected), TestExpression.GetExpected());
        }

        [Test]
        public void ShouldBe_DoublesWithinDelta_ReturnsActualValue()
        {
            const double actual = 1d;

            Actual<double> result = actual.ShouldBe(1d, 0);

            Assert.AreEqual(actual, result.And);
        }

        [Test]
        public void ShouldBe_ActualNotADouble_FailsWithTypesNotEqualMessage()
        {
            object actual = new object();
            MockFormatter.NotEqual(typeof(double), typeof(object), "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldBe(1d, 1d, "foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void ShouldBe_DoublesOutsideDelta_FailsWithObjectsNotEqualMessage()
        {
            const double expected = 10d;
            const double actual = 1d;
            MockFormatter.NotEqual(expected, actual, "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldBe(expected, 1d, "foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void ShouldBe_Doubles_CorrectlyRegistersAssertion()
        {
            const double actual = 1;
            const double expected = 1;

            actual.ShouldBe(expected, double.Epsilon);

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
            Assert.AreEqual(nameof(expected), TestExpression.GetExpected());
        }

        [Test]
        public void ShouldNotBe_FloatsOutsideDelta_ReturnsActualValue()
        {
            const float actual = 1f;
            Actual<float> result = actual.ShouldNotBe(2f, 0);

            Assert.AreEqual(actual, result.And);
        }

        [Test]
        public void ShouldNotBe_FloatsWithinDelta_FailsWithObjectsEqualMessage()
        {
            const float actual = 1f;
            const float notExpected = 2f;
            MockFormatter.AreEqual(notExpected, actual, "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldNotBe(notExpected, 1f, "foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void ShouldNotBe_Floats_CorrectlyRegistersAssertion()
        {
            const float actual = 1;
            const float notExpected = 2;

            actual.ShouldNotBe(notExpected, float.Epsilon);

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
            Assert.AreEqual(nameof(notExpected), TestExpression.GetExpected());
        }

        [Test]
        public void ShouldNotBe_DoublesOutsideDelta_ReturnsActualValue()
        {
            const double actual = 1d;

            Actual<double> result = actual.ShouldNotBe(2d, 0);

            Assert.AreEqual(actual, result.And);
        }

        [Test]
        public void ShouldNotBe_DoublesWithinDelta_FailsWithObjectsEqualMessage()
        {
            const double actual = 1d;
            const double notExpected = 2d;
            MockFormatter.AreEqual(notExpected, actual, "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldNotBe(notExpected, 1d, "foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void ShouldNotBe_Doubles_CorrectlyRegistersAssertion()
        {
            const double actual = 1;
            const double notExpected = 2;

            actual.ShouldNotBe(notExpected, double.Epsilon);

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
            Assert.AreEqual(nameof(notExpected), TestExpression.GetExpected());
        }

        [Test]
        public void ShouldBeGreaterThan_IsGreaterThan_ReturnsActualValue()
        {
            const int actual = 2;

            Actual<int> result = actual.ShouldBeGreaterThan(1);

            Assert.AreEqual(actual, result.And);
        }

        [Test]
        public void ShouldBeGreaterThan_NotGreaterThan_FailsWithNotGreaterThanMessage()
        {
            const int actual = 1;
            const int expected = 2;
            MockFormatter.NotGreaterThan(expected, actual, "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldBeGreaterThan(expected, "foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void ShouldBeGreaterThan_CorrectlyRegistersAssertion()
        {
            const int actual = 1;
            const int expected = 0;

            actual.ShouldBeGreaterThan(expected);

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
            Assert.AreEqual(nameof(expected), TestExpression.GetExpected());
        }

        [Test]
        public void ShouldBeLessThan_IsLessThan_ReturnsActualValue()
        {
            const int actual = 1;

            Actual<int> result = actual.ShouldBeLessThan(2);

            Assert.AreEqual(actual, result.And);
        }

        [Test]
        public void ShouldBeLessThan_NotLessThan_FailsWithNotLessThanMessage()
        {
            const int actual = 2;
            const int expected = 1;
            MockFormatter.NotLessThan(expected, actual, "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldBeLessThan(expected, "foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void ShouldBeLessThan_CorrectlyRegistersAssertion()
        {
            const int actual = 1;
            const int expected = 2;

            actual.ShouldBeLessThan(expected);

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
            Assert.AreEqual(nameof(expected), TestExpression.GetExpected());
        }

        [Test]
        public void FloatShouldBeNaN_IsNaN_Passes()
        {
            const float actual = float.NaN;

            actual.ShouldBeNaN();
        }

        [Test]
        public void FloatShouldBeNaN_IsNotNaN_FailsWithObjectsNotEqualMessage()
        {
            const float actual = 1f;
            MockFormatter.NotEqual(float.NaN, actual, "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldBeNaN("foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void FloatShouldBeNaN_CorrectlyRegistersAssertion()
        {
            const float actual = float.NaN;

            actual.ShouldBeNaN();

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
        }

        [Test]
        public void FloatShouldNotBeNaN_IsNotNaN_ReturnsActualValue()
        {
            const float actual = 1f;

            Actual<float> result = actual.ShouldNotBeNaN();

            Assert.AreEqual(actual, result.And);
        }

        [Test]
        public void FloatShouldNotBeNaN_IsNaN_FailsWithObjectsEqualMessage()
        {
            const float actual = float.NaN;
            MockFormatter.AreEqual(float.NaN, actual, "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldNotBeNaN("foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void FloatShouldNotBeNaN_CorrectlyRegistersAssertion()
        {
            const float actual = 1;

            actual.ShouldNotBeNaN();

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
        }

        [Test]
        public void DoubleShouldBeNaN_IsNaN_Passes()
        {
            const double actual = double.NaN;

            actual.ShouldBeNaN();
        }

        [Test]
        public void DoubleShouldBeNaN_IsNotNaN_FailsWithObjectsNotEqualMessage()
        {
            const double actual = 1d;
            MockFormatter.NotEqual(double.NaN, actual, "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldBeNaN("foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void DoubleShouldBeNaN_CorrectlyRegistersAssertion()
        {
            const double actual = double.NaN;

            actual.ShouldBeNaN();

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
        }

        [Test]
        public void DoubleShouldNotBeNaN_IsNotNaN_ReturnsActualValue()
        {
            const double actual = 1f;

            Actual<double> result = actual.ShouldNotBeNaN();

            Assert.AreEqual(actual, result.And);
        }

        [Test]
        public void DoubleShouldNotBeNaN_IsNaN_FailsWithObjectsEqualMessage()
        {
            const double actual = double.NaN;
            MockFormatter.AreEqual(double.NaN, actual, "foo").Returns("bar");

            EasyAssertionException result = Assert.Throws<EasyAssertionException>(() => actual.ShouldNotBeNaN("foo"));

            Assert.AreEqual("bar", result.Message);
        }

        [Test]
        public void DoubleShouldNotBeNaN_CorrectlyRegistersAssertion()
        {
            const double actual = 1;

            actual.ShouldNotBeNaN();

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
        }
    }
}
