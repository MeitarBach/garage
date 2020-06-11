namespace Ex03.GarageLogic
{
    public class VehicleOwner
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public VehicleOwner(string i_Name, string i_PhoneNumber)
        {
            Name = i_Name;
            PhoneNumber = i_PhoneNumber;
        }
    }
}
