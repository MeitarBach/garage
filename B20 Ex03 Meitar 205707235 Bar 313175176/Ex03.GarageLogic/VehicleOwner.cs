namespace Ex03.GarageLogic
{
    public class VehicleOwner
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return string.Format(
@"Owner Name: {0}
Owner Phone Number: {1}", Name, PhoneNumber);
        }
    }
}
