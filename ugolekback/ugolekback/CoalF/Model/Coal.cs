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
        private static List<Coal> _coals = new List<Coal>()
        {
            new Coal{ Id=1, Name="Montemagno, Pizza shaped like a great mountain", Price = 150000, Supplier="Кемуглесбыт" },
            new Coal{ Id=2, Name="The Galloway, Pizza shaped like a submarine, silent but deadly", Price = 210000, Supplier="Кумуглесбыт"},
            new Coal{ Id=3, Name="The Noring, Pizza shaped like a Viking helmet, where's the mead", Price = 230000, Supplier="Камуглесбыт"}
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
