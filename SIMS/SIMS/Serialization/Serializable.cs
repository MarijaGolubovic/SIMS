namespace SIMS.Serialization
{
    interface Serializable
    {

        string[] toCSV();

        void fromCSV(string[] values);
    }


}
