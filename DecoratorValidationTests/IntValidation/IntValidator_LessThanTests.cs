﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorValidation.IntValidation.Validators;
using NUnit.Framework;
using DecoratorValidation.Core;
namespace DecoratorValidation.IntValidation.Validators.Tests
{
    [TestFixture()]
    public class IntValidator_LessThanTests
    {
        private StringBuilder errorAccumulator;

        [SetUp]
        public void Setup()
        {
            errorAccumulator = new StringBuilder();
        }

        [Test()]
        [TestCase(1, 1, false, false)]
        [TestCase(1, 1, true, true)]
        [TestCase(2, 1, true, false)]
        [TestCase(2, 1, false, false)]
        [TestCase(1, 2, true, true)]
        [TestCase(1, 2, false, true)]
        public void WhenIntValidator_LessThanValidates(int toValidate, int bound, bool orEqualTo, bool expectedResult)
        {
            string errorMessage = "IntValidator_LessThan Failed";
            Validator<int> validator = new ValidatorBaseCase<int>();
            validator = new IntValidator_LessThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test()]
        [TestCase(1, 1, false)]
        public void WhenIntValidator_LessThanFails_ErrorMessageIsGenerated(int toValidate, int bound, bool orEqualTo)
        {
            string errorMessage = "IntValidator_LessThan Failed";
            Validator<int> validator = new ValidatorBaseCase<int>();
            validator = new IntValidator_LessThan(validator, bound, orEqualTo, errorMessage);
            bool actual = validator.Validate(toValidate);
            Assert.That(validator.ErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
