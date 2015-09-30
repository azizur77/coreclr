using System;
using System.Globalization;
using System.Collections;
/// <summary>
/// CopyTo
/// </summary>
public class ArrayCopyTo
{
    const int c_MaxValue = 10;
    const int c_MinValue = 0;
    public static int Main()
    {
        ArrayCopyTo ArrayCopyTo = new ArrayCopyTo();

        TestLibrary.TestFramework.BeginTestCase("ArrayCopyTo");
        if (ArrayCopyTo.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }

    public bool RunTests()
    {
        bool retVal = true;
        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;
        retVal = PosTest4() && retVal;
        TestLibrary.TestFramework.LogInformation("[Negative]");
        retVal = NegTest1() && retVal;
        retVal = NegTest2() && retVal;
        retVal = NegTest3() && retVal;
        retVal = NegTest4() && retVal;
        retVal = NegTest5() && retVal;
        retVal = NegTest6() && retVal;
        retVal = NegTest7() && retVal;
        retVal = NegTest8() && retVal;
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest1:Copies all the elements of the current one-dimensional Array to the specified one-dimensional Array starting at the specified destination Array index,the two array have the same value type.");
        try
        {
            Array myOriginalArray = Array.CreateInstance(typeof(Int32), c_MaxValue);
            Array myTargetArray = Array.CreateInstance(typeof(Int32), c_MaxValue * 2);
            for (int i = 0; i < c_MaxValue; i++)
            {
                myOriginalArray.SetValue(i, i);
                myTargetArray.SetValue(i + c_MaxValue, i);
            }
            myOriginalArray.CopyTo(myTargetArray, c_MaxValue);
            int index = c_MaxValue;
            for (IEnumerator itr = myOriginalArray.GetEnumerator(); itr.MoveNext(); )
            {
                object current = itr.Current;
                if (!current.Equals(myTargetArray.GetValue(index)))
                {
                    TestLibrary.TestFramework.LogError("001", "Copy error");
                    retVal = false;
                    break;
                }
                index++;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest2:Copies all the elements of the current one-dimensional Array to the specified one-dimensional Array starting at the specified destination Array index,the two array have the same reference type.");
        try
        {
            Array myOriginalArray = Array.CreateInstance(typeof(string), c_MaxValue);
            Array myTargetArray = Array.CreateInstance(typeof(string), c_MaxValue * 2);
            string generator1 = string.Empty;
            string generator2 = string.Empty;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator1 = TestLibrary.Generator.GetString(-55, true, c_MinValue, c_MaxValue);
                generator2 = TestLibrary.Generator.GetString(-55, true, c_MinValue, c_MaxValue);
                myOriginalArray.SetValue(generator1, i);
                myTargetArray.SetValue(generator2, i);
            }
            myOriginalArray.CopyTo(myTargetArray, c_MaxValue);
            int index = c_MaxValue;
            for (IEnumerator itr = myOriginalArray.GetEnumerator(); itr.MoveNext(); )
            {
                object current = itr.Current;
                if (!current.Equals(myTargetArray.GetValue(index)))
                {
                    TestLibrary.TestFramework.LogError("003", "Copy error");
                    retVal = false;
                    break;
                }
                index++;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("004", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest3()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest3:Copies all the elements of the current one-dimensional Array to the specified one-dimensional Array starting at the specified destination Array index,the two array can upcast.");
        try
        {
            Array myOriginalArray = Array.CreateInstance(typeof(TestDeriveClass), c_MaxValue);
            Array myTargetArray = Array.CreateInstance(typeof(TestBaseClass), c_MaxValue * 2);
            TestDeriveClass generator1;
            TestBaseClass generator2;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator1 = new TestDeriveClass(i);
                generator2 = new TestDeriveClass(i + c_MaxValue);
                myOriginalArray.SetValue(generator1, i);
                myTargetArray.SetValue(generator2, i);
            }
            myOriginalArray.CopyTo(myTargetArray, c_MaxValue);
            int index = c_MaxValue;
            for (IEnumerator itr = myOriginalArray.GetEnumerator(); itr.MoveNext(); )
            {
                object current = itr.Current;
                if (!current.Equals(myTargetArray.GetValue(index)))
                {
                    TestLibrary.TestFramework.LogError("005", "Copy error");
                    retVal = false;
                    break;
                }
                index++;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("006", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest4()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest4:Copies all the elements of the current one-dimensional Array to the specified one-dimensional Array starting at the specified destination Array index,the two array can boxing.");
        try
        {
            Array myOriginalArray = Array.CreateInstance(typeof(Int32), c_MaxValue);
            Array myTargetArray = Array.CreateInstance(typeof(Object), c_MaxValue * 2);
            int generator1;
            object generator2;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator1 = i;
                generator2 = i + c_MaxValue;
                myOriginalArray.SetValue(generator1, i);
                myTargetArray.SetValue(generator2, i);
            }
            myOriginalArray.CopyTo(myTargetArray, c_MaxValue);
            int index = c_MaxValue;
            for (IEnumerator itr = myOriginalArray.GetEnumerator(); itr.MoveNext(); )
            {
                object current = itr.Current;
                if (!current.Equals(myTargetArray.GetValue(index)))
                {
                    TestLibrary.TestFramework.LogError("007", "Copy error");
                    retVal = false;
                    break;
                }
                index++;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("008", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest1:myTargetArray is a null reference.");
        try
        {
            Array myOriginalArray = Array.CreateInstance(typeof(Int32), c_MaxValue);
            Array myTargetArray = Array.CreateInstance(typeof(Int32), c_MaxValue * 2);
            for (int i = 0; i < c_MaxValue; i++)
            {
                myOriginalArray.SetValue(i, i);
                myTargetArray.SetValue(i + c_MaxValue, i);
            }
            myTargetArray = null;
            myOriginalArray.CopyTo(myTargetArray, c_MaxValue);
            TestLibrary.TestFramework.LogError("009", "Copy error");
            retVal = false;
        }
        catch (ArgumentNullException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("010", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest6:index is less than the lower bound of array.");
        try
        {
            Array myOriginalArray = Array.CreateInstance(typeof(Int32), c_MaxValue);
            Array myTargetArray = Array.CreateInstance(typeof(Int32), c_MaxValue * 2);
            for (int i = 0; i < c_MaxValue; i++)
            {
                myOriginalArray.SetValue(i, i);
                myTargetArray.SetValue(i + c_MaxValue, i);
            }
            myOriginalArray.CopyTo(myTargetArray, c_MinValue-1);
            TestLibrary.TestFramework.LogError("011", "Copy error");
            retVal = false;
        }
        catch (ArgumentOutOfRangeException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("012", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest3()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest3:The source Array is multidimensional.");
        try
        {
            int[] parameter ={ c_MaxValue, c_MaxValue };
            Array myOriginalArray = Array.CreateInstance(typeof(Int32), parameter);
            Array myTargetArray = Array.CreateInstance(typeof(Int32), c_MaxValue*3);
            myOriginalArray.CopyTo(myTargetArray, c_MinValue - 1);
            TestLibrary.TestFramework.LogError("013", "Copy error");
            retVal = false;
        }
        catch (RankException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("014", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest4()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest4:The type of the source Array cannot be cast automatically to the type of the destination array.");
        try
        {
            Array myOriginalArray = Array.CreateInstance(typeof(Int32), c_MaxValue);
            Array myTargetArray = Array.CreateInstance(typeof(string), c_MaxValue * 2);
            myOriginalArray.CopyTo(myTargetArray, c_MaxValue);
            TestLibrary.TestFramework.LogError("015", "Copy error");
            retVal = false;
        }
        catch (ArrayTypeMismatchException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("016", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest5()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest5:array is multidimensional.");
        try
        {
            Array myOriginalArray = Array.CreateInstance(typeof(Int32), c_MaxValue);
            int[] parameter ={ c_MaxValue, c_MaxValue };
            Array myTargetArray = Array.CreateInstance(typeof(Int32), parameter);
            for (int i = 0; i < c_MaxValue; i++)
            {
                myOriginalArray.SetValue(i, i);
            }
            myOriginalArray.CopyTo(myTargetArray, c_MaxValue);
            TestLibrary.TestFramework.LogError("017", "Copy error");
            retVal = false;
        }
        catch (ArgumentException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("018", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest6()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest6:index is equal to or greater than the length of array.");
        try
        {
            Array myOriginalArray = Array.CreateInstance(typeof(Int32), c_MaxValue);
            Array myTargetArray = Array.CreateInstance(typeof(Int32), c_MaxValue);
            for (int i = 0; i < c_MaxValue; i++)
            {
                myOriginalArray.SetValue(i, i);
            }
            myOriginalArray.CopyTo(myTargetArray, c_MaxValue);
            TestLibrary.TestFramework.LogError("019", "Copy error");
            retVal = false;
        }
        catch (ArgumentException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("020", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest7()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest7:The number of elements in the source Array is greater than the available space from index to the end of the destination array.");
        try
        {
            Array myOriginalArray = Array.CreateInstance(typeof(Int32), c_MaxValue * 2);
            Array myTargetArray = Array.CreateInstance(typeof(Int32), c_MaxValue);
            for (int i = 0; i < c_MaxValue; i++)
            {
                myOriginalArray.SetValue(i, i);
            }
            myOriginalArray.CopyTo(myTargetArray, c_MinValue);
            TestLibrary.TestFramework.LogError("021", "Copy error");
            retVal = false;
        }
        catch (ArgumentException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("022", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest8()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest8:At least one element in sourceArray cannot be cast to the type of destinationArray.");
        try
        {
            Array myOriginalArray = Array.CreateInstance(typeof(ITestInterface), c_MaxValue);
            Array myTargetArray = Array.CreateInstance(typeof(TestBaseClass), c_MaxValue * 2);
            TestDeriveClass generator1;
            TestBaseClass generator2;
            TestDeriveClass1 generator3 = new TestDeriveClass1(100);
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator1 = new TestDeriveClass(i);
                generator2 = new TestDeriveClass(i + c_MaxValue);
                myOriginalArray.SetValue(generator1, i);
                myTargetArray.SetValue(generator2, i);
            }

            myOriginalArray.SetValue(generator3, c_MaxValue - 1);
            myOriginalArray.CopyTo(myTargetArray, c_MinValue);
            TestLibrary.TestFramework.LogError("023", "Copy error");
            retVal = false;
        }
        catch (InvalidCastException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("024", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
}



//create ITestInterface  for Negtest8.
interface ITestInterface
{
    string GetName();
}
//create TestBaseClass  for provding test method and test target.
public abstract class TestBaseClass
{
    // The value holder
    protected int id;
    public TestBaseClass(int Id)
    {
        id = Id;
    }
    protected int m_value;
    protected abstract int GetValue();

}
//create TestDeriveClass  for provding test method and test source.
public class TestDeriveClass : TestBaseClass, ITestInterface
{
    int deriveId;
    public TestDeriveClass(int Id)
        : base(Id)
    {
        deriveId = Id;
    }

    protected override int GetValue()
    {
        return deriveId;
    }


    #region ITestInterface Members

    public string GetName()
    {
        return "TestDeriveClass";
    }

    #endregion
}
//create TestDeriveClass  for provding test method and test source.
public class TestDeriveClass1 : ITestInterface
{
    int deriveId;
    public TestDeriveClass1(int Id)
    {
        deriveId = Id;
    }

    protected int GetValue()
    {
        return deriveId;
    }
    #region ITestInterface Members

    public string GetName()
    {
        return "TestDeriveClass1";
    }

    #endregion
}
