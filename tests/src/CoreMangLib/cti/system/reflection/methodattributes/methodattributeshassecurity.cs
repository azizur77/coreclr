using System;
using System.Reflection;

/// <summary>
/// System.Reflection.MethodAttributes.HasSecurity[v-juwa]
/// </summary>
public class MethodAttributesHasSecurity
{
    #region Public Methods
    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;

        return retVal;
    }

    #region Positive Test Cases
    public bool PosTest1()
    {
        bool retVal = true;

        const string c_TEST_DESC = "PosTest1:check the MethodAttributes.HasSecurity value is 16384...";
        const string c_TEST_ID = "P001";
        MethodAttributes FLAG_VALUE = (MethodAttributes)16384;

        TestLibrary.TestFramework.BeginScenario(c_TEST_DESC);

        try
        {

            if (MethodAttributes.HasSecurity != FLAG_VALUE)
            {
                string errorDesc = "value is not " + FLAG_VALUE.ToString() + " as expected: Actual is " + MethodAttributes.HasSecurity.ToString();
                TestLibrary.TestFramework.LogError("001" + " TestId-" + c_TEST_ID, errorDesc);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002" + " TestId-" + c_TEST_ID, "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    #endregion

    #endregion

    public static int Main()
    {
        MethodAttributesHasSecurity test = new MethodAttributesHasSecurity();

        TestLibrary.TestFramework.BeginTestCase("System.Reflection.MethodAttributes.HasSecurity");

        if (test.RunTests())
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
}
