using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using CsvSerializer;
using Domain.DataObjects;

namespace InMemoryInfra
{
    public class FileImageRepository : IImageRepository
    {

        private string _filePath;

        private IImageRepository _repository;

        public FileImageRepository(string filePath)
        {
            _filePath = filePath;
            _repository = new InMemoryImageRepository();
            Initialize();
        }

        private void Initialize()
        {
            Deserializer deserializer = new Deserializer(_filePath);
            List<Image> list = deserializer.DeserializeObject<Image>();
            foreach (Image image in list)
            {
                _repository.Add(image.ImageId, image);
            }
        }

        public void Add(int imageId, Image image)
        {
            _repository.Add(imageId, image);
            IEnumerable<Image> list = _repository.GetAll().Values;

            using (FileStream fs = new FileStream(_filePath, FileMode.Append))
            {
                Serializer serializer = new Serializer();
                serializer.SerializeObjects<Image>(list, fs);
            }
        }

        public Image Get(int imageId)
        {
            return _repository.Get(imageId);
        }

        public Dictionary<int, Image> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
