using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.DataObjects;

namespace InMemoryInfra.ImageRepository
{
    public class InMemoryImageRepository : IImageRepository
    {

        public Dictionary<int, Image> Images = new Dictionary<int, Image>();

        public Image Get(int imageId)
        {
            return Images[imageId];
        }

        public void Add(int imageId, Image image)
        {
            if (Images.ContainsKey(imageId))
            {
                Images[imageId] = image;
            }
            else
            {
                Images.Add(imageId, image);
            }
        }

        public Dictionary<int, Image> GetAll()
        {
            return Images;
        }

    }
}
