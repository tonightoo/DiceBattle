using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.DataObjects;

namespace InMemoryInfra
{
    public class InMemoryGraphRepository : IGraphRepository
    {

        public Dictionary<int, int> Graphs = new Dictionary<int, int>();

        public int Get(int graphId)
        {
            return Graphs[graphId];
        }

        public void Add(int graphId, int graph)
        {
            Graphs.Add(graphId, graph);
        }

    }
}
