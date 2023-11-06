namespace ugolekback.EmailF
{


    public interface ICode
    {
        string GetCode();
    }
    public class Code: ICode
    {
        string ICode.GetCode()
        {
            Random rnd = new Random();
            
            int value = rnd.Next(1010, 9090);
            string code = value.ToString();
            return code;
        }
    }
}
