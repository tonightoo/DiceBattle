using Domain.DataObjects;
using System.Collections.Generic;

namespace Application.Repositories
{
    public interface IImageRepository
    {

        Image Get(int imageId);

        void Add(int imageId, Image image);

        Dictionary<int, Image> GetAll();

    }
}
