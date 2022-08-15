using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Homework.Infrastructure.DbSettings
{
    public interface IDatabaseSettings
    {
        public string HomeworkInformationCollectionName { get; set; }
        public string HomeworkMetadataCollectionName { get; set; }
        public string StudentHomeworkMetadataCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
