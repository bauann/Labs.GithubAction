namespace Labs.GithubAction.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void OrdStringConvert_OddString_GetErrorResult()
    {
        var convert = new StringConvert();
        Assert.ThrowsException<NotSupportedException>(
            () => convert.ConvertOrdString("123"));
    }

    [TestMethod]
    public void OrdStringConvert_EvenString_GetCorrectResult()
    {
        var data = "56";
        var convert = new StringConvert();
        var actual = convert.ConvertOrdString(data);
        Assert.AreEqual("e", actual);
    }
}