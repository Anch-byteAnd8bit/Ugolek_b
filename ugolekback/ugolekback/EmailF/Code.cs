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
            //Получить случайное число (в диапазоне от 0 до 10)
            int value = rnd.Next(1010, 9090);
            string code = value.ToString();
            return code;
        }
    }
}
