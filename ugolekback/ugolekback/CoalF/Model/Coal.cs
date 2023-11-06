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

        public static Coal? GetCoal(int id)
        {
            return _coals.SingleOrDefault(coal => coal.Id == id);
        }

        public static Coal CreateCoal(Coal coal)
        {
            _coals.Add(coal);
            return coal;
        }

        public static Coal UpdateCoal(Coal update)
        {
            _coals = _coals.Select(coal =>
            {
                if (coal.Id == update.Id)
                {
                    coal.Name = update.Name;
                }
                return coal;
            }).ToList();
            return update;
        }

        public static void RemoveCoal(int id)
        {
            _coals = _coals.FindAll(coal => coal.Id != id).ToList();
        }
    }

}
