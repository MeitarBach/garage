namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const float k_MinVolumeOfCargo = 0;
        private bool m_ContainsDangerousMaterials;
        private float m_VolumeOfCargo;

        public Truck(string i_LicenseNumber, string i_ModelName, Engine i_Engine)
            : base(i_LicenseNumber, i_ModelName, i_Engine)
        {
        }

        public bool ContainsDangerousMaterials
        {
            get
            {
                return m_ContainsDangerousMaterials;
            }

            set
            {
                m_ContainsDangerousMaterials = value;
            }
        }

        public float VolumeOfCargo
        {
            get
            {
                return m_VolumeOfCargo;
            }

            set
            {
                Validation.ValidRange(value, k_MinVolumeOfCargo);
                m_VolumeOfCargo = value;
            }
        }

        public string ContainsDagerousMaterialsOrNot()
        {
            string containsOrNot = m_ContainsDangerousMaterials ? "contains" : "doesn't contain";

            return containsOrNot;
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
The truck {1} dagerous materials
Volume of Cargo: {2}", base.ToString(), ContainsDagerousMaterialsOrNot(), m_VolumeOfCargo);
        }
    }
}
