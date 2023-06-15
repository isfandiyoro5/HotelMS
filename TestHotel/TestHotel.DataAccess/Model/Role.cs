namespace TestHotel.DataAccess.Model
{
    public class Role
    {
        public int RoleId { get; set; }

        public string RoleTitle { get; set; }

        public string RoleDescription { get; set; }


        public List<Employee> Employee { get; set; }
    }
}
