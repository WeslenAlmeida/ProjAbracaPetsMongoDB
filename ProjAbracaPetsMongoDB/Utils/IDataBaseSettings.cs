namespace ProjAbracaPetsMongoDB.Utils
{
    public interface IDataBaseSettings
    {
        string AdopterCollectionName { get; set; }
        string AnimalCollectionName { get; set; }
        string AdoptionCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DataBaseName { get; set; }
    }
}
