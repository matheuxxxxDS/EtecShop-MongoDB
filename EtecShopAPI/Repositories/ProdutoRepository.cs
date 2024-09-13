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

    public async Task CreateAsync(Produto produto) =>
        await _collection.InsertOneAsync(produto);

    public async Task DeleteAsync(string id) =>
        await _collection.DeleteOneAsync(_ => _.Id == id);


    public async Task<List<Produto>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();


    public async Task<Produto> GetByIdAsync(string id) =>
        await _collection.Find(_ => _.Id == id).FirstOrDefaultAsync();

    public async Task UpdateAsync(Produto produto) =>
        await _collection.ReplaceOneAsync(_ => _.Id == produto.Id, produto);
}
