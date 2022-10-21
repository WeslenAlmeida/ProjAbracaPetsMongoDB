namespace ProjAbracaPetsMongoDB.Utils
{
    public class DataBaseSettings : IDataBaseSettings
    {
       public string AdopterCollectionName { get; set; }
       public string AnimalCollectionName { get; set; }
       public string AdoptionCollectionName { get; set; }
       public string ConnectionString { get; set; }
       public string DataBaseName { get; set; }
    }
}
