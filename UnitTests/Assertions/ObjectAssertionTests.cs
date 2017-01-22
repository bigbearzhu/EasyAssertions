﻿using System;
using NSubstitute;
using NUnit.Framework;

namespace EasyAssertions.UnitTests
{
    [TestFixture]
    public class ObjectAssertionTests : AssertionTests
    {
        [Test]
        public void ShouldBe_SameValueReturnsActualValue()
        {
            Equatable actual = new Equatable(1);
            Equatable expected = new Equatable(1);
            Actual<Equatable> result = actual.ShouldBe(expected);

            Assert.AreSame(actual, result.And);
        }

        [Test]
        public void ShouldBe_DifferentObjects_FailsWithObjectsNotEqualMessage()
        {
            object obj1 = new object();
            object obj2 = new object();
            Error.NotEqual(obj2, obj1, "foo").Returns(ExpectedException);

            Exception result = Assert.Throws<Exception>(() => obj1.ShouldBe(obj2, "foo"));

            Assert.AreSame(ExpectedException, result);
        }

        [Test]
        public void ShouldBe_DifferentStrings_FailsWithStringsNotEqualMessage()
        {
            Error.NotEqual("foo", "bar", message: "baz").Returns(new Exception("qux"));

            Exception result = Assert.Throws<Exception>(() => "bar".ShouldBe("foo", "baz"));

            Assert.AreEqual("qux", result.Message);
        }

        [Test]
        public void ShouldBe_CorrectlyRegistersAssertion()
        {
            Equatable actual = new Equatable(1);
            Equatable expected = actual;

            actual.ShouldBe(expected);

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
            Assert.AreEqual(nameof(expected), TestExpression.GetExpected());
        }

        [Test]
        public void NullableShouldBe_ValueEqualsExpected_ReturnsActualValue()
        {
            int? actual = 1;

            Actual<int> result = actual.ShouldBe(1);

            Assert.AreEqual(1, result.And);
        }

        [Test]
        public void NullableShouldBe_NoValue_FailsWithObjectsNotEqualMessage()
        {
            int? actual = null;
            const int expected = 1;
            Error.NotEqual(expected, actual, "foo").Returns(ExpectedException);

            Exception result = Assert.Throws<Exception>(() => actual.ShouldBe(expected, "foo"));

            Assert.AreSame(ExpectedException, result);
        }

        [Test]
        public void NullableShouldBe_ValueIsDifferent_FailsWithObjectsNotEqualMessage()
        {
            int? actual = 1;
            const int expected = 2;
            Error.NotEqual(expected, actual, "foo").Returns(ExpectedException);

            Exception result = Assert.Throws<Exception>(() => actual.ShouldBe(expected, "foo"));

            Assert.AreSame(ExpectedException, result);
        }

        [Test]
        public void NullableShouldBe_CorrectlyRegistersAssertion()
        {
            int? actual = 1;
            int expected = actual.Value;

            actual.ShouldBe(expected);

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
            Assert.AreEqual(nameof(expected), TestExpression.GetExpected());
        }

        [Test]
        public void ShouldNotBe_DifferentValue_ReturnsActualValue()
        {
            Equatable actual = new Equatable(1);

            Actual<Equatable> result = actual.ShouldNotBe(new Equatable(2));

            Assert.AreSame(actual, result.Value);
        }

        [Test]
        public void ShouldNotBe_EqualValue_FailsWithObjectsEqualMessage()
        {
            Equatable actual = new Equatable(1);
            Equatable notExpected = new Equatable(1);
            Error.AreEqual(notExpected, actual, "foo").Returns(ExpectedException);

            Exception result = Assert.Throws<Exception>(() => actual.ShouldNotBe(notExpected, "foo"));

            Assert.AreSame(ExpectedException, result);
        }

        [Test]
        public void ShouldNotBe_CorrectlyRegistersAssertion()
        {
            Equatable actual = new Equatable(1);
            Equatable notExpected = new Equatable(2);

            actual.ShouldNotBe(notExpected);

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
            Assert.AreEqual(nameof(notExpected), TestExpression.GetExpected());
        }

        [Test]
        public void ShouldBeNull_IsNull_Passes()
        {
            ((object)null).ShouldBeNull();
        }

        [Test]
        public void ShouldBeNull_NotNull_FailsWithNotEqualToNullMessage()
        {
            object actual = new object();
            Error.NotEqual(null, actual, "foo").Returns(ExpectedException);

            Exception result = Assert.Throws<Exception>(() => actual.ShouldBeNull("foo"));

            Assert.AreSame(ExpectedException, result);
        }

        [Test]
        public void ShouldBeNull_CorrectlyRegistersAssertion()
        {
            object actual = null;

            actual.ShouldBeNull();

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
        }

        [Test]
        public void ShouldNotBeNull_NotNull_ReturnsActualValue()
        {
            object actual = new object();

            Actual<object> result = actual.ShouldNotBeNull();

            Assert.AreSame(actual, result.And);
        }

        [Test]
        public void ShouldNotBeNull_IsNull_FailsWithIsNullMessage()
        {
            Error.IsNull("foo").Returns(ExpectedException);

            Exception result = Assert.Throws<Exception>(() => ((object)null).ShouldNotBeNull("foo"));

            Assert.AreSame(ExpectedException, result);
        }

        [Test]
        public void ShouldNotBeNull_CorrectlyRegistersAssertion()
        {
            object actual = new object();

            actual.ShouldNotBeNull();

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
        }

        [Test]
        public void ShouldReferTo_SameObject_ReturnsActualValue()
        {
            object obj = new object();
            Actual<object> result = obj.ShouldReferTo(obj);

            Assert.AreSame(obj, result.And);
        }

        [Test]
        public void ShouldReferTo_DifferentObject_FailsWithObjectsNotSameMessage()
        {
            Equatable actual = new Equatable(1);
            Equatable expected = new Equatable(1);
            Error.NotSame(expected, actual, "foo").Returns(ExpectedException);

            Exception result = Assert.Throws<Exception>(() => actual.ShouldReferTo(expected, "foo"));

            Assert.AreSame(ExpectedException, result);
        }

        [Test]
        public void ShouldReferTo_CorrectlyRegistersAssertion()
        {
            object actual = new object();
            object expected = actual;

            actual.ShouldReferTo(expected);

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
            Assert.AreEqual(nameof(expected), TestExpression.GetExpected());
        }

        [Test]
        public void ShouldNotReferTo_DifferentObject_ReturnsActualValue()
        {
            object actual = new object();

            Actual<object> result = actual.ShouldNotReferTo(new object());

            Assert.AreSame(actual, result.And);
        }

        [Test]
        public void ShouldNotReferTo_SameObject_FailsWithObjectsAreSameMessage()
        {
            object actual = new object();
            Error.AreSame(actual, "foo").Returns(ExpectedException);

            Exception result = Assert.Throws<Exception>(() => actual.ShouldNotReferTo(actual, "foo"));

            Assert.AreSame(ExpectedException, result);
        }

        [Test]
        public void ShouldNotReferTo_CorrectlyRegistersAssertion()
        {
            object actual = new object();
            object notExpected = new object();

            actual.ShouldNotReferTo(notExpected);

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
            Assert.AreEqual(nameof(notExpected), TestExpression.GetExpected());
        }

        [Test]
        public void ShouldBeA_SubType_ReturnsTypedActual()
        {
            object actual = new SubEquatable(1);
            Actual<Equatable> result = actual.ShouldBeA<Equatable>();

            Assert.AreSame(actual, result.And);
            Assert.AreEqual(1, result.And.Value);
        }

        [Test]
        public void ShouldBeA_SuperType_FailsWithTypesNotEqualMessage()
        {
            object actual = new Equatable(1);
            Error.NotEqual(typeof(SubEquatable), typeof(Equatable), "foo").Returns(ExpectedException);
            Exception result = Assert.Throws<Exception>(() => actual.ShouldBeA<SubEquatable>("foo"));

            Assert.AreSame(ExpectedException, result);
        }

        [Test]
        public void ShouldBeA_CorrectlyRegistersAssertion()
        {
            object actual = new SubEquatable(1);

            actual.ShouldBeA<Equatable>();

            Assert.AreEqual(nameof(actual), TestExpression.GetActual());
        }

        protected class Equatable
        {
            public readonly int Value;

            public Equatable(int value)
            {
                Value = value;
            }

            public override bool Equals(object obj)
            {
                Equatable otherEquatable = obj as Equatable;
                return otherEquatable != null
                    && otherEquatable.Value == Value;
            }

            public override int GetHashCode()
            {
                return Value;
            }
        }

        protected class SubEquatable : Equatable
        {
            public SubEquatable(int value) : base(value) { }
        }
    }
}