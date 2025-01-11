using Domain.DataObjects;

namespace Application.Repositories
{
    public interface IGraphRepository
    {

        int Get(int graphId);

        void Add(int graphId, int graphingHandle);


    }
}
