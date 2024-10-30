namespace WebApplication1._1.Services
{
    public class TestDI : ITestDI
    {
        public int GenId()
        {
            var newId = GetHashCode(); //generate ตัวเลขมั่วๆมา
            return newId;
        }
    }
}
