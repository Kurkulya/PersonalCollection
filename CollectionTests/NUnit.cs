﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Compatibility;
using PersonalCollection;

   
namespace CollectionTests
{
    [TestFixture(typeof(AList0))]
    [TestFixture(typeof(AList1))]
    [TestFixture(typeof(AList2))]
    [TestFixture(typeof(LList1))]
    [TestFixture(typeof(LList2))]
    [TestFixture(typeof(LListR))]
    [TestFixture(typeof(AListR))]
    [TestFixture(typeof(LListF))]
    public class NUnitTests<TPage> where TPage : IList, new()
    {
        IList lst = new TPage();
       
        [SetUp]
        public void SetUp()
        {
            lst.Clear();
        }

        [Test]
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 5, 6 }, new int[] { 5, 6 })]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 9, 1 })]
        public void TestToArray(int[] input, int[] res)
        {
            lst.Init(input);
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

        [Test]
        [TestCase(null, new int[] { })]
        [TestCase(new int[]{ }, new int[] { })]
        [TestCase(new int[] {2 }, new int[] {2 })]
        [TestCase(new int[] {5,6 }, new int[] {5,6 })]
        [TestCase(new int[] { 3,7,4,9,1}, new int[] { 3, 7, 4, 9, 1 })]
        public void TestInit(int[] input, int[] res)
        {          
            lst.Init(input);
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestGetExEmpty(int[] input)
        {
            lst.Init(input);           
            var ex = Assert.Throws<EmptyArrayEx>(() => lst.Get(0));
            Assert.AreEqual(typeof(EmptyArrayEx), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, -1)]
        [TestCase(new int[] { 2 }, 1)]
        [TestCase(new int[] { 5, 6 }, -1)]
        [TestCase(new int[] { 5, 6 }, 2)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, -1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 5)]
        public void TestGetExOutRange(int[] input, int pos)
        {
            lst.Init(input);
            var ex = Assert.Throws<IndexOutOfRangeException>(() => lst.Get(pos));
            Assert.AreEqual(typeof(IndexOutOfRangeException), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, 0, 2)]
        [TestCase(new int[] { 12, 3 }, 0, 12)]
        [TestCase(new int[] { 12, 3 }, 1, 3)]
        [TestCase(new int[] { 2, 1, 0, -10, 80 }, 0, 2)]
        [TestCase(new int[] { 2, 1, 0, -10, 80 }, 3, -10)]
        [TestCase(new int[] { 2, 1, 0, -10, 80 }, 4, 80)]
        public void TestGet(int[] input, int pos, int val)
        {
            lst.Init(input);
            Assert.AreEqual(val, lst.Get(pos));
        }

        [Test]
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 2 }, 1)]
        [TestCase(new int[] { 5, 6 }, 2)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 5)]
        public void TestSize(int[] input, int res)
        {           
            lst.Init(input);
            Assert.AreEqual(res, lst.Size());
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 2 })]
        [TestCase(new int[] { 5, 6 })]
        [TestCase(new int[] { 3, 7, 4, 9, 1 })]
        public void TestClear(int[] input)
        {           
            lst.Init(input);
            lst.Clear();
            Assert.AreEqual(0, lst.Size());
        }


        [Test]
        [TestCase(null, "")]
        [TestCase(new int[] { }, "")]
        [TestCase(new int[] { 2 }, "2")]
        [TestCase(new int[] { 5, 6 }, "5, 6")]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, "3, 7, 4, 9, 1")]
        public void TestToString(int[] input, string res)
        {        
            lst.Init(input);
            Assert.AreEqual(res, lst.ToString());
        }

        [Test]
        [TestCase(null, new int[] {0 } , 1)]
        [TestCase(new int[] { }, new int[] {0 }, 1)]
        [TestCase(new int[] { 2 }, new int[] {0, 2 }, 2)]
        [TestCase(new int[] { 5, 6 }, new int[] { 0,5, 6 }, 3)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] {0, 3, 7, 4, 9, 1 }, 6)]
        public void TestAddStart(int[] input, int[] res, int size)
        {            
            lst.Init(input);
            lst.AddStart(0);
            Assert.AreEqual(size, lst.Size());
            Assert.AreEqual(0, lst.Get(0));           
            CollectionAssert.AreEqual(res, lst.ToArray());
        }



        [Test]
        [TestCase(null, new int[] { 0 },1)]
        [TestCase(new int[] { }, new int[] { 0 },1)]
        [TestCase(new int[] { 2 }, new int[] { 2, 0 },2)]
        [TestCase(new int[] { 5, 6 }, new int[] { 5, 6, 0 },3)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 9, 1,0 },6)]
        public void TestAddEnd(int[] input, int[] res, int size)
        {            
            lst.Init(input);
            lst.AddEnd(0);
            Assert.AreEqual(size, lst.Size());
            Assert.AreEqual(0, lst.Get(lst.Size()-1));            
            CollectionAssert.AreEqual(res, lst.ToArray());
        }



        [Test]
        [TestCase(null, -1)]
        [TestCase(null,  1)]
        [TestCase(new int[] { }, -1)]
        [TestCase(new int[] { },  1)]
        [TestCase(new int[] { 2 }, -1)]
        [TestCase(new int[] { 2 },  2)]
        [TestCase(new int[] { 5, 6 }, -1)]
        [TestCase(new int[] { 5, 6 },  3)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, -1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 },  6)]
        public void TestAddPosExEmpty(int[] input, int pos)
        {           
            lst.Init(input);
            var ex = Assert.Throws<IndexOutOfRangeException>(() => lst.AddPos(pos, 5));
            Assert.AreEqual(typeof(IndexOutOfRangeException), ex.GetType());
        }

        [Test]
        [TestCase(null, new int[] { 0 }, 0 , 1)]
        [TestCase(new int[] {  }, new int[] { 0 }, 0, 1)]
        [TestCase(new int[] { 2 }, new int[] { 0, 2 }, 0, 2)]
        [TestCase(new int[] { 2 }, new int[] { 2, 0 }, 1, 2)]
        [TestCase(new int[] { 5, 6 }, new int[] { 0, 5, 6 },0, 3)]
        [TestCase(new int[] { 5, 6 }, new int[] { 5, 6, 0 },2, 3)]
        [TestCase(new int[] { 5, 6 }, new int[] { 5, 0, 6 },1, 3)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 0, 3, 7, 4, 9, 1 },0, 6)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 9, 1, 0 },5, 6)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 0, 9, 1 },3, 6)]
        public void TestAddPos(int[] input, int[] res, int pos, int size)
        {           
            lst.Init(input);
            lst.AddPos(pos,0);
            Assert.AreEqual(size, lst.Size());
            Assert.AreEqual(0, lst.Get(pos));
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[] {  })]
        public void TestDelStartExEmpty(int[] input)
        {            
            lst.Init(input);        
            var ex = Assert.Throws<EmptyArrayEx>(() => lst.DelStart());
            Assert.AreEqual(typeof(EmptyArrayEx), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, new int[] { }, 2, 0)]
        [TestCase(new int[] { 5, 6 }, new int[] { 6 }, 5, 1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 7, 4, 9, 1 }, 3, 4)]
        public void TestDelStart(int[] input, int[] res, int val, int size)
        {         
            lst.Init(input);
            int delVal = lst.DelStart();
            Assert.AreEqual(size, lst.Size());
            Assert.AreEqual(val, delVal);           
            CollectionAssert.AreEqual(res, lst.ToArray());
        }


        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestDelEndExEmpty(int[] input)
        {
            lst.Init(input);
            var ex = Assert.Throws<EmptyArrayEx>(() => lst.DelEnd());
            Assert.AreEqual(typeof(EmptyArrayEx), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, new int[] { }, 2, 0)]
        [TestCase(new int[] { 5, 6 }, new int[] { 5 }, 6, 1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 9 }, 1, 4)]
        public void TestDelEnd(int[] input, int[] res, int val, int size)
        {           
            lst.Init(input);
            int delVal = lst.DelEnd();
            Assert.AreEqual(size, lst.Size());
            Assert.AreEqual(val, delVal);
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestDelPosExEmpty(int[] input)
        {
            lst.Init(input);
            var ex = Assert.Throws<EmptyArrayEx>(() => lst.DelPos(0));
            Assert.AreEqual(typeof(EmptyArrayEx), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, -1)]
        [TestCase(new int[] { 2 }, 1)]
        [TestCase(new int[] { 5, 6 }, -1)]
        [TestCase(new int[] { 5, 6 }, 2)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, -1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 5)]
        public void TestDelPosExOutRange(int[] input, int pos)
        {         
            lst.Init(input);
            var ex = Assert.Throws<IndexOutOfRangeException>(() => lst.DelPos(pos));
            Assert.AreEqual(typeof(IndexOutOfRangeException), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, new int[] {  }, 0, 2, 0)]
        [TestCase(new int[] { 5, 6 }, new int[] { 6 }, 0, 5, 1)]
        [TestCase(new int[] { 5, 6 }, new int[] { 5 }, 1, 6, 1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 7, 4, 9, 1 }, 0, 3, 4)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 1 }, 3, 9, 4)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, new int[] { 3, 7, 4, 9 }, 4, 1, 4)]
        public void TestDelPos(int[] input, int[] res, int pos, int val, int size)
        {       
            lst.Init(input);
            int delVal = lst.DelPos(pos);
            Assert.AreEqual(size, lst.Size());
            Assert.AreEqual(val, delVal);
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestMinExEmpty(int[] input)
        {         
            lst.Init(input);
            var ex = Assert.Throws<EmptyArrayEx>(() => lst.Min());
            Assert.AreEqual(typeof(EmptyArrayEx), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, 2)]
        [TestCase(new int[] { 12, 3 }, 3)]
        [TestCase(new int[] { 2, 1, 0, -10, 80, -15, 9, -15 }, -15)]
        public void TestMin(int[] arr, int res)
        {          
            lst.Init(arr);
            Assert.AreEqual(res, lst.Min());
        }


        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestMaxExEmpty(int[] input)
        {     
            lst.Init(input);
            var ex = Assert.Throws<EmptyArrayEx>(() => lst.Max());
            Assert.AreEqual(typeof(EmptyArrayEx), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, 2)]
        [TestCase(new int[] { 12, 3 }, 12)]
        [TestCase(new int[] { 2, 1, 0, -10, 80, -15, 9, -15 }, 80)]
        public void TestMax(int[] arr, int res)
        {
            
            lst.Init(arr);
            Assert.AreEqual(res, lst.Max());
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestMinPosExEmpty(int[] input)
        {          
            lst.Init(input);
            var ex = Assert.Throws<EmptyArrayEx>(() => lst.MinPos());
            Assert.AreEqual(typeof(EmptyArrayEx), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, 0)]
        [TestCase(new int[] { 12, 3 }, 1)]
        [TestCase(new int[] { 2, 1, 0, -10, 80, -15, 9, -15 }, 5)]
        public void TestMinPos(int[] arr, int res)
        {            
            lst.Init(arr);
            Assert.AreEqual(res, lst.MinPos());
        }


        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestMaxPosExEmpty(int[] input)
        {  
            lst.Init(input);
            var ex = Assert.Throws<EmptyArrayEx>(() => lst.MaxPos());
            Assert.AreEqual(typeof(EmptyArrayEx), ex.GetType());
        }
        [Test]
        [TestCase(new int[] { 2 }, 0)]
        [TestCase(new int[] { 12, 3 }, 0)]
        [TestCase(new int[] { 2, 1, 0, -10, 80, -15, 9, -15 }, 4)]
        public void TestMaxPos(int[] arr, int res)
        {
            
            lst.Init(arr);
            Assert.AreEqual(res, lst.MaxPos());
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void TestSetExEmpty(int[] input)
        {
            lst.Init(input);
            var ex = Assert.Throws<EmptyArrayEx>(() => lst.Set(0,0));
            Assert.AreEqual(typeof(EmptyArrayEx), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, -1)]
        [TestCase(new int[] { 2 }, 1)]
        [TestCase(new int[] { 5, 6 }, -1)]
        [TestCase(new int[] { 5, 6 }, 2)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, -1)]
        [TestCase(new int[] { 3, 7, 4, 9, 1 }, 5)]
        public void TestSetExOutRange(int[] input, int pos)
        {           
            lst.Init(input);
            var ex = Assert.Throws<IndexOutOfRangeException>(() => lst.Set(pos, 0));
            Assert.AreEqual(typeof(IndexOutOfRangeException), ex.GetType());
        }

        [Test]
        [TestCase(new int[] { 2 }, new int[] { 0 }, 0)]
        [TestCase(new int[] { 12, 3 }, new int[] { 0, 3 }, 0)]
        [TestCase(new int[] { 12, 3 }, new int[] { 12, 0 }, 1)]
        [TestCase(new int[] { 2, 1, 0, -10, 80 }, new int[] { 0, 1, 0, -10, 80 },0)]
        [TestCase(new int[] { 2, 1, 0, -10, 80}, new int[] { 2, 1, 0, 0, 80 },3)]
        [TestCase(new int[] { 2, 1, 0, -10, 80}, new int[] { 2, 1, 0, -10, 0 },4)]
        public void TestSet(int[] arr, int[] res, int pos)
        {           
            lst.Init(arr);
            lst.Set(pos, 0);
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

        [Test]
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 12, 3 }, new int[] { 3, 12 })]
        [TestCase(new int[] { 2, 1, 0, -10, 80, -15, 9, 5 }, new int[] { 5, 9, -15, 80, -10, 0, 1, 2 })]
        public void TestReverse(int[] arr, int[] res)
        {       
            lst.Init(arr);
            lst.Reverse();
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

        [Test]
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 12, 3 }, new int[] { 3, 12 })]
        [TestCase(new int[] { 2, 1, 0, 80, -15, 9, 5 }, new int[] {-15, 9, 5, 80, 2, 1, 0 })]
        public void TestHalfReverse(int[] arr, int[] res)
        {
            
            lst.Init(arr);
            lst.HalfReverse();
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

 
        [Test]
        [TestCase(null, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { 12, 3 }, new int[] { 3, 12 })]
        [TestCase(new int[] { 2, 1, 0, 80, -15, 9, -15 }, new int[] { -15, -15, 0, 1, 2, 9, 80 })]
        public void TestSort(int[] arr, int[] res)
        {
            
            lst.Init(arr);
            lst.Sort();
            CollectionAssert.AreEqual(res, lst.ToArray());
        }

        [TestCase(null)]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        public void TestForeach(int[] input)
        {
            lst.Init(input);
            int i = 0;
            foreach (int item in lst)
            {
                Assert.AreEqual(item, input[i++]);
            }
        }
    }
}
