using System;
using System.Globalization;

/// <summary>
/// String.System.IConvertible.ToByte(IFormatProvider provider)
/// This method supports the .NET Framework infrastructure and is 
/// not intended to be used directly from your code. 
/// Converts the value of the current String object to an 8-bit unsigned integer. 
/// </summary>
class IConvertibleToByte
{
    private const int c_MIN_STRING_LEN = 8;
    private const int c_MAX_STRING_LEN = 256;

    public static int Main()
    {
        IConvertibleToByte iege = new IConvertibleToByte();

        TestLibrary.TestFramework.BeginTestCase("for method: String.System.IConvertible.ToByte(IFormatProvider)");
        if (iege.RunTests())
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

        return retVal;
    }

    #region Positive test scenarioes

    public bool PosTest1()
    {
        bool retVal = true;

        const string c_TEST_DESC = "PosTest1: Random numeric string";
        const string c_TEST_ID = "P001";

        string strSrc;
        IFormatProvider provider;
        byte b;
        bool expectedValue = true;
        bool actualValue = false;

        b = TestLibrary.Generator.GetByte(-55);
        strSrc = b.ToString();
        provider = null;

        TestLibrary.TestFramework.BeginScenario(c_TEST_DESC);
        try
        {
            actualValue = (b == ((IConvertible)strSrc).ToByte(provider));
            if (actualValue != expectedValue)
            {
                string errorDesc = "Value is not " + expectedValue + " as expected: Actual(" + actualValue + ")";
                errorDesc += GetDataString(strSrc, provider);
                TestLibrary.TestFramework.LogError("001" + " TestId-" + c_TEST_ID, errorDesc);
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002" + " TestId-" + c_TEST_ID, "Unexpected exception: " + e + GetDataString(strSrc, provider));
            retVal = false;
        }

        return retVal;
    }

    public bool PosTest2()
    {
        bool retVal = true;

        const string c_TEST_DESC = "PosTest2: Positive sign";
        const string c_TEST_ID = "P002";

        string strSrc;
        IFormatProvider provider;
        NumberFormatInfo ni = new NumberFormatInfo();
        byte b;
        bool expectedValue = true;
        bool actualValue = false;

        b = TestLibrary.Generator.GetByte(-55);
        ni.PositiveSign = TestLibrary.Generator.GetString(-55, false, c_MIN_STRING_LEN, c_MAX_STRING_LEN);
        strSrc = ni.PositiveSign + b.ToString();
        provider = (IFormatProvider)ni;

        TestLibrary.TestFramework.BeginScenario(c_TEST_DESC);
        try
        {
            actualValue = (b == ((IConvertible)strSrc).ToByte(provider));
            if (actualValue != expectedValue)
            {
                string errorDesc = "Value is not " + expectedValue + " as expected: Actual(" + actualValue + ")";
                errorDesc += GetDataString(strSrc, provider);
                TestLibrary.TestFramework.LogError("003" + " TestId-" + c_TEST_ID, errorDesc);
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("004" + " TestId-" + c_TEST_ID, "Unexpected exception: " + e + GetDataString(strSrc, provider));
            retVal = false;
        }

        return retVal;
    }

    public bool PosTest3()
    {
        bool retVal = true;

        const string c_TEST_DESC = "PosTest3: string is Byte.MaxValue";
        const string c_TEST_ID = "P003";

        string strSrc;
        IFormatProvider provider;
        bool expectedValue = true;
        bool actualValue = false;

        strSrc = byte.MaxValue.ToString();
        provider = null;

        TestLibrary.TestFramework.BeginScenario(c_TEST_DESC);
        try
        {
            actualValue = (byte.MaxValue == ((IConvertible)strSrc).ToByte(provider));
            if (actualValue != expectedValue)
            {
                string errorDesc = "Value is not " + expectedValue + " as expected: Actual(" + actualValue + ")";
                errorDesc += GetDataString(strSrc, provider);
                TestLibrary.TestFramework.LogError("005" + " TestId-" + c_TEST_ID, errorDesc);
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("006" + " TestId-" + c_TEST_ID, "Unexpected exception: " + e + GetDataString(strSrc, provider));
            retVal = false;
        }

        return retVal;
    }

    public bool PosTest4()
    {
        bool retVal = true;

        const string c_TEST_DESC = "PosTest4: string is Byte.MinValue";
        const string c_TEST_ID = "P004";

        string strSrc;
        IFormatProvider provider;
        bool expectedValue = true;
        bool actualValue = false;

        strSrc = byte.MinValue.ToString();
        provider = null;

        TestLibrary.TestFramework.BeginScenario(c_TEST_DESC);
        try
        {
            actualValue = (byte.MinValue == ((IConvertible)strSrc).ToByte(provider));
            if (actualValue != expectedValue)
            {
                string errorDesc = "Value is not " + expectedValue + " as expected: Actual(" + actualValue + ")";
                errorDesc += GetDataString(strSrc, provider);
                TestLibrary.TestFramework.LogError("007" + " TestId-" + c_TEST_ID, errorDesc);
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("008" + " TestId-" + c_TEST_ID, "Unexpected exception: " + e + GetDataString(strSrc, provider));
            retVal = false;
        }

        return retVal;
    }

    #endregion // end for positive test scenarioes

    #region Negative test scenarios

    public bool NegTest1()
    {
        bool retVal = true;

        const string c_TEST_DESC = "NegTest1: The value of String object cannot be parsed";
        const string c_TEST_ID = "N001";

        string strSrc;
        IFormatProvider provider;

        strSrc = "p" + TestLibrary.Generator.GetString(-55, false, 9, c_MAX_STRING_LEN);
        provider = null;

        TestLibrary.TestFramework.BeginScenario(c_TEST_DESC);
        try
        {
            ((IConvertible)strSrc).ToByte(provider);
            TestLibrary.TestFramework.LogError("009" + "TestId-" + c_TEST_ID, "FormatException is not thrown as expected" + GetDataString(strSrc, provider));
            retVal = false;
        }
        catch (FormatException)
        { }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("010" + "TestId-" + c_TEST_ID, "Unexpected exception:" + e + GetDataString(strSrc, provider));
            retVal = false;
        }

        return retVal;
    }

    public bool NegTest2()
    {
        bool retVal = true;

        const string c_TEST_DESC = "NegTest2: The value of String object is a number greater than MaxValue";
        const string c_TEST_ID = "N002";

        string strSrc;
        IFormatProvider provider;
        int i;

        i = byte.MaxValue + 1 + TestLibrary.Generator.GetByte(-55);
        strSrc = i.ToString();
        provider = null;

        TestLibrary.TestFramework.BeginScenario(c_TEST_DESC);
        try
        {
            ((IConvertible)strSrc).ToByte(provider);
            TestLibrary.TestFramework.LogError("011" + "TestId-" + c_TEST_ID, "OverflowException is not thrown as expected" + GetDataString(strSrc, provider));
            retVal = false;
        }
        catch (OverflowException)
        { }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("012" + "TestId-" + c_TEST_ID, "Unexpected exception:" + e + GetDataString(strSrc, provider));
            retVal = false;
        }

        return retVal;
    }

    public bool NegTest3()
    {
        bool retVal = true;

        const string c_TEST_DESC = "NegTest3: The value of String object is a number less than MinValue";
        const string c_TEST_ID = "N003";

        string strSrc;
        IFormatProvider provider;
        int i;

        // new update 8-14-2006 Noter(v-yaduoj)
        i = -1*TestLibrary.Generator.GetByte(-55) - 1;
        strSrc = i.ToString();
        provider = null;

        TestLibrary.TestFramework.BeginScenario(c_TEST_DESC);
        try
        {
            ((IConvertible)strSrc).ToByte(provider);
            TestLibrary.TestFramework.LogError("013" + "TestId-" + c_TEST_ID, "OverflowException is not thrown as expected" + GetDataString(strSrc, provider));
            retVal = false;
        }
        catch (OverflowException)
        { }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("014" + "TestId-" + c_TEST_ID, "Unexpected exception:" + e + GetDataString(strSrc, provider));
            retVal = false;
        }

        return retVal;
    }

    #endregion

    private string GetDataString(string strSrc, IFormatProvider provider)
    {
        string str1, str2, str;
        int len1;

        if (null == strSrc)
        {
            str1 = "null";
            len1 = 0;
        }
        else
        {
            str1 = strSrc;
            len1 = strSrc.Length;
        }

        str2 = (null == provider) ? "null" : provider.ToString();

        str = string.Format("\n[Source string value]\n \"{0}\"", str1);
        str += string.Format("\n[Length of source string]\n {0}", len1);
        str += string.Format("\n[Format provider string]\n {0}", str2);

        return str;
    }

}
