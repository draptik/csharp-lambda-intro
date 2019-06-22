using System;
using FluentAssertions;
using Xunit;

namespace LambdaDemos.Tests
{
    public class Demos
    {
        public class HelloWorld
        {
            private static int Add(int a, int b)
            {
                return a + b;
            }

            [Fact]
            public void Adding_two_numbers_works()
            {
                Add(1, 2).Should().Be(3);
            }
            
            // TODO Intro to Expression Body vs Statement
            // TODO Intro to Extension Methods
        }

        public class ExtensionMethodDemo
        {
            // GOAL: Enrich some class
            //
            // Example: c# string class
            //
            // Option 1: Derive from String class (not allowed in C#, but in Java!)
//            class MyString : String
//            {
//            }

            // Option 2: Extension methods
            // NOTE: Extension classes in c# can't be nested!
            [Fact]
            public void ExtensionDemo_works_classic() 
                // ReSharper disable once InvokeAsExtensionMethod
                => FooExtensions.AddOne(123).Should().Be(124);

            [Fact]
            public void ExtensionDemo_works() 
                => 123.AddOne().Should().Be(124);
        }
        
        public class SingleInputSingleOutput
        {
            private static int AddOne(int i) => i + 1;

            [Fact]
            public void AddOne_works() 
                => AddOne(1).Should().Be(2);

            private static int NumberOfDigits(int i) => i.ToString().Length;

            [Theory]
            [InlineData(1, 1)]
            [InlineData(12, 2)]
            [InlineData(123, 3)]
            public void NumberOfDigits_works(int input, int expected)
                => NumberOfDigits(input).Should().Be(expected);
        }

        public class WhatIsAFunction
        {
            [Fact]
            public void Function_works1()
            {
                // string -> int
                Func<string, int> foo = s => 42;
                foo("12345678").Should().Be(42);
            }

            [Fact]
            public void Function_works2()
            {
                // string -> int
                Func<string, int> foo = s => s.Length;
                foo("12345678").Should().Be(8);
            }

            [Fact]
            public void Function_works3()
            {
                // void -> int
                // No input, only output
                Func<int> foo = () => 42;
                foo().Should().Be(42);
            }
        }

        public class UsingAFunction
        {
            public class MyClass
            {
                public static int DoSomethingWithFunction(string s, Func<string, int> func) 
                    => func(s);
            }

            // string -> int
            Func<string, int> foo = s => s.Length;

            [Fact]
            public void DoSomethingWithFunction_works() 
                => MyClass.DoSomethingWithFunction("abc", foo).Should().Be(3);
        }
    }
}