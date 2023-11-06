namespace ugolekback.CoalF.Model
{
    public record Coal
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public decimal Price { get; set; } 
        public string Supplier { get; set; } 
    }


    public class CoalDB
    {
        public static List<Coal> _coals = new List<Coal>()
        {
            new Coal{ Id=1, Name="ДМСШ 0-25", Price = 150000, Supplier="Кемуглесбыт" },
            new Coal{ Id=2, Name="ДО 25-50", Price = 210000, Supplier="СУЭК-Хакасия"},
            new Coal{ Id=3, Name="TДПК 50-200", Price = 230000, Supplier="Разрез Изыхский"}
        };

        public static List<Coal> GetCoals()
        {
            return _coals;
        }

       

        

        
    }

}
