using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Domain.DataObjects;
using System.Text.Json;

namespace InMemoryInfra.ImageRepository
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

            using (FileStream fs = new FileStream(_filePath, FileMode.Open))
            {
                IEnumerable<Image> list = JsonSerializer.Deserialize<IEnumerable<Image>>(fs);
                foreach (Image image in list)
                {
                    _repository.Add(image.ImageId, image);
                }
            }
        }

        public void Add(int imageId, Image image)
        {
            _repository.Add(imageId, image);
            IEnumerable<Image> list = _repository.GetAll().Values;

            using (FileStream fs = new FileStream(_filePath, FileMode.Append))
            {
                JsonSerializer.Serialize<IEnumerable<Image>>(fs, list);
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
