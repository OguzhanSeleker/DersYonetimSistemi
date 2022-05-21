
namespace Services.Homework.Infrastructure.DbSettings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string HomeworkInformationCollectionName { get; set; }
        public string HomeworkMetadataCollectionName { get; set; }
        public string StudentHomeworkMetadataCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
