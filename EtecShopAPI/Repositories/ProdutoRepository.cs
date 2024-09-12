using EtecShopAPI.Collections;
using MongoDB.Driver;

namespace EtecShopAPI.Repositories;
public class ProdutoRepository : IProdutoRepository
{
    private readonly IMongoCollection<Produto> _collection;
    public ProdutoRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Produto>("produtos");
    }

    public Task CreateAsync(Produto produto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Produto>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();


    public Task<Produto> GetByIdAsync(string id) =>
        await _collection.Find(_ => _.Id == id).FirstOrDefaultAsync();

    public Task UpdateAsync(Produto produto)
    {
        throw new NotImplementedException();
    }
}
